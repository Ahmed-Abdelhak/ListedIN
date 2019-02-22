namespace ListedIN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
             
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        HeadLine = c.String(),
                        Position = c.String(),
                        Country = c.Int(nullable: false),
                        Summary = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
