namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remover_campo_tipo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_institucional", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_institucional", "Tipo", c => c.Int(nullable: false));
        }
    }
}
