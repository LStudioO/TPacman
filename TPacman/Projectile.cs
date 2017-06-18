using System.Drawing;

namespace TPacman
{
    public class Projectile
    {
        ProjectileImg projectileImg = new ProjectileImg();
        Image img;

        int x, y, direct_x, direct_y;
        readonly int max_distance = 120;

        int km;
        public Image Img
        {
            get { return img; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
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

        public Projectile()
        {
            img = projectileImg.Img01;
            Reset();
        }

        public void Run()
        {
            if (direct_x != 0 || direct_y != 0)
                km += 3;    
            x += direct_x * 3;
            y += direct_y * 3;
            PutImg();
            if (km > max_distance)
                Reset();
        }

        public void Reset()
        {
            Direct_x = Direct_y = 0;
            x = y = -300;
            km = 0;
        }

        public bool IsFree()
        {
            return ((x == y) && (x == -300));
        }

        private void PutImg()
        {
            if (direct_x == 1)
                img = projectileImg.Img10;
            else if (direct_x == -1)
                img = projectileImg.Img_10;
            if (direct_y == 1)
                img = projectileImg.Img01;
            else if (direct_y == -1)
                img = projectileImg.Img0_1;
        }
    }
}
