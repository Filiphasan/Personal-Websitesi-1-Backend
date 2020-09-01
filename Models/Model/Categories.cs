using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Kategori")]
        [Required,MaxLength(60,ErrorMessage ="Kategori Adı en fazla 60 karakte olabilir!")]
        public string CategoryName { get; set; }

        [DisplayName("Kategori Fontawesome")]
        [Required,MaxLength(100,ErrorMessage ="Kategori Fontawesome alanı en fazla 100 karakter olabilir!")]
        public string CategoryFA { get; set; }

        [DefaultValue(true)]
        public bool State { get; set; }

        public ICollection<Blogs> Blogs { get; set; }
    }
}