namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_linguaem", newName: "tb_linguagem");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_linguagem", newName: "tb_linguaem");
        }
    }
}
