namespace ListedIN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserSkillsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillApplicationUsers",
                c => new
                    {
                        Skill_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Skill_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Skills", t => t.Skill_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Skill_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SkillApplicationUsers", "Skill_Id", "dbo.Skills");
            DropIndex("dbo.SkillApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SkillApplicationUsers", new[] { "Skill_Id" });
            DropTable("dbo.SkillApplicationUsers");
        }
    }
}
