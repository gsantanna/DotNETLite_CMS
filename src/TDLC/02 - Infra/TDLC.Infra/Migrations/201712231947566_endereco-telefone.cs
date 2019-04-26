namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enderecotelefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_endereco", "Telefone", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_endereco", "Telefone");
        }
    }
}
