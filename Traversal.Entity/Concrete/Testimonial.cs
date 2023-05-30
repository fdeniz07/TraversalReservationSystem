using Traversal.CoreLayer.Entity.Abstract;

namespace Traversal.Entity.Concrete
{
    public class Testimonial : EntityBase, IEntity
    {
        public string Client { get; set; }
        public string Comment { get; set; }
        public string ClientImage { get; set; }
    }
}
