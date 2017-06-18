using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPacman
{
    public class PacmanImg
    {
        Image img0_1 = Properties.Resources.Pacman0_1;
        Image img01 = Properties.Resources.Pacman01;
        Image img10 = Properties.Resources.Pacman10;
        Image img_10 = Properties.Resources.Pacman_10;

        public Image Img0_1
        {
            get { return img0_1; }
        }

        public Image Img01
        {
            get { return img01; }
        }

        public Image Img10
        {
            get { return img10; }
        }

        public Image Img_10
        {
            get { return img_10; }
        }

    }
}
