namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagens : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_conteudopublicacao", "Imagem7", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Imagem8", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Imagem9", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Imagem10", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_conteudopublicacao", "Imagem10");
            DropColumn("dbo.tb_conteudopublicacao", "Imagem9");
            DropColumn("dbo.tb_conteudopublicacao", "Imagem8");
            DropColumn("dbo.tb_conteudopublicacao", "Imagem7");
        }
    }
}
