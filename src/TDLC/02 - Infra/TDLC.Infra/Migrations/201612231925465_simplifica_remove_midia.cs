namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simplifica_remove_midia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_conteudopublicacao", "Imagem1", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Imagem2", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Imagem3", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Imagem4", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Imagem5", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Imagem6", c => c.String(maxLength: 100, unicode: false));
            DropTable("dbo.tb_midia");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_midia",
                c => new
                    {
                        id_midia = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 255, unicode: false),
                        NomeArquivo = c.String(maxLength: 800, unicode: false),
                        Tipo = c.Int(nullable: false),
                        Criacao = c.DateTime(nullable: false),
                        Autor = c.String(maxLength: 80, unicode: false),
                        Tamanho = c.Int(),
                        Mime = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.id_midia);
            
            DropColumn("dbo.tb_conteudopublicacao", "Imagem6");
            DropColumn("dbo.tb_conteudopublicacao", "Imagem5");
            DropColumn("dbo.tb_conteudopublicacao", "Imagem4");
            DropColumn("dbo.tb_conteudopublicacao", "Imagem3");
            DropColumn("dbo.tb_conteudopublicacao", "Imagem2");
            DropColumn("dbo.tb_conteudopublicacao", "Imagem1");
        }
    }
}
