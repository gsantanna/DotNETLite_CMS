namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoOrdem1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_areaatuacao", "Ordem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_areaatuacao", "Ordem");
        }
    }
}
