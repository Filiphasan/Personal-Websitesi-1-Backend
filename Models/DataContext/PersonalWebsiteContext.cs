using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyWebsite.Models.Model;

namespace MyWebsite.Models.DataContext
{
    public class PersonalWebsiteContext: DbContext
    {
        public PersonalWebsiteContext() 
            : base("MyWebsiteDBNew")
        {
        }
        public DbSet<About> About { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BlogImages> BlogImages { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Educations> Educations { get; set; }
        public DbSet<Experiences> Experiences { get; set; }
        public DbSet<HomePageSlider> HomePageSlider { get; set; }
        public DbSet<Interesteds> Interesteds { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<SiteIdentity> SiteIdentity { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccount { get; set; }
        public DbSet<Summary> Summary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogs>()
            .HasRequired<Categories>(s => s.Categories)
            .WithMany(g => g.Blogs)
            .HasForeignKey<int>(s => (int)s.CategoryId);

            modelBuilder.Entity<BlogImages>()
            .HasRequired<Blogs>(s => s.Blogs)
            .WithMany(g => g.BlogImages)
            .HasForeignKey<int>(s => (int)s.BlogId);

            modelBuilder.Entity<Comments>()
            .HasRequired<Blogs>(s => s.Blogs)
            .WithMany(g => g.Comments)
            .HasForeignKey<int>(s => (int)s.BlogId);
        }
    }
}