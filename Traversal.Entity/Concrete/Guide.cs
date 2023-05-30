using Traversal.CoreLayer.Entity.Abstract;

namespace Traversal.Entity.Concrete
{
    public class Guide : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string TwitterUrl{ get; set; }
        public string InstagramUrl { get; set; }
    }
}
