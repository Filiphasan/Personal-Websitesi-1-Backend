using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("ContactInfo")]
    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required,StringLength(20,ErrorMessage ="Lütfen girdiğiniz değerleri kontrol ediniz!")]
        public string PhoneNumber { get; set; }

        [DisplayName("Mail Adresi")]
        [Required,StringLength(150,ErrorMessage ="Mail Alanı en fazla 150 karakter olabilir!")]
        public string Mail { get; set; }

        [DisplayName("Uzun Adres")]
        [Required,StringLength(500,ErrorMessage ="Uzun Adres Alanı 500 Karakterden fazla olamaz!")]
        public string LongAdress { get; set; }

        [DisplayName("Kısa Adres")]
        [Required, StringLength(30, ErrorMessage = "Kısa Adres Alanı en fazla 30 karakter olabilir!")]
        public string ShortAdress { get; set; }
    }
}