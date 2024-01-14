using Task.TreeElements.Interfaces;

namespace Task.TreeElements
{
    /// <summary>
    /// Класс для терминальных узлов дерева - изображений
    /// </summary>
    public class ImageInfo : ITreeNode
    {
        public Bitmap Image { get; set; }

        // Путь к базовой папке с изображениями
        private static string basicFolder;

        public float Width => Image.Width;

        public float Height => Image.Height;

        public bool IsNormalized => true;

        public List<ITreeNode> Children => null;

        /// <summary>
        /// Конструктор класса, инициализирующий изображение
        /// </summary>
        /// <param name="fileName">Имя файла изображения</param>
        public ImageInfo(string fileName)
        {
            Image = (Bitmap)Bitmap.FromFile(Path.Combine(basicFolder, fileName));
        }

        public void Normalize() { }

        public void CreateImage() { }

        /// <summary>
        /// Метод, устанавливающий базовую папку
        /// </summary>
        /// <param name="path">Путь к папке</param>
        public static void SetBasicFolder(string path) 
        {
            basicFolder = path;
        }   
    }
}
