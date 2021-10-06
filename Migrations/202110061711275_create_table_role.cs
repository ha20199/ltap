namespace ltap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountModels",
                c => new
                    {
                        UseName = c.String(nullable: false, maxLength: 128),
                        PassWord = c.String(nullable: false),
                        RoleID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.UseName);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.String(nullable: false, maxLength: 128),
                        Author = c.String(),
                        Articlecontent = c.String(),
                    })
                .PrimaryKey(t => t.ArticleID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.String(nullable: false, maxLength: 128),
                        PersonName = c.String(),
                        Company = c.String(),
                        Address = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10, unicode: false),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        StudentName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
            DropTable("dbo.Roles");
            DropTable("dbo.People");
            DropTable("dbo.Articles");
            DropTable("dbo.AccountModels");
        }
    }
}
