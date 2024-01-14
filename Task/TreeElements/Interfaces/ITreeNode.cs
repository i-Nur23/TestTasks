namespace Task.TreeElements.Interfaces
{
    /// <summary>
    /// Интерфейс узла дерева
    /// </summary>
    public interface ITreeNode
    {
        // Изображение текущего узла
        public Bitmap Image { get; }

        // Ширина и высота изображения
        public float Width { get; }
        public float Height { get; }
        
        // Свойство, определяющее, приведен ли узел к прямоугольному виду
        public bool IsNormalized { get; }

        // Список дочерних элементов
        public List<ITreeNode> Children {  get; }

        // Приведение к прямоугольному виду
        public void Normalize();

        // Создание изображения узла
        public void CreateImage();


        

    }
}
