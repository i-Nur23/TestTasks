using System.Drawing.Drawing2D;
using Task.TreeElements;
using Task.TreeElements.Interfaces;

namespace Task
{
    public partial class Form1 : Form
    {
        private int width = 600;
        private string basicPath = "../../../Images";
        private ComposableNode
            r1 = new Row(),
            c1 = new Column(),
            r2 = new Row(),
            c2 = new Column(),
            r3 = new Row();

        private float maxWidth;
        private float maxHeight;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;

            InitializeComponent();

            CreateStoryboard();
        }

        /// <summary>
        /// Создание галереи изображений
        /// </summary>
        private void CreateStoryboard()
        {
            ImageInfo.SetBasicFolder(basicPath);

            r1.AddRange(new ImageInfo("cake.jpg"), c1, new ImageInfo("car1.jpeg"));
            c1.AddRange(r2, new ImageInfo("cat.jpg"));
            r2.AddRange(new ImageInfo("city.jpg"), c2);
            c2.AddRange(r3, new ImageInfo("dog.jpg"));
            r3.AddRange(new ImageInfo("mountain.jpeg"), new ImageInfo("nature.jpg"));

            DrawStoryboard(r1);
        }

        /// <summary>
        /// Создание галереи изображений
        /// </summary>
        /// <param name="root">Корень дерева</param>
        private void DrawStoryboard(ITreeNode root)
        {
            SetMaximumValues(root);
            ExtremeParameterValues.InitializeMaxValues(maxWidth, maxHeight);

            root.Normalize();
            var percent = width / root.Width;
            var height = root.Height * percent;
            using (Bitmap bmp = new Bitmap((int)width, (int)height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(root.Image, 0, 0, width, height);
                }

                bmp.Save("../../../result.jpg");
            }
        }

        /// <summary>
        /// Поиск максимальных высоты и ширины изображений
        /// </summary>
        /// <param name="node">Текущий узел дерева</param>
        private void SetMaximumValues(ITreeNode node)
        {
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    SetMaximumValues(child);
                }

                return;
            }

            if (node.Height > maxHeight) maxHeight = node.Height;
            if (node.Width > maxWidth) maxWidth = node.Width;
        }

        /// <summary>
        /// Загрузка изображения в PictureBox на форме
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            var img = Image.FromFile("../../../result.jpg");
            pictureBox.Width = img.Width; 
            pictureBox.Height = img.Height;
            pictureBox.Image = img;
        }


    }
}