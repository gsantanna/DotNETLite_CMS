namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Socios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConteudoEquipe",
                c => new
                    {
                        id_conteudoequipe = c.Int(nullable: false, identity: true),
                        Chamada = c.String(maxLength: 100, unicode: false),
                        Cargo = c.String(maxLength: 100, unicode: false),
                        AreasAtuacao = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        id_linguagem = c.Int(nullable: false),
                        id_equipe = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_conteudoequipe)
                .ForeignKey("dbo.Equipe", t => t.id_equipe)
                .ForeignKey("dbo.tb_linguagem", t => t.id_linguagem)
                .Index(t => t.id_linguagem)
                .Index(t => t.id_equipe);
            
            CreateTable(
                "dbo.Equipe",
                c => new
                    {
                        id_equipe = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                        FotoPopup = c.String(maxLength: 100, unicode: false),
                        FotoDestaque = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id_equipe);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConteudoEquipe", "id_linguagem", "dbo.tb_linguagem");
            DropForeignKey("dbo.ConteudoEquipe", "id_equipe", "dbo.Equipe");
            DropIndex("dbo.ConteudoEquipe", new[] { "id_equipe" });
            DropIndex("dbo.ConteudoEquipe", new[] { "id_linguagem" });
            DropTable("dbo.Equipe");
            DropTable("dbo.ConteudoEquipe");
        }
    }
}
