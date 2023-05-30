using Traversal.CoreLayer.Entity.Abstract;

namespace Traversal.Entity.Concrete
{
    public class SubAbout : EntityBase, IEntity
    {
        public string Title{ get; set; }
        public string Description { get; set; }
    }
}
    