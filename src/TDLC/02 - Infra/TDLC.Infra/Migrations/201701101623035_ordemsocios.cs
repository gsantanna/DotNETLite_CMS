namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordemsocios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_equipe", "Ordem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_equipe", "Ordem");
        }
    }
}
