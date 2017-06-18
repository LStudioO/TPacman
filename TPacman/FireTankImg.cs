using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;

namespace TPacman
{
    public class FireTankImg
    {
        Image[] img = new Image[]
        {
            Properties.Resources.fire0,
            Properties.Resources.fire1,
            Properties.Resources._01,
            Properties.Resources._001,
            Properties.Resources.fire2,
            Properties.Resources.fire3
        };

        public Image[] Img
        {
            get { return img; }
        }
    }
}
