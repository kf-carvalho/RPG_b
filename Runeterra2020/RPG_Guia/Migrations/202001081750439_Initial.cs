namespace RPG_Guia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Raça", "Traços", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Raça", "Traços");
        }
    }
}
