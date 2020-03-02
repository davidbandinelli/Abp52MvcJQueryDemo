namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_tipi_contatto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PbPersons", "TelephoneNumber", c => c.String());
            AddColumn("dbo.PbPersons", "TipoContatto", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PbPersons", "TipoContatto");
            DropColumn("dbo.PbPersons", "TelephoneNumber");
        }
    }
}
