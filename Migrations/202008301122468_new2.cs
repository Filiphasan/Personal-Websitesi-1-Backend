namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogImages", "Blogs_Id", "dbo.Blogs");
            DropForeignKey("dbo.Comments", "Blogs_Id", "dbo.Blogs");
            DropIndex("dbo.BlogImages", new[] { "Blogs_Id" });
            DropIndex("dbo.Comments", new[] { "Blogs_Id" });
            DropColumn("dbo.BlogImages", "BlogId");
            DropColumn("dbo.Comments", "BlogId");
            RenameColumn(table: "dbo.BlogImages", name: "Blogs_Id", newName: "BlogId");
            RenameColumn(table: "dbo.Comments", name: "Blogs_Id", newName: "BlogId");
            AlterColumn("dbo.BlogImages", "BlogId", c => c.Int(nullable: false));
            AlterColumn("dbo.BlogImages", "BlogId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "BlogId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "BlogId", c => c.Int(nullable: false));
            CreateIndex("dbo.BlogImages", "BlogId");
            CreateIndex("dbo.Comments", "BlogId");
            AddForeignKey("dbo.BlogImages", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogImages", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropIndex("dbo.BlogImages", new[] { "BlogId" });
            AlterColumn("dbo.Comments", "BlogId", c => c.Int());
            AlterColumn("dbo.Comments", "BlogId", c => c.Int());
            AlterColumn("dbo.BlogImages", "BlogId", c => c.Int());
            AlterColumn("dbo.BlogImages", "BlogId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "BlogId", newName: "Blogs_Id");
            RenameColumn(table: "dbo.BlogImages", name: "BlogId", newName: "Blogs_Id");
            AddColumn("dbo.Comments", "BlogId", c => c.Int());
            AddColumn("dbo.BlogImages", "BlogId", c => c.Int());
            CreateIndex("dbo.Comments", "Blogs_Id");
            CreateIndex("dbo.BlogImages", "Blogs_Id");
            AddForeignKey("dbo.Comments", "Blogs_Id", "dbo.Blogs", "Id");
            AddForeignKey("dbo.BlogImages", "Blogs_Id", "dbo.Blogs", "Id");
        }
    }
}
