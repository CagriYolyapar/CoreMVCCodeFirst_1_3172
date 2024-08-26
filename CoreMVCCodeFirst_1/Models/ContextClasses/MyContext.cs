using CoreMVCCodeFirst_1.Models.Configurations;
using CoreMVCCodeFirst_1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCCodeFirst_1.Models.ContextClasses
{

    //Package Manager Console'da add-migration Mig1
    public class MyContext : DbContext
    {
        //BUrada DbContextOptions<MyContext> tipini belirterek aslında Middleware'de yaptıgımız ayarlanmaları temsil ediyoruz..Sonra o tipte bir parametreyi argüman olarak DbContext isimli sınıfın (miras aldıgımız sınıfın) constructor'ina gönderiyoruz...
        public MyContext(DbContextOptions<MyContext> opt) :base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //sakın base.OnModelCreating(modelBuilder) metodunu kodların sonuna yazmayın. En basta bulunsun...
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserProfile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
