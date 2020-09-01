using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("BlogImages")]
    public class BlogImages
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Blog Resim")]
        [Required,MaxLength(250,ErrorMessage ="Resim yolu en fazla 250 karakter olabilir!")]
        public string ImagePath { get; set; }

        [DisplayName("Blog")]
        public int? BlogId { get; set; }
        public Blogs Blogs { get; set; }

        public bool State { get; set; }
    }
}