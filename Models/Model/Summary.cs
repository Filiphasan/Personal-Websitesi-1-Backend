using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("Summary")]
    public class Summary
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Özet")]
        [Required,MinLength(100,ErrorMessage = "Özet alanı en az 100 karakter olabilir!")]
        public string Description { get; set; }
    }
}