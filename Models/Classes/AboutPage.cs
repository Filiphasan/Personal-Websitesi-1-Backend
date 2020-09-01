using MyWebsite.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Classes
{
    public class AboutPage
    {
        public About Abouts { get; set; }
        public IEnumerable<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public IEnumerable<ContactInfo> ContactInfos { get; set; }
        public IEnumerable<Summary> Summaries { get; set; }
        public IEnumerable<Skills> Skills { get; set; }
        public IEnumerable<Experiences> Experiences { get; set; }
        public IEnumerable<Educations> Educations { get; set; }
        public IEnumerable<Interesteds> Interesteds { get; set; }
    }
}