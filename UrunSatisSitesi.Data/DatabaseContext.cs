using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunSatisSitesi.Entities;

namespace UrunSatisSitesi.Data
{
    // Bu sınıfda entity framework kullanacağımız için Solution kısmından UrunSatisSitesi.Data projesine sağ tık yapıp menage nuget packages menüsüne tıklıyoruz. ve açılan pencereden browse sekmesine tıklayıp "microsoft.EntitiyFrameworkCore, microsoft.entityframeworkcore.design, microsoft.entityframeworkcore.sqlserver,microsoft.entityframeworkcore.microsoft.entityframeworkcore.tools" paketlerini install diyip gelen uyarıyı kabul edip yüklüyoruz.
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //ctor yazıp tab tab ile oluşturabiliriz.
            
        }
        //Katmanlı mimaride bir katman (UrunSatisSitesi.Data katmanı gibi) başka bir katmanada erişecekse bunu solution kısmından projenin altındaki dependencies bölümüne sağ tıklayıp add project reference diyerek açılan pencereden ilgili katmanı (UrunSatisSitesi.Entities gibi) yandaki chech e tık koyarak kaydet deyip işlemi tamamlayabiliriz. veya aşağıda yaptığımız gibi AppUser db set ini yazıp çıkan ampülden add project reference menüsüne tıklayıp bu işlemi otomotik yapılmasını sağlayabiliriz. *Bu noktada dikkat etmemiz gereken nokta yazım yanlışı yapmamak! visual studio bulamayabilir yanlış yazarsak.
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        // db setleri oluşturduktan sonra aşağıdaki metodu override yazıp bir boşluk bırakıp on yazıp gelen seçeneklerden OnConfiguring i seçip entera basarak oluşturuyoruz.   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // burada optionsbuilder ı kullanarak aql server ayarlarımızı belirleyebiliyoruz.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=UrunSatisSitesi; trusted_connection=true;"
);// Bu metod ile sql server kullanacağımızı belirttik.
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentAPI: Data annotations taki tablo  ve property özelliklerini yapılandırabiliceğimiz bir diğer yöntemdir.
            modelBuilder.Entity<AppUser>().Property(a=>a.Name)//entitilerimizden appuser ın propertylerinden name alanı için 
                
                .IsRequired()//Bu propertyi zorunlu alan yap
                .HasColumnType("varchar(50)")// name alanının sql deki kolon tipi varchar(50) olsun.
                .HasMaxLength(50)//Kolon karakter uzunluğu 
                ;
            modelBuilder.Entity<AppUser>().Property(s => s.Surname).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(s => s.Email).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(p => p.Phone).HasColumnType("varchar(15)");
            modelBuilder.Entity<AppUser>().Property(un => un.Username).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<AppUser>().Property(p => p.Password).HasColumnType("nvarchar(15)").HasMaxLength(50).IsRequired();
            //FluentAPI ile veritabanımızı oluşturduktan sonra ilk kaydı ekleme işlemi yapıyoruz.
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id= 1,
                    Username="Admin",
                    Password="123",
                    Email="admin@urunsatissitesi.com",
                    IsActive=true,
                    IsAdmin=true,
                    Name="Admin",
                    Surname="Administrator"
                });


            base.OnModelCreating(modelBuilder);
        }

    }
}
