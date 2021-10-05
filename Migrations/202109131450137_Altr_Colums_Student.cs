namespace ltap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Altr_Colums_Student : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "StudentName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "StudentName", c => c.String());
            DropColumn("dbo.Student", "Address");
        }
    }
}
