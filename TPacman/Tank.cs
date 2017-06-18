using System;
using System.Drawing;

namespace TPacman
{

    // переход границі і поворот

    public class Tank : IRun, ITurn, ITurnAround, ITransparent, IPicture
    {
        TankImg tankImg;
        protected Image img;
        protected static Random r;

        protected int x, y;
        protected int direct_x, direct_y;
        protected int sizeField;
        protected bool turned;

        public Image Img
        {
            get { return img; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public int Direct_x
        {
            get { return direct_x; }

            set { if (value == 0 || value == -1 || value == 1)
                    direct_x = value;
                else direct_x = 0;
            }
        }

        public int Direct_y
        {
            get { return direct_y; }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_y = value;
                else direct_y = 0;
            }
        }

        public Tank(int sizeField, int x, int y)
        {
            this.sizeField = sizeField;
            turned = false;
            r = new Random();
            tankImg = new TankImg();
            img = tankImg.Img0_1;

            direct_x = r.Next(-1,2);
            if (direct_x == 0)
            {   while (direct_y == 0)
                {
                    direct_y = r.Next(-1, 2);
                }
            }
            else
                direct_y = 0;

            PutImg();

            this.x = x;
            this.y = y;
        }

        public void Run()
        {
            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
                Turn();

            Transparent();

            x += direct_x;
            y += direct_y;
        }

        public void Turn()
        {
            if (turned)
            {
                turned = false;
                return;
            }
                if (r.Next(5000) < 2500) // рухаємося по вертикалі
                {
                    if (direct_y == 0)
                    {
                        direct_x = 0;
                        while (direct_y == 0)
                            Direct_y = r.Next(-1, 2);
                    }
                }
                else // рухаємося по горизонталі
                {
                    if (direct_x == 0)
                    {
                        direct_y = 0;
                        while (direct_x == 0)
                            Direct_x = r.Next(-1, 2);
                    }
                }
            PutImg();
        }
        public void Transparent()
        {
            if (x == -1)
                x = sizeField - 21;
            else if (x == sizeField - 19)
                x = 1;

            if (y == -1)
                y = sizeField - 21;
            else if (y == sizeField - 19)
                y = 1;
        }

        private void PutImg()
        {
            if (direct_x == 1)
                img = tankImg.Img10;
            else if (direct_x == -1)
                img = tankImg.Img_10;

            if (direct_y == 1)
                img = tankImg.Img01;
            else if (direct_y == -1)
                img = tankImg.Img0_1;
        }

        public void TurnAround()
        {
            direct_x *= -1;
            direct_y *= -1;
            PutImg();
            turned = true;
        }

    }
}
