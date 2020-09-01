using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MyWebsite.Models.Model
{
    [Table("HomePageSlider")]
    public class HomePageSlider
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Anasayfa Slider Başlığı")]
        [Required,StringLength(30,ErrorMessage ="Slider Başlığı 30 Karakterden Fazla Olamaz!")]
        public string SliderTitle { get; set; }

        [DisplayName("Anasayfa Slider Açıklaması")]
        [Required,MinLength(400,ErrorMessage ="Açıklama alanı en az 400 karakter olmalıdır!")]
        public string SliderDescription { get; set; }
    }
}