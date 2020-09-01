using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Model
{
    [Table("SocialMediaAccount")]
    public class SocialMediaAccount
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Facebook Link")]
        [StringLength(250,ErrorMessage ="Facebook Linki 250 Karakterden fazla olamaz!")]
        public string Facebook { get; set; }

        [DisplayName("Twitter Link")]
        [StringLength(250, ErrorMessage = "Twitter Linki 250 Karakterden fazla olamaz!")]
        public string Twitter { get; set; }

        [DisplayName("Linkedin Link")]
        [StringLength(250, ErrorMessage = "Linkedin Linki 250 Karakterden fazla olamaz!")]
        public string Linkedin { get; set; }

        [DisplayName("Github Link")]
        [StringLength(250, ErrorMessage = "Github Linki 250 Karakterden fazla olamaz!")]
        public string Github { get; set; }

        [DisplayName("Youtube Link")]
        [StringLength(250, ErrorMessage = "Youtube Linki 250 Karakterden fazla olamaz!")]
        public string Youtube { get; set; }
    }
}