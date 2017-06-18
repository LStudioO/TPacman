using System;

namespace TPacman
{
    public class Hunter : Tank
    {
        HunterImg hunterImg = new HunterImg();
        int target_x, target_y;

        public Hunter(int sizeField, int x, int y) : base(sizeField, x, y)
        {
            PutImg();
        }

        public void Turn(int target_x, int target_y)
        {

            if (turned)
            {
                turned = false;
                return;
            }

            Direct_x = Direct_y = 0;

            if (X > target_x)
            {
                Direct_x = -1;
            } 
            if (X < target_x)
            {
                Direct_x = 1;
            }
            if (Y < target_y)
            {
                Direct_y = 1;
            }
            if (Y < target_y)
            {
                Direct_y = 1;
            }

            if (Direct_x != 0 && Direct_y != 0)
            {
                if (r.Next(5000) < 2500)
                    Direct_x = 0;
                else
                    Direct_y = 0;
            }

            PutImg();
        }

        private void PutImg()
        {
            if (direct_x == 1)
                img = hunterImg.Img10;
            else if (direct_x == -1)
                img = hunterImg.Img_10;

            if (direct_y == 1)
                img = hunterImg.Img01;
            else if (direct_y == -1)
                img = hunterImg.Img0_1;
        }

        public void Run(int pacman_x, int pacman_y)
        {
            target_x = pacman_x;
            target_y = pacman_y;

            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
                Turn(target_x,target_y);

            Transparent();

            x += direct_x;
            y += direct_y;
        }

        public new void TurnAround()
        {
            direct_x *= -1;
            direct_y *= -1;
            PutImg();
            turned = true;
        }

    }
}
