namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeaderImagem2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_tipopublicacao", "nometipo", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_tipopublicacao", "nometipo");
        }
    }
}
