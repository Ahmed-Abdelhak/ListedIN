namespace ListedIN.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EditTypeOfColumnYearInEducationTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                     ALTER TABLE Educations DROP COLUMN FromYear
");
            Sql(@"
                     ALTER TABLE Educations DROP COLUMN ToYear
");
            AddColumn("dbo.Educations", "FromYear", c => c.Short());
            AddColumn("dbo.Educations", "ToYear", c => c.Short());
            

            Sql(@"

                   INSERT INTO  Educations (Name,Degree,Field,Grade,Description,fk_User,FromYear,ToYear) VALUES ('Suez Canal','Bachelor','Engineering','3.14','Bachelor Degree from SCU','7ac13782-7598-43d7-9a01-06f4f025c8f6','2011','2016')

");
        }

        public override void Down()
        {
            Sql(@"
                     ALTER TABLE Educations DROP COLUMN FromYear
");
            Sql(@"
                     ALTER TABLE Educations DROP COLUMN ToYear
");
        }
    }
}
