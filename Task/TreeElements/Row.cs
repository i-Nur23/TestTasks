namespace Task.TreeElements
{
    /// <summary>
    /// Класс, описывающий строку
    /// </summary>
    public class Row : ComposableNode
    {
        public override void CreateImage()
        {
            var width = ExtremeParameterValues.GetMaxWidth();

            var divider = Children[0].Width;

            for (int i = 1; i < Children.Count; i++)
            {
                divider += Children[i].Width * Children[0].Height / Children[i].Height;
            }

            var firstCoefficient = width / divider;
            var height = firstCoefficient * Children[0].Height;

            Image = new Bitmap((int)width, (int)height);

            using (Graphics g = Graphics.FromImage(Image))
            {
                var currentX = 0;

                for (int i = 0; i < Children.Count; i++)
                {
                    var child = Children[i];
                    g.DrawImage(child.Image, currentX, 0, child.Width * firstCoefficient * Children[0].Height / child.Height, height);
                    currentX += (int)(child.Width * firstCoefficient * Children[0].Height / child.Height);
                }
            }

              
        }
    }
}
