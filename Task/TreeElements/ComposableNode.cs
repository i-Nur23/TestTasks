using Task.TreeElements.Interfaces;

namespace Task.TreeElements
{
    /// <summary>
    /// Абстрактный класс для нетерминальных узлов дерева - строки и колонки
    /// </summary>
    public abstract class ComposableNode : ITreeNode
    {

        public Bitmap Image { get; protected set; }

        public float Width => Image.Width;

        public float Height => Image.Height;

        public bool IsNormalized { get; private set; } = false;

        public List<ITreeNode> Children { get; private set; }

        public ComposableNode()
        {
            Children = new List<ITreeNode>();
        }

        /// <summary>
        /// Добавление дочернего элемента
        /// </summary>
        /// <param name="newNode">Новый дочерний узел</param>
        /// <returns>Ссылка на текущий экземпляр класса</returns>
        public ComposableNode Add(ITreeNode newNode)
        {
            Children.Add(newNode);
            return this;
        }

        /// <summary>
        /// Добавление дочерних элементов
        /// </summary>
        /// <param name="newNodes">Новые дочерние узлы</param>
        /// <returns>Ссылка на текущий экземпляр класса</returns>
        public ComposableNode AddRange(params ITreeNode[] newNodes)
        {
            Children.AddRange(newNodes);
            return this;
        }

        public abstract void CreateImage();

        public void Normalize()
        {
            foreach (var item in Children)
            {
                if (!item.IsNormalized)
                {
                    item.Normalize();
                }
            }

            CreateImage();
            IsNormalized = true;
        }
        
    }
}
