using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("SiteIdentity")]
    public class SiteIdentity
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Site Başlık")]
        [Required,StringLength(50,ErrorMessage ="Site Başlığı 50 Karakterden fazla olmamalıdır!")]
        public string Title { get; set; }

        [DisplayName("Site Anahtar Kelimeler")]
        [Required,StringLength(260,ErrorMessage ="Site Keywords Alanı 260 Karakterden kısa olmalıdır!")]
        public string Keywords { get; set; }

        [DisplayName("Site Açıklaması")]
        [Required,StringLength(160,ErrorMessage ="Site Description Alanı 160 Karakterden az olmalıdır!")]
        public string Description { get; set; }

        [DisplayName("Site Logo Font Awesome")]
        [Required]
        public string LogoFA { get; set; }

        [DisplayName("Site Logo Başlık")]
        [Required,StringLength(40,ErrorMessage ="Site Logo Başlığı 40 Karakterden az olmalıdır!")]
        public string LogoTitle { get; set; }
    }
}