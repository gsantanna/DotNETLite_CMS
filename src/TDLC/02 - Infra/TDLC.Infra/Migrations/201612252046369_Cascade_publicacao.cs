namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cascade_publicacao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_conteudopublicacao", "id_publicacao", "dbo.tb_publicacao");
            AddForeignKey("dbo.tb_conteudopublicacao", "id_publicacao", "dbo.tb_publicacao", "id_publicacao", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_conteudopublicacao", "id_publicacao", "dbo.tb_publicacao");
            AddForeignKey("dbo.tb_conteudopublicacao", "id_publicacao", "dbo.tb_publicacao", "id_publicacao");
        }
    }
}
