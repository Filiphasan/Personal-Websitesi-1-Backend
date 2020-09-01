using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("About")]
    public class About
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("İsim")]
        [Required,StringLength(20,ErrorMessage ="İsim alanı en fazla 20 karakter olabilir!")]
        public string Name { get; set; }

        [DisplayName("Soyisim")]
        [Required,StringLength(20,ErrorMessage ="Soyisim alanı en fazla 20 karakter olabilir!")]
        public string Surname { get; set; }

        [DisplayName("Profil Resmi")]
        [StringLength(200,ErrorMessage ="Resim Yolu en fazla 200 karakter olabilir!")]
        public string ResimUrl { get; set; }

        [DisplayName("Meslek Font Awesome")]
        [Required, StringLength(100, ErrorMessage = "Meslek Logo Alanı en fazla 100 karakter olabilir!")]
        public string MyJobFA { get; set; }

        [DisplayName("Meslek")]
        [Required,StringLength(50,ErrorMessage ="Meslek Alanı en fazla 50 karakter olabilir!")]
        public string MyJob { get; set; }

        [DisplayName("Doğum Tarihi")]
        [Required]
        public DateTime BirthDate { get; set; }

        [DisplayName("Özgeçmiş Dosyası")]
        public string MyCV { get; set; }
    }
}