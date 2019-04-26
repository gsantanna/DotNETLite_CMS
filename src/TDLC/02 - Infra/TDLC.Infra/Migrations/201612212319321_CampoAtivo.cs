namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoAtivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_linguagem", "padrao", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_linguagem", "padrao");
        }
    }
}
