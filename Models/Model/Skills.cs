using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("Skills")]
    public class Skills
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Yetenek")]
        [Required,StringLength(50,ErrorMessage ="Yetenek Alanı en fazla 50 karakter olabilir!")]
        public string Skill { get; set; }

        [DisplayName("Yetenek Yüzdelik Değer")]
        [Required,Range(0,100,ErrorMessage = "Yetenek Yüzde Değeri 0 ile 100 arasında olmalıdır!")]
        public byte PercentageValue { get; set; }
    }
}