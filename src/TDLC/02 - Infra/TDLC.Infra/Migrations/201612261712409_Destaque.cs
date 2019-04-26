namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Destaque : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_conteudopublicacao", "Destaque_Categoria", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Destaque_Titulo", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Destaque_Texto", c => c.String(maxLength: 300, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_conteudopublicacao", "Destaque_Texto");
            DropColumn("dbo.tb_conteudopublicacao", "Destaque_Titulo");
            DropColumn("dbo.tb_conteudopublicacao", "Destaque_Categoria");
        }
    }
}
