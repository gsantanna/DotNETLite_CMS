namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovosCamposPublicacao2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_publicacao", "publicacao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_publicacao", "publicacao");
        }
    }
}
