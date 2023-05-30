using Microsoft.EntityFrameworkCore;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection Strings

            optionsBuilder.UseSqlServer("Data Source=APACHIE;database=TraversalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }



        //public Context(DbContextOptions<Context> options):base(options)
        //{

        //}


        //Db'ye yansimasini istedigimiz entity class'lar

        public DbSet<About> Abouts { get; set; }
        public DbSet<About2> Abouts2 { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Feature2> Features2 { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }


    }
}
