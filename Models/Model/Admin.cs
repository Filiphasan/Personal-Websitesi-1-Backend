using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models.Model
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Yönetici E-Posta Adresi")]
        [Required, StringLength(200, ErrorMessage = "E-posta Alanı 200 karakterden az olmalıdır!")]
        public string Eposta { get; set; }

        [DisplayName("Yönetici Şifresi")]
        [Required, StringLength(160, ErrorMessage = "Password Alanı 20 karakterden az olmalıdır!")]
        public string Password { get; set; }

        [DisplayName("Güvenlik Sorusu?")]
        [Required, StringLength(480, ErrorMessage = "Güvenlik Sorusu 60 Karakterden kısa olmalıdır!")]
        public string SecurityQuestion { get; set; }

        [DisplayName("Güvenlik Sorusu Cevabı")]
        [Required, StringLength(240, ErrorMessage = "Güvenlik Sorusunun Cevabı 30 Karakterden kısa olmalıdır!")]
        public string SQAnswer { get; set; }
    }
}