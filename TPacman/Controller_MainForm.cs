using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System;
using System.Media;


namespace TPacman
{
    delegate void Invoker();

    public partial class Controller_MainForm : Form
    {
        private const int SIZE_FIELD = 260;
        private const int AMOUNT_TANKS = 5;
        private const int AMOUNT_APPLE = 5;
        private const int SPEED_GAME = 20;

        View view;
        Model model;
        Thread modelPlay;
        bool isSound;

        public Controller_MainForm() : this(SIZE_FIELD) { }
        public Controller_MainForm(int sizeField) : this(sizeField, AMOUNT_TANKS) { }
        public Controller_MainForm(int sizeField, int amountTanks) : this(sizeField, amountTanks, AMOUNT_APPLE) { }
        public Controller_MainForm(int sizeField, int amountTanks, int amountApples) : this(sizeField, amountTanks, amountApples, SPEED_GAME) { }
        public Controller_MainForm(int sizeField, int amountTanks, int amountApples, int speedGame)
        {
            InitializeComponent();
            model = new Model(sizeField, amountTanks, amountApples, speedGame);
            model.changeStrip += new Strip(ChangeStatusStripLabel);
            view = new View(model);
            this.Controls.Add(view);
            isSound = true;
        }

        private void btnStartStop_Click(object sender, System.EventArgs e)
        {
            if (model.gameStatus == GameStatus.playing)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stoped;
            }
            else
            {
                model.gameStatus = GameStatus.playing;
                modelPlay = new Thread(model.Play);
                modelPlay.IsBackground = true;
                modelPlay.Start();

                view.Invalidate();
            }
        }
        private void Controller_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modelPlay != null)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stoped;
            }
        }
        private void pbtnStartStop_Click(object sender, EventArgs e)
        {
            if (model.gameStatus == GameStatus.playing)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stoped;
                pbtnStartStop.Image = Properties.Resources.start;
            }
            else
            {
                pbtnStartStop.Focus();
                model.gameStatus = GameStatus.playing;
                modelPlay = new Thread(model.Play);
                modelPlay.IsBackground = true;
                modelPlay.Start();
                pbtnStartStop.Image = Properties.Resources.pause;
                view.Invalidate();
            }
            ChangeStatusStripLabel();
        }
        private void ManipulatePacman(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "A":
                    {
                        model.Pacman.NextDirect_x = -1;
                        model.Pacman.NextDirect_y = 0;
                        break;
                    }
                case "W":
                    {
                        model.Pacman.NextDirect_x = 0;
                        model.Pacman.NextDirect_y = -1;
                        break;
                    }
                case "D":
                    {
                        model.Pacman.NextDirect_x = 1;
                        model.Pacman.NextDirect_y = 0;
                        break;
                    }
                case "S":
                    {
                        model.Pacman.NextDirect_x = 0;
                        model.Pacman.NextDirect_y = 1;
                        break;
                    }
                case "Q":
                    {
                        if (model.Projectile.IsFree())
                        {
                            model.Projectile.X = model.Pacman.X + model.Pacman.Direct_x * 10;
                            model.Projectile.Y = model.Pacman.Y + model.Pacman.Direct_y * 10;
                            model.Projectile.Direct_x = model.Pacman.Direct_x;
                            model.Projectile.Direct_y = model.Pacman.Direct_y;
                        }
                        break;
                    }
            }
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.NewGame();
            view.Refresh();
            pbtnStartStop.Image = Properties.Resources.start;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSound = !isSound;
        }
        private void ChangeStatusStripLabel()
        {
            Invoke(new Invoker(SetValueToStrLbl));
        }
        private void SetValueToStrLbl()
        {
            gameStatusStrip.Text = model.gameStatus.ToString();
        }
    }
}
