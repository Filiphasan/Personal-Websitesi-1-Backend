using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Ad")]
        [Required,MaxLength(25,ErrorMessage = "İsim alanı en fazla 25 karakter olabilir!")]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        [Required, MaxLength(25,ErrorMessage ="Soyisim alanı en fazla 25 karakter olabilir!")]
        public string Surname { get; set; }

        [DisplayName("Mail")]
        [Required, MaxLength(200,ErrorMessage ="Mail alanı en fazla 200 karakter olabilir!")]
        public string Mail { get; set; }

        [DisplayName("Yorum")]
        [Required, MaxLength(400,ErrorMessage ="Yorum alanı en fazla 400 karakter olabilir!"), MinLength(20, ErrorMessage = "Yorum alanı en az 20 karakter olmalıdır!")]
        public string Comment { get; set; }

        [DefaultValue(false)]
        public bool State { get; set; }

        [DisplayName("Blog")]
        public int? BlogId { get; set; }
        public Blogs Blogs { get; set; }
    }
}