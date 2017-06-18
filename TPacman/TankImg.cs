using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPacman
{
    public class TankImg
    {
        Image img0_1 = Properties.Resources.Tank0_1;
        Image img01 = Properties.Resources.Tank01;
        Image img10 = Properties.Resources.Tank10;
        Image img_10 = Properties.Resources.Tank_10;

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
