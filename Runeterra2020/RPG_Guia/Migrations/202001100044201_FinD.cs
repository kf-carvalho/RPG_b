namespace RPG_Guia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armaduras",
                c => new
                    {
                        ArmaduraId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Categoria = c.String(),
                        ClasseArmadura = c.String(),
                        Força = c.String(),
                        Furtividade = c.String(),
                        Peso = c.String(),
                    })
                .PrimaryKey(t => t.ArmaduraId);
            
            CreateTable(
                "dbo.Armas",
                c => new
                    {
                        ArmaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Categoria = c.String(),
                        Preço = c.String(),
                        Peso = c.String(),
                        Dano = c.String(),
                        Propriedades = c.String(),
                    })
                .PrimaryKey(t => t.ArmaId);
            
            CreateTable(
                "dbo.FichaArmaduras",
                c => new
                    {
                        Ficha_FichaId = c.Int(nullable: false),
                        Armadura_ArmaduraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ficha_FichaId, t.Armadura_ArmaduraId })
                .ForeignKey("dbo.Fichas", t => t.Ficha_FichaId, cascadeDelete: true)
                .ForeignKey("dbo.Armaduras", t => t.Armadura_ArmaduraId, cascadeDelete: true)
                .Index(t => t.Ficha_FichaId)
                .Index(t => t.Armadura_ArmaduraId);
            
            CreateTable(
                "dbo.ArmaFichas",
                c => new
                    {
                        Arma_ArmaId = c.Int(nullable: false),
                        Ficha_FichaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Arma_ArmaId, t.Ficha_FichaId })
                .ForeignKey("dbo.Armas", t => t.Arma_ArmaId, cascadeDelete: true)
                .ForeignKey("dbo.Fichas", t => t.Ficha_FichaId, cascadeDelete: true)
                .Index(t => t.Arma_ArmaId)
                .Index(t => t.Ficha_FichaId);
            
            AddColumn("dbo.Items", "Custo", c => c.String());
            AddColumn("dbo.Items", "Peso", c => c.String());
            DropColumn("dbo.Items", "Descriçao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Descriçao", c => c.String());
            DropForeignKey("dbo.ArmaFichas", "Ficha_FichaId", "dbo.Fichas");
            DropForeignKey("dbo.ArmaFichas", "Arma_ArmaId", "dbo.Armas");
            DropForeignKey("dbo.FichaArmaduras", "Armadura_ArmaduraId", "dbo.Armaduras");
            DropForeignKey("dbo.FichaArmaduras", "Ficha_FichaId", "dbo.Fichas");
            DropIndex("dbo.ArmaFichas", new[] { "Ficha_FichaId" });
            DropIndex("dbo.ArmaFichas", new[] { "Arma_ArmaId" });
            DropIndex("dbo.FichaArmaduras", new[] { "Armadura_ArmaduraId" });
            DropIndex("dbo.FichaArmaduras", new[] { "Ficha_FichaId" });
            DropColumn("dbo.Items", "Peso");
            DropColumn("dbo.Items", "Custo");
            DropTable("dbo.ArmaFichas");
            DropTable("dbo.FichaArmaduras");
            DropTable("dbo.Armas");
            DropTable("dbo.Armaduras");
        }
    }
}
