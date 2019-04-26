namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestePreDeploy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_conteudomenu", "id_linguagem", "dbo.tb_linguagem");
            DropForeignKey("dbo.tb_conteudomenu", "id_menu", "dbo.tb_menu");
            DropIndex("dbo.tb_conteudomenu", new[] { "id_menu" });
            DropIndex("dbo.tb_conteudomenu", new[] { "id_linguagem" });
            DropTable("dbo.tb_conteudomenu");
            DropTable("dbo.tb_menu");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_menu",
                c => new
                    {
                        id_menu = c.Int(nullable: false, identity: true),
                        pai = c.String(maxLength: 100, unicode: false),
                        flg_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_menu);
            
            CreateTable(
                "dbo.tb_conteudomenu",
                c => new
                    {
                        id_conteudomenu = c.Int(nullable: false, identity: true),
                        id_menu = c.Int(nullable: false),
                        id_linguagem = c.Int(nullable: false),
                        conteudo = c.String(nullable: false, maxLength: 100, unicode: false),
                        url = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id_conteudomenu);
            
            CreateIndex("dbo.tb_conteudomenu", "id_linguagem");
            CreateIndex("dbo.tb_conteudomenu", "id_menu");
            AddForeignKey("dbo.tb_conteudomenu", "id_menu", "dbo.tb_menu", "id_menu", cascadeDelete: true);
            AddForeignKey("dbo.tb_conteudomenu", "id_linguagem", "dbo.tb_linguagem", "id_linguagem");
        }
    }
}
