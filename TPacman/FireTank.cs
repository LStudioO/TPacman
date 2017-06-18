using System.Drawing;

namespace TPacman
{
    public class FireTank
    {
        FireTankImg ftImg = new FireTankImg();
        Image currentImg;
        Image[] img;
        int x, y;
        int currentImgPosition;

        public Image CurrentImg
        {
            get
            {
                return currentImg;
            }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public FireTank(int x, int y)
        {
            this.x = x;
            this.y = y;
            currentImgPosition = 0;
            img = ftImg.Img;
            PutCurrentImage();
        }

        public void Fire()
        {
            PutCurrentImage();
        }

        private void PutCurrentImage()
        {
            currentImg = img[currentImgPosition++];
            if (currentImgPosition == img.Length)
                currentImgPosition = 0;
        }

    }
}
