namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campourl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_publicacao", "URL", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_publicacao", "URL");
        }
    }
}
