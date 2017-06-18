using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPacman
{
    public class Wall : IPicture
    {
        WallImg wallImg = new WallImg();

        Image img;

        public Wall()
        {
            img = wallImg.Img;
        }

        public Image Img
        {
            get { return img; }
        }
    }
}
