namespace Task
{
    /// <summary>
    /// Singleton-класс для хранения максимальных значений ширины и высоты изображений
    /// </summary>
    public class ExtremeParameterValues
    {
        private static float maxWidth;
        private static float maxHeight;

        public static void InitializeMaxValues(float width, float height)
        {
            maxWidth = width;  
            maxHeight = height;
        }

        public static float GetMaxWidth()
        {
            return maxWidth;
        }

        public static float GetMaxHeight()
        {
            return maxHeight;
        }
    }
}
