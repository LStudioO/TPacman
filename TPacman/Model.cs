using System;
using System.Collections.Generic;
using System.Threading;

namespace TPacman
{

    public delegate void Strip();

    public class Model
    {

        public Wall Wall
        {
            get
            {
                return wall;
            }

            set
            {
                wall = value;
            }
        }
        public Pacman Pacman
        {
            get
            {
                return pacman;
            }

            set
            {
                pacman = value;
            }
        }
        public Projectile Projectile
        {
            get
            {
                return projectile;
            }

            set
            {
                projectile = value;
            }
        }
        public List<FireTank> FireTanks
        {
            get
            {
                return fireTanks;
            }
        }
        public List<Tank> Tanks
        {
            get { return tanks; }
        }
        public List<Star> Stars
        {
            get { return stars; }
        }
        public int speedGame;

        public event Strip changeStrip;
        public GameStatus gameStatus;

        Wall wall;
        Pacman pacman;
        Projectile projectile;
        List<Tank> tanks;
        List<FireTank> fireTanks;
        List<Star> stars;

        int collectedStars;
        int sizeField;
        int amountTanks;
        int amountApples;
        static Random r;

        public Model(int sizeField, int amountTanks, int amountApples, int speedGame)
        {

            this.sizeField = sizeField;
            this.amountTanks = amountTanks;
            this.amountApples = amountApples;
            this.speedGame = speedGame;

            r = new Random();

            NewGame();
        }

        public void NewGame()
        {
            gameStatus = GameStatus.stoped;

            this.collectedStars = 0;
            pacman = new Pacman(sizeField);
            projectile = new Projectile();
            tanks = new List<Tank>();
            fireTanks = new List<FireTank>();
            stars = new List<Star>();

            CreateTanks();
            CreateStars();

            wall = new Wall();
        }
        public void Play()
        {
            while (gameStatus == GameStatus.playing)
            {
                Thread.Sleep(speedGame);

                pacman.Run();

                projectile.Run();

                ((Hunter)tanks[0]).Run(pacman.X, pacman.Y);

                for (int i = 1; i < tanks.Count; i++)
                    tanks[i].Run();

                for (int i = 0; i < fireTanks.Count; i++)
                    fireTanks[i].Fire();

                for (int i = 1; i < tanks.Count; i++)
                {
                    if (Math.Abs(tanks[i].X - projectile.X) < 11 && Math.Abs(tanks[i].Y - projectile.Y) < 11)
                    {
                        fireTanks.Add(new FireTank(tanks[i].X, tanks[i].Y));
                        tanks.RemoveAt(i);
                        projectile.Reset();
                    }
                }

                for (int i = 0; i < tanks.Count; i++)
                    for (int j = i + 1; j < tanks.Count; j++)
                    {
                        // прорахувати наскрізні зіткнення
                        if (
                            (Math.Abs(tanks[i].X - tanks[j].X) <= 20 && (tanks[i].Y == tanks[j].Y))
                            ||
                            (Math.Abs(tanks[i].Y - tanks[j].Y) <= 20 && (tanks[i].X == tanks[j].X))
                            ||
                            (Math.Abs(tanks[i].X - tanks[j].X) <= 20 && (Math.Abs(tanks[i].Y - tanks[j].Y) <= 20))
                           )
                        {
                            if (i == 0)
                                ((Hunter)tanks[0]).TurnAround();
                            else
                            {
                                tanks[i].TurnAround();
                                tanks[i].Run();
                            }
                            tanks[j].TurnAround();
                            tanks[j].Run();
                        }
                    }


                for (int i = 0; i < tanks.Count; i++)
                {
                    if (
                        (Math.Abs(tanks[i].X - pacman.X) <= 18 && (tanks[i].Y == pacman.Y))
                        ||
                        (Math.Abs(tanks[i].Y - pacman.Y) <= 18 && (tanks[i].X == pacman.X))
                        ||
                        (Math.Abs(tanks[i].X - pacman.X) <= 18 && (Math.Abs(tanks[i].Y - pacman.Y) <= 18))
                       )
                    {
                        gameStatus = GameStatus.looser;
                        changeStrip?.Invoke();
                    }
                }

                for (int i = 0; i < stars.Count; i++)
                    if (pacman.X == stars[i].X && pacman.Y == stars[i].Y)
                    {
                        stars[i] = new Star(22 * collectedStars, 270);
                        collectedStars++;
                        CreateStars(collectedStars);
                    }

                if (collectedStars > 4)
                {
                    gameStatus = GameStatus.winner;
                    changeStrip?.Invoke();
                }
            }
        }

        private void CreateStars(int newStars = 0)
        {
            int x, y;
            while (stars.Count < amountApples + newStars)
            {
                x = r.Next(6) * 40;
                y = r.Next(6) * 40;
                bool flag = true;
                foreach (var itm in stars)
                    if (itm.X == x && itm.Y == y)
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                    stars.Add(new Star(x, y));
            }
        }
        private void CreateTanks()
        {
            int x, y;
            while (tanks.Count < amountTanks + 1)
            {
                x = r.Next(6) * 40;
                y = r.Next(6) * 40;

                if (tanks.Count == 0)
                {
                    tanks.Add(new Hunter(sizeField, x, y));
                    continue;
                }

                bool flag = true;
                foreach (var itm in tanks)
                    if (itm.X == x && itm.Y == y)
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                    tanks.Add(new Tank(sizeField, x, y));
            }
        }
    }
}
