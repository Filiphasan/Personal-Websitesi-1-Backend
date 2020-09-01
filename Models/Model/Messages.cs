using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("Messages")]
    public class Messages
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("İsim")]
        [Required,StringLength(25,ErrorMessage ="İsim Alanı en fazla 25 karakter olabilir!")]
        public string Name { get; set; }

        [DisplayName("Soyisim")]
        [Required,StringLength(25,ErrorMessage ="Soyisim alanı en fazla 25 karakter olabilir!")]
        public string Surname { get; set; }

        [DisplayName("Mail Adresi")]
        [Required,StringLength(150,ErrorMessage ="Mail alanı en fazla 150 karakter olabilir!")]
        public string Mail { get; set; }

        [DisplayName("Konu")]
        [Required,StringLength(50,ErrorMessage ="Konu en fazla 50 karakter olabilir!")]
        public string Subject { get; set; }

        [DisplayName("Mesaj")]
        [Required,StringLength(1000,ErrorMessage ="Mesaj en fazla 1000 karakter olabilir!")]
        public string Message { get; set; }

        [DisplayName("Okunma Durumu")]
        [DefaultValue(false)]
        public bool Durum { get; set; }

    }
}