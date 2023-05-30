using Traversal.CoreLayer.Entity.Abstract;

namespace Traversal.Entity.Concrete
{
    public class About2 : EntityBase, IEntity
    {
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
