using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunSatisSitesi.Entities
{
    public class Contact:IEntitiy
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Name { get; set; }

        [Display(Name = "Soyad"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "{0} Boş Geçilemez!"), EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), DataType(DataType.MultilineText), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Message { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]//ScaffoldColumn False sayfa oluştururken ekranda bu alan oluşmasın diye 
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
