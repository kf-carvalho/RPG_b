namespace RPG_Guia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClasseId = c.Int(nullable: false, identity: true),
                        Descriçao = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ClasseId);
            
            CreateTable(
                "dbo.Fichas",
                c => new
                    {
                        FichaId = c.Int(nullable: false, identity: true),
                        Nome_Jogador = c.String(),
                        Nome_Personagem = c.String(),
                        Antepassado = c.String(),
                        Tendencia = c.String(),
                        TerritorioId = c.Int(nullable: false),
                        RaçaId = c.Int(nullable: false),
                        ClasseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FichaId)
                .ForeignKey("dbo.Classes", t => t.ClasseId, cascadeDelete: true)
                .ForeignKey("dbo.Raça", t => t.RaçaId, cascadeDelete: true)
                .ForeignKey("dbo.Territorios", t => t.TerritorioId, cascadeDelete: true)
                .Index(t => t.TerritorioId)
                .Index(t => t.RaçaId)
                .Index(t => t.ClasseId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Descriçao = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Pericias",
                c => new
                    {
                        PericiaId = c.Int(nullable: false, identity: true),
                        Modificador = c.Int(nullable: false),
                        Mastery = c.String(),
                        Proeficiencia = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PericiaId);
            
            CreateTable(
                "dbo.Raça",
                c => new
                    {
                        RaçaId = c.Int(nullable: false, identity: true),
                        Descriçao = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.RaçaId);
            
            CreateTable(
                "dbo.Territorios",
                c => new
                    {
                        TerritorioId = c.Int(nullable: false, identity: true),
                        Descriçao = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.TerritorioId);
            
            CreateTable(
                "dbo.PulsoRunicoes",
                c => new
                    {
                        PulsoRunicoId = c.Int(nullable: false, identity: true),
                        Descriçao = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.PulsoRunicoId);
            
            CreateTable(
                "dbo.Runas",
                c => new
                    {
                        RunaId = c.Int(nullable: false, identity: true),
                        Descriçao = c.String(),
                        Nivel = c.String(),
                        Nome = c.String(),
                        Alcance = c.String(),
                        Cura = c.String(),
                        Duracao = c.String(),
                        Dano = c.String(),
                        Uso = c.String(),
                    })
                .PrimaryKey(t => t.RunaId);
            
            CreateTable(
                "dbo.ItemFichas",
                c => new
                    {
                        Item_ItemId = c.Int(nullable: false),
                        Ficha_FichaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_ItemId, t.Ficha_FichaId })
                .ForeignKey("dbo.Items", t => t.Item_ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Fichas", t => t.Ficha_FichaId, cascadeDelete: true)
                .Index(t => t.Item_ItemId)
                .Index(t => t.Ficha_FichaId);
            
            CreateTable(
                "dbo.PericiaFichas",
                c => new
                    {
                        Pericia_PericiaId = c.Int(nullable: false),
                        Ficha_FichaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pericia_PericiaId, t.Ficha_FichaId })
                .ForeignKey("dbo.Pericias", t => t.Pericia_PericiaId, cascadeDelete: true)
                .ForeignKey("dbo.Fichas", t => t.Ficha_FichaId, cascadeDelete: true)
                .Index(t => t.Pericia_PericiaId)
                .Index(t => t.Ficha_FichaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fichas", "TerritorioId", "dbo.Territorios");
            DropForeignKey("dbo.Fichas", "RaçaId", "dbo.Raça");
            DropForeignKey("dbo.PericiaFichas", "Ficha_FichaId", "dbo.Fichas");
            DropForeignKey("dbo.PericiaFichas", "Pericia_PericiaId", "dbo.Pericias");
            DropForeignKey("dbo.ItemFichas", "Ficha_FichaId", "dbo.Fichas");
            DropForeignKey("dbo.ItemFichas", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.Fichas", "ClasseId", "dbo.Classes");
            DropIndex("dbo.PericiaFichas", new[] { "Ficha_FichaId" });
            DropIndex("dbo.PericiaFichas", new[] { "Pericia_PericiaId" });
            DropIndex("dbo.ItemFichas", new[] { "Ficha_FichaId" });
            DropIndex("dbo.ItemFichas", new[] { "Item_ItemId" });
            DropIndex("dbo.Fichas", new[] { "ClasseId" });
            DropIndex("dbo.Fichas", new[] { "RaçaId" });
            DropIndex("dbo.Fichas", new[] { "TerritorioId" });
            DropTable("dbo.PericiaFichas");
            DropTable("dbo.ItemFichas");
            DropTable("dbo.Runas");
            DropTable("dbo.PulsoRunicoes");
            DropTable("dbo.Territorios");
            DropTable("dbo.Raça");
            DropTable("dbo.Pericias");
            DropTable("dbo.Items");
            DropTable("dbo.Fichas");
            DropTable("dbo.Classes");
        }
    }
}
