namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoPai : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_areaatuacao", "id_pai", c => c.Int());
            CreateIndex("dbo.tb_areaatuacao", "id_pai");
            AddForeignKey("dbo.tb_areaatuacao", "id_pai", "dbo.tb_areaatuacao", "id_areaatuacao");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_areaatuacao", "id_pai", "dbo.tb_areaatuacao");
            DropIndex("dbo.tb_areaatuacao", new[] { "id_pai" });
            AlterColumn("dbo.tb_areaatuacao", "id_pai", c => c.Int(nullable: false));
        }
    }
}
