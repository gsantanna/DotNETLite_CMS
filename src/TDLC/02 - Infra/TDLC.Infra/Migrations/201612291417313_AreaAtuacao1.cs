namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AreaAtuacao1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_areaatuacao",
                c => new
                    {
                        id_areaatuacao = c.Int(nullable: false, identity: true),
                        id_pai = c.Int(nullable: false),
                        imagem = c.String(maxLength: 100, unicode: false),
                        Destaque = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_areaatuacao);
            
            CreateTable(
                "dbo.tb_conteudoareaatuacao",
                c => new
                    {
                        id_conteudoareatuacao = c.Int(nullable: false, identity: true),
                        id_areaatuacao = c.Int(nullable: false),
                        nome = c.String(nullable: false, maxLength: 255, unicode: false),
                        chamada = c.String(maxLength: 600, unicode: false),
                        Conteudo = c.String(maxLength: 8000, unicode: false),
                        id_linguagem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_conteudoareatuacao)
                .ForeignKey("dbo.tb_areaatuacao", t => t.id_areaatuacao, cascadeDelete: true)
                .ForeignKey("dbo.tb_linguagem", t => t.id_linguagem)
                .Index(t => t.id_areaatuacao)
                .Index(t => t.id_linguagem);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_conteudoareaatuacao", "id_linguagem", "dbo.tb_linguagem");
            DropForeignKey("dbo.tb_conteudoareaatuacao", "id_areaatuacao", "dbo.tb_areaatuacao");
            DropIndex("dbo.tb_conteudoareaatuacao", new[] { "id_linguagem" });
            DropIndex("dbo.tb_conteudoareaatuacao", new[] { "id_areaatuacao" });
            DropTable("dbo.tb_conteudoareaatuacao");
            DropTable("dbo.tb_areaatuacao");
        }
    }
}
