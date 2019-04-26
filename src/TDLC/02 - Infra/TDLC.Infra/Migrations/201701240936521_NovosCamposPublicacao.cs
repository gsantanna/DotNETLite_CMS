namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovosCamposPublicacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_conteudopublicacao", "Destaque_Titulo_Home_Topo", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.tb_conteudopublicacao", "Destaque_Titulo_Home_Corpo", c => c.String(maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_conteudopublicacao", "Destaque_Titulo_Home_Corpo");
            DropColumn("dbo.tb_conteudopublicacao", "Destaque_Titulo_Home_Topo");
        }
    }
}
