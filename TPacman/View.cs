using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace TPacman
{
    public partial class View : UserControl
    {

        Model model;

        public View(Model model)
        {
            InitializeComponent();

            this.model = model;

            // double buffering
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.UpdateStyles();

        }

        void Draw(PaintEventArgs e)
        {
            DrawWall(e);
            DrawStar(e);
            DrawTank(e);
            DrawFireTank(e);
            DrawPacman(e);
            DrawProjectile(e);

            if (model.gameStatus != GameStatus.playing)
                return;

            Invalidate();
            Thread.Sleep(model.speedGame);
        }

        private void DrawTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.Tanks.Count; i++)
                e.Graphics.DrawImage(model.Tanks[i].Img, new Point(model.Tanks[i].X, model.Tanks[i].Y));
        }

        private void DrawFireTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.FireTanks.Count; i++)
                e.Graphics.DrawImage(model.FireTanks[i].CurrentImg, new Point(model.FireTanks[i].X, model.FireTanks[i].Y));
        }

        private void DrawPacman(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Pacman.Img, new Point(model.Pacman.X, model.Pacman.Y));
        }

        private void DrawProjectile(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Projectile.Img, new Point(model.Projectile.X, model.Projectile.Y));
        }

        private void DrawStar(PaintEventArgs e)
        {
            for(int i = 0; i < model.Stars.Count; i++)
                e.Graphics.DrawImage(model.Stars[i].Img, new Point(model.Stars[i].X, model.Stars[i].Y));
        }

        private void DrawWall(PaintEventArgs e)
        {
            for (int y = 20; y < 260; y += 40)
                for (int x = 20; x < 260; x += 40)
                    e.Graphics.DrawImage(model.Wall.Img, new Point(x, y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }
    }
}
