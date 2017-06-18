using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPacman
{
    public class Star : IPicture
    {
        StarImg starImg = new StarImg();

        Image img;
        int x, y;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Star(int x, int y)
        {
            img = starImg.Img;
            this.x = x;
            this.y = y;
        }

        public Image Img
        {
            get { return img; }
        }
    }
}
