namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Midia1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_midia",
                c => new
                    {
                        id_midia = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 255, unicode: false),
                        NomeArquivo = c.String(maxLength: 800, unicode: false),
                        Tipo = c.Int(nullable: false),
                        Criacao = c.DateTime(nullable: false),
                        Autor = c.String(maxLength: 80, unicode: false),
                        Tamanho = c.Int(),
                        Mime = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.id_midia);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_midia");
        }
    }
}
