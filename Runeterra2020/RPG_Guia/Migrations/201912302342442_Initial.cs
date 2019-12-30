namespace RPG_Guia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EscalaRunicas",
                c => new
                    {
                        EscalaRunicaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.EscalaRunicaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.RunaFichas",
                c => new
                    {
                        Runa_RunaId = c.Int(nullable: false),
                        Ficha_FichaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Runa_RunaId, t.Ficha_FichaId })
                .ForeignKey("dbo.Runas", t => t.Runa_RunaId, cascadeDelete: true)
                .ForeignKey("dbo.Fichas", t => t.Ficha_FichaId, cascadeDelete: true)
                .Index(t => t.Runa_RunaId)
                .Index(t => t.Ficha_FichaId);
            
            AddColumn("dbo.Fichas", "Nome", c => c.String());
            AddColumn("dbo.Fichas", "Personalidade", c => c.String());
            AddColumn("dbo.Fichas", "Ideal", c => c.String());
            AddColumn("dbo.Fichas", "Vinculo", c => c.String());
            AddColumn("dbo.Fichas", "Fraqueza", c => c.String());
            AddColumn("dbo.Fichas", "Caracteristica", c => c.String());
            AddColumn("dbo.Fichas", "Força", c => c.Int(nullable: false));
            AddColumn("dbo.Fichas", "Inteligencia", c => c.Int(nullable: false));
            AddColumn("dbo.Fichas", "Sabedoria", c => c.Int(nullable: false));
            AddColumn("dbo.Fichas", "Destreza", c => c.Int(nullable: false));
            AddColumn("dbo.Fichas", "Constituição", c => c.Int(nullable: false));
            AddColumn("dbo.Fichas", "Carisma", c => c.Int(nullable: false));
            AddColumn("dbo.Fichas", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Runas", "EscalaRunicaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fichas", "UsuarioId");
            CreateIndex("dbo.Runas", "EscalaRunicaId");
            AddForeignKey("dbo.Runas", "EscalaRunicaId", "dbo.EscalaRunicas", "EscalaRunicaId", cascadeDelete: true);
            AddForeignKey("dbo.Fichas", "UsuarioId", "dbo.Usuarios", "UsuarioId", cascadeDelete: true);
            DropColumn("dbo.Fichas", "Nome_Jogador");
            DropColumn("dbo.Fichas", "Nome_Personagem");
            DropTable("dbo.PulsoRunicoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PulsoRunicoes",
                c => new
                    {
                        PulsoRunicoId = c.Int(nullable: false, identity: true),
                        Descriçao = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.PulsoRunicoId);
            
            AddColumn("dbo.Fichas", "Nome_Personagem", c => c.String());
            AddColumn("dbo.Fichas", "Nome_Jogador", c => c.String());
            DropForeignKey("dbo.Fichas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.RunaFichas", "Ficha_FichaId", "dbo.Fichas");
            DropForeignKey("dbo.RunaFichas", "Runa_RunaId", "dbo.Runas");
            DropForeignKey("dbo.Runas", "EscalaRunicaId", "dbo.EscalaRunicas");
            DropIndex("dbo.RunaFichas", new[] { "Ficha_FichaId" });
            DropIndex("dbo.RunaFichas", new[] { "Runa_RunaId" });
            DropIndex("dbo.Runas", new[] { "EscalaRunicaId" });
            DropIndex("dbo.Fichas", new[] { "UsuarioId" });
            DropColumn("dbo.Runas", "EscalaRunicaId");
            DropColumn("dbo.Fichas", "UsuarioId");
            DropColumn("dbo.Fichas", "Carisma");
            DropColumn("dbo.Fichas", "Constituição");
            DropColumn("dbo.Fichas", "Destreza");
            DropColumn("dbo.Fichas", "Sabedoria");
            DropColumn("dbo.Fichas", "Inteligencia");
            DropColumn("dbo.Fichas", "Força");
            DropColumn("dbo.Fichas", "Caracteristica");
            DropColumn("dbo.Fichas", "Fraqueza");
            DropColumn("dbo.Fichas", "Vinculo");
            DropColumn("dbo.Fichas", "Ideal");
            DropColumn("dbo.Fichas", "Personalidade");
            DropColumn("dbo.Fichas", "Nome");
            DropTable("dbo.RunaFichas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.EscalaRunicas");
        }
    }
}
