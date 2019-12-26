namespace RPG_Guia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fichas",
                c => new
                    {
                        FichaId = c.Int(nullable: false, identity: true),
                        Nome_Jogador = c.String(),
                        Nome_Personagem = c.String(),
                        Raça = c.String(),
                        Classe = c.String(),
                        Antepassado = c.String(),
                        Alinhamento = c.String(),
                        TerritorioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FichaId)
                .ForeignKey("dbo.Territorios", t => t.TerritorioId, cascadeDelete: true)
                .Index(t => t.TerritorioId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ficha_FichaId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Fichas", t => t.Ficha_FichaId)
                .Index(t => t.Ficha_FichaId);
            
            CreateTable(
                "dbo.Pericias",
                c => new
                    {
                        PericiaId = c.Int(nullable: false, identity: true),
                        Modificador = c.Int(nullable: false),
                        Mastery = c.String(),
                        Proeficiencia = c.Boolean(nullable: false),
                        Ficha_FichaId = c.Int(),
                    })
                .PrimaryKey(t => t.PericiaId)
                .ForeignKey("dbo.Fichas", t => t.Ficha_FichaId)
                .Index(t => t.Ficha_FichaId);
            
            CreateTable(
                "dbo.Territorios",
                c => new
                    {
                        TerritorioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.TerritorioId);
            
            CreateTable(
                "dbo.PulsoRunicoes",
                c => new
                    {
                        PulsoRunicoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.PulsoRunicoId);
            
            CreateTable(
                "dbo.Runas",
                c => new
                    {
                        RunaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Nivel = c.String(),
                        Alcance = c.String(),
                        Cura = c.String(),
                        Duracao = c.String(),
                        Dano = c.String(),
                        Uso = c.String(),
                    })
                .PrimaryKey(t => t.RunaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fichas", "TerritorioId", "dbo.Territorios");
            DropForeignKey("dbo.Pericias", "Ficha_FichaId", "dbo.Fichas");
            DropForeignKey("dbo.Items", "Ficha_FichaId", "dbo.Fichas");
            DropIndex("dbo.Pericias", new[] { "Ficha_FichaId" });
            DropIndex("dbo.Items", new[] { "Ficha_FichaId" });
            DropIndex("dbo.Fichas", new[] { "TerritorioId" });
            DropTable("dbo.Runas");
            DropTable("dbo.PulsoRunicoes");
            DropTable("dbo.Territorios");
            DropTable("dbo.Pericias");
            DropTable("dbo.Items");
            DropTable("dbo.Fichas");
        }
    }
}
