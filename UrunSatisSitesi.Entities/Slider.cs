using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunSatisSitesi.Entities
{
    public class Slider:IEntitiy
    {
        public int Id { get; set; }


        [Display(Name = "Adı")]
        public string Title { get; set; }


        [Display(Name = "Açıklama"), DataType(DataType.MultilineText)]
        public string? Description { get; set; }


        [Display(Name = "Resim")]
        public string? Image { get; set; }



        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }

        public string? Link { get; set; }
    }
}
