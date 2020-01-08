namespace RPG_Guia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Normaliza : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fichas", "ClasseArmadura", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fichas", "ClasseArmadura");
        }
    }
}
