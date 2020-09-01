using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("Interesteds")]
    public class Interesteds
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("İlgi Alanı")]
        [Required,StringLength(500,ErrorMessage ="İlgi Alanı en fazla 500 karakter olabilir!")]
        public string Interested { get; set; }
    }
}