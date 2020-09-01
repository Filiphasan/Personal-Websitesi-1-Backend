using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("Educations")]
    public class Educations
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Eğitim")]
        [Required,StringLength(50,ErrorMessage ="Eğitim Alanı en fazla 50 karakter olabilir!")]
        public string Education { get; set; }

        [DisplayName("Okul")]
        [Required,StringLength(100,ErrorMessage ="Okul alanı en fazla 100 karakter olabilir!")]
        public string School { get; set; }

        [DisplayName("Eğitim Süresi")]
        [Required,StringLength(50,ErrorMessage ="Eğitim süresi alanı en fazla 50 karakter olabilir!")]
        public string Duration { get; set; }

        [DisplayName("Okul Ortalaması")]
        [Required,StringLength(10,ErrorMessage ="Okul ortalaması alanı en fazla 10 karakter olabilir!")]
        public string Avarage { get; set; }

        [DisplayName("Açıklama")]
        [Required,MinLength(40,ErrorMessage ="Eğitim Açıklaması en az 40 karakter olmalıdır!")]
        public string Description { get; set; }
    }
}