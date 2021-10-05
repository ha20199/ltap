namespace ltap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Person : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Usename = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Usename);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.String(nullable: false, maxLength: 128),
                        PersonName = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            DropTable("dbo.SinhViens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        MaSinhVien = c.String(nullable: false, maxLength: 128),
                        TenSinhVien = c.String(),
                    })
                .PrimaryKey(t => t.MaSinhVien);
            
            DropTable("dbo.People");
            DropTable("dbo.Account");
        }
    }
}
