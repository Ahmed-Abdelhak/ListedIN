namespace ListedIN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EducationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Degree = c.String(),
                        Field = c.String(),
                        Grade = c.String(),
                        FromYear = c.DateTime(),
                        ToYear = c.DateTime(),
                        Description = c.String(),
                        fk_User = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.fk_User)
                .Index(t => t.fk_User);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "fk_User", "dbo.AspNetUsers");
            DropIndex("dbo.Educations", new[] { "fk_User" });
            DropTable("dbo.Educations");
        }
    }
}
