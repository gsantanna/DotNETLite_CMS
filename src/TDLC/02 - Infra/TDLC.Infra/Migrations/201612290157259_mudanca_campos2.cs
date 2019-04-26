namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudanca_campos2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem1", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem2", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem3", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem4", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem5", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem6", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem7", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem8", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem9", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem10", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem10", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem9", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem8", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem7", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem6", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem5", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem4", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem3", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem2", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "Imagem1", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
