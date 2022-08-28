using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunSatisSitesi.Entities
{
    public class Brand : IEntitiy
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]

        public string? Description { get; set; }

        public string? Logo { get; set; }

        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]//ScaffoldColumn False sayfa oluştururken ekranda bu alan oluşmasın diye 
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public ICollection<Product> Products { get; set; }// Brand İle Product arasına bire çok ilişki kurduk.
        public Brand()
        {
            Products = new List<Product>();
        }
    }
}
