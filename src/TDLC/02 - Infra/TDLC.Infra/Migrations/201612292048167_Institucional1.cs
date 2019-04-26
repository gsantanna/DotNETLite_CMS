namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Institucional1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_conteudoinstitucional",
                c => new
                    {
                        id_conteudoinstitucional = c.Int(nullable: false, identity: true),
                        id_institucional = c.Int(nullable: false),
                        id_linguagem = c.Int(nullable: false),
                        conteudo = c.String(nullable: false, unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id_conteudoinstitucional)
                .ForeignKey("dbo.tb_institucional", t => t.id_institucional, cascadeDelete: true)
                .ForeignKey("dbo.tb_linguagem", t => t.id_linguagem)
                .Index(t => t.id_institucional)
                .Index(t => t.id_linguagem);
            
            CreateTable(
                "dbo.tb_institucional",
                c => new
                    {
                        id_institucional = c.Int(nullable: false, identity: true),
                        Area = c.String(maxLength: 8000, unicode: false),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Tipo = c.Int(nullable: false),
                        arquivo = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id_institucional);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_conteudoinstitucional", "id_linguagem", "dbo.tb_linguagem");
            DropForeignKey("dbo.tb_conteudoinstitucional", "id_institucional", "dbo.tb_institucional");
            DropIndex("dbo.tb_conteudoinstitucional", new[] { "id_linguagem" });
            DropIndex("dbo.tb_conteudoinstitucional", new[] { "id_institucional" });
            DropTable("dbo.tb_institucional");
            DropTable("dbo.tb_conteudoinstitucional");
        }
    }
}
