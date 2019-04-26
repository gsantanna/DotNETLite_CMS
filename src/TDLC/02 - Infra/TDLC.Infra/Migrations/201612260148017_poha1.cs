namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poha1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configuracao",
                c => new
                    {
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Valor = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Nome);
            
            AddColumn("dbo.tb_linguagem", "Sitemap", c => c.String(maxLength: 1000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_linguagem", "Sitemap");
            DropTable("dbo.Configuracao");
        }
    }
}
