using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunSatisSitesi.Entities
{
    public class Category : IEntitiy
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Name { get; set; }

        [Display(Name = "Açıklama"),DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }

        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }

        [Display(Name = "Üst Menü?")]
        public bool IsTopMennu { get; set; }

        [Display(Name = "Üst Kategori")]
        public int ParentId { get; set; }

        [Display(Name = "Sıra No")]
        public int OrderNo { get; set; }


        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]//ScaffoldColumn False sayfa oluştururken ekranda bu alan oluşmasın diye 
        public DateTime CreateDate { get; set; }=DateTime.Now;

        public ICollection<Product> Products { get; set; }// 1 kategorinin 1 den çok ürünü olabilir.(bire çok ilişki).

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
