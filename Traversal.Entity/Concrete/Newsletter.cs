using Traversal.CoreLayer.Entity.Abstract;

namespace Traversal.Entity.Concrete
{
    public class Newsletter : EntityBase, IEntity
    {
        public string Mail { get; set; }
    }
}
    