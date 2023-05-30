using Traversal.CoreLayer.Entity.Abstract;

namespace Traversal.Entity.Concrete
{
    public class Feature2 : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
