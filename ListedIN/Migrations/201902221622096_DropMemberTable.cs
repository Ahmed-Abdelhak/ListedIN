namespace ListedIN.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DropMemberTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Members");
        }
        
        public override void Down()
        {
        }
    }
}
