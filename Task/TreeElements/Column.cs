namespace Task.TreeElements
{
    /// <summary>
    /// Класс, описывающий колонку
    /// </summary>
    public class Column : ComposableNode
    {
        public override void CreateImage()
        {
            var height = ExtremeParameterValues.GetMaxHeight();

            var divider = Children[0].Height;

            for (int i = 1; i < Children.Count; i++)
            {
                divider += Children[i].Height * Children[0].Width / Children[i].Width;
            }

            var firstCoefficient = height / divider;
            var width = firstCoefficient * Children[0].Width;

            Image = new Bitmap((int)width, (int)height);

            using (Graphics g = Graphics.FromImage(Image))
            {
                var currentY = 0f;

                for (int i = 0; i < Children.Count; i++)
                {
                    var child = Children[i];
                    g.DrawImage(child.Image, 0, currentY, width, child.Height * firstCoefficient * Children[0].Width / child.Width);
                    currentY += child.Height * firstCoefficient * Children[0].Width / child.Width;
                }
            }
        }
    }
}
