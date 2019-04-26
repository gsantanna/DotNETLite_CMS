namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyBalls011 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_endereco", "logradouro", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.tb_endereco", "numero", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.tb_endereco", "Complemento", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.tb_endereco", "UF", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.tb_endereco", "CEP", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.tb_endereco", "VisivelHome", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_endereco", "VisivelContato", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tb_endereco", "mapa", c => c.String(maxLength: 4000, unicode: false));
            DropColumn("dbo.tb_endereco", "pagina");
            DropColumn("dbo.tb_endereco", "descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_endereco", "descricao", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.tb_endereco", "pagina", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.tb_endereco", "mapa", c => c.String(maxLength: 8000, unicode: false));
            DropColumn("dbo.tb_endereco", "VisivelContato");
            DropColumn("dbo.tb_endereco", "VisivelHome");
            DropColumn("dbo.tb_endereco", "CEP");
            DropColumn("dbo.tb_endereco", "UF");
            DropColumn("dbo.tb_endereco", "Complemento");
            DropColumn("dbo.tb_endereco", "numero");
            DropColumn("dbo.tb_endereco", "logradouro");
        }
    }
}
