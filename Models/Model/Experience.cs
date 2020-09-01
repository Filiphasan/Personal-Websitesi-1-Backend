using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("Experiences")]
    public class Experiences
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Deneyim")]
        [Required,StringLength(50,ErrorMessage ="Yetenek ismi en fazla 50 karakter olabilir!")]
        public string Experience { get; set; }

        [DisplayName("Çalışma Yeri")]
        [Required,StringLength(100,ErrorMessage ="Deneyim İşyeri en fazla 100 karakter olabilir!")]
        public string Workplace { get; set; }

        [DisplayName("Çalışma Süresi")]
        [Required,StringLength(100,ErrorMessage ="Deneyim Süresi Alanı en fazla 100 karakter olabilir!")]
        public string Duration { get; set; }

        [DisplayName("Deneyim Açıklaması")]
        [Required,StringLength(300,ErrorMessage ="Deneyim Açıklaması en fazla 300 karakter olabilir!"),MinLength(40,ErrorMessage ="Deneyim Açıklaması en az 40 karakter olmalıdır!")]
        public string Description { get; set; }
    }
}