using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPacman
{
    public class Pacman : IRun, ITurn, ITransparent, IPicture
    {
        PacmanImg pacmanImg = new PacmanImg();
        Image img;

        public Image Img
        {
            get
            {
                return img;
            }
        }

        int x, y;
        int direct_x, direct_y;
        int nextDirect_x, nextDirect_y;
        int sizeField;

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

            set
            {
                if (value == 0 || value == -1 || value == 1)
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

        public int NextDirect_x
        {
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    nextDirect_x = value;
                else nextDirect_x = 0;
            }
        }

        public int NextDirect_y
        {
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    nextDirect_y = value;
                else nextDirect_y = 0;
            }
        }

        public Pacman(int sizeField)
        {
            this.sizeField = sizeField;
            this.x = 120;
            this.y = 240;
            this.direct_x = nextDirect_x = 0;
            this.direct_y = nextDirect_y = - 1;
            PutImg();
        }

        void PutImg()
        {
            if (direct_x == 1)
                img = pacmanImg.Img10;
            else if (direct_x == -1)
                img = pacmanImg.Img_10;

            if (direct_y == 1)
                img = pacmanImg.Img01;
            else if (direct_y == -1)
                img = pacmanImg.Img0_1;
        }

        public void Run()
        {
            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
                Turn();

            Transparent();

            x += direct_x;
            y += direct_y;
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

        public void Turn()
        {
            direct_x = nextDirect_x;
            direct_y = nextDirect_y;
            PutImg();
        }

    }
}
