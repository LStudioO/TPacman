using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPacman
{
   public class WallImg
    {
        Image img = Properties.Resources.wall;

        public Image Img
        {
            get { return img; }
        }
    }
}
