using System.Runtime.CompilerServices;

namespace Task
{
    public partial class Form1 : Form
    {
        private int width = 600;
        private string[] pathsToImages = new string[]
        {
            "cake.jpg",
            "car1.jpeg",
            "cat.jpg",
            "city.jpg",
            "dog.jpg",
            "mountain.jpeg",
            "nature.jpg"
        };

        private ImagesHandler imgHandler = new ImagesHandler();
        private List<Image> images = new List<Image>();
        private float firstCoefficient;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;

            InitializeComponent();

            CreateStoryboard();
        }

        private void CreateStoryboard()
        {
            images = imgHandler.ExtractImages("../../../Images", pathsToImages);

            if (images.Count == 0)
            {
                return;
            }

            var divider = images[0].Width;

            for (int i = 1; i < images.Count; i++)
            {
                divider += images[i].Width * images[0].Height / images[i].Height;
            }

            firstCoefficient = (float)width / divider;
            var height = (int)Math.Ceiling(firstCoefficient * images[0].Height);

            SaveImage(images, height);

        }

        private void SaveImage(List<Image> images, int height)
        {
            using (Bitmap bmp = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    float currentXCoord = 0f;

                    foreach (var image in images)
                    {
                        g.DrawImage(image, currentXCoord, 0, image.Width * firstCoefficient * images[0].Height / image.Height, height);
                        currentXCoord += image.Width * firstCoefficient * images[0].Height / image.Height;
                    }
                }

                bmp.Save("../../../result.jpg");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var img = Image.FromFile("../../../result.jpg");
            pictureBox.Width = img.Width; 
            pictureBox.Height = img.Height;
            pictureBox.Image = img;
        }
    }
}