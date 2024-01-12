using System.Drawing;

namespace Task
{
    public class ImagesHandler
    {

        private Image GetImage(string path)
        {
            return Image.FromFile(path);
        }


        public List<Image> ExtractImages(string folder, string[] paths)
        {
            var list = new List<Image>();

            foreach (var path in paths)
            {
                list.Add(GetImage(Path.Combine(folder, path)));
            }

            return list;
        }
    }
}
