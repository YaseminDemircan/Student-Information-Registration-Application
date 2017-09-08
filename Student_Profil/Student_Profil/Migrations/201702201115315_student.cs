namespace Student_Profil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Birthday = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Email = c.String(),
                        Adres = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
