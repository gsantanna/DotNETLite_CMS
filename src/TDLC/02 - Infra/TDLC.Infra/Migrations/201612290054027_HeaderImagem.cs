namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeaderImagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_tipopublicacao", "imagemheader", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_tipopublicacao", "imagemheader");
        }
    }
}
