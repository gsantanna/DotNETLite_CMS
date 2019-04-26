namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_conteudopublicacao",
                c => new
                    {
                        id_conteudopublicacao = c.Int(nullable: false, identity: true),
                        titulo = c.String(nullable: false, maxLength: 255, unicode: false),
                        subtitulo = c.String(nullable: false, maxLength: 255, unicode: false),
                        conteudo = c.String(nullable: false, unicode: false, storeType: "text"),
                        id_linguagem = c.Int(nullable: false),
                        id_publicacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_conteudopublicacao)
                .ForeignKey("dbo.tb_linguaem", t => t.id_linguagem)
                .ForeignKey("dbo.tb_publicacao", t => t.id_publicacao)
                .Index(t => t.id_linguagem)
                .Index(t => t.id_publicacao);
            
            CreateTable(
                "dbo.tb_linguaem",
                c => new
                    {
                        id_linguagem = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        cultura = c.String(nullable: false, maxLength: 30, unicode: false),
                        codepage = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.id_linguagem);
            
            CreateTable(
                "dbo.tb_publicacao",
                c => new
                    {
                        id_publicacao = c.Int(nullable: false, identity: true),
                        Destaque = c.Boolean(nullable: false),
                        DestaqueTopo = c.Boolean(nullable: false),
                        Criado = c.DateTime(nullable: false),
                        Modificado = c.DateTime(nullable: false),
                        criadopor = c.String(nullable: false, maxLength: 100, unicode: false),
                        modificadopor = c.String(nullable: false, maxLength: 100, unicode: false),
                        id_tipopublicacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_publicacao)
                .ForeignKey("dbo.tb_tipopublicacao", t => t.id_tipopublicacao)
                .Index(t => t.id_tipopublicacao);
            
            CreateTable(
                "dbo.tb_tipopublicacao",
                c => new
                    {
                        id_tipopublicacao = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id_tipopublicacao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_conteudopublicacao", "id_publicacao", "dbo.tb_publicacao");
            DropForeignKey("dbo.tb_publicacao", "id_tipopublicacao", "dbo.tb_tipopublicacao");
            DropForeignKey("dbo.tb_conteudopublicacao", "id_linguagem", "dbo.tb_linguaem");
            DropIndex("dbo.tb_publicacao", new[] { "id_tipopublicacao" });
            DropIndex("dbo.tb_conteudopublicacao", new[] { "id_publicacao" });
            DropIndex("dbo.tb_conteudopublicacao", new[] { "id_linguagem" });
            DropTable("dbo.tb_tipopublicacao");
            DropTable("dbo.tb_publicacao");
            DropTable("dbo.tb_linguaem");
            DropTable("dbo.tb_conteudopublicacao");
        }
    }
}
