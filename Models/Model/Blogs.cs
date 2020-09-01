using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("Blogs")]
    public class Blogs
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Blog Başlık")]
        [Required,MaxLength(50,ErrorMessage ="Blog Başlık Alanı en fazla 50 karakter olabilir!")]
        public string Title { get; set; }

        [Required,DisplayName("Blog Açıklama"),MinLength(100,ErrorMessage ="Blog açıklaması en az 100 karakter olmalıdır!")]
        public string Description { get; set; }

        [DisplayName("Kategori")]
        public int? CategoryId { get; set; }
        public Categories Categories { get; set; }

        [DefaultValue(0)]
        [DisplayName("Okunma Sayısı")]
        public int ReadCount { get; set; }

        public bool State { get; set; }

        public ICollection<BlogImages> BlogImages { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}