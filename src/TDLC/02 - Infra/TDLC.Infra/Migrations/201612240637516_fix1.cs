namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_conteudopublicacao", "subtitulo", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.tb_conteudopublicacao", "conteudo", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_conteudopublicacao", "conteudo", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.tb_conteudopublicacao", "subtitulo", c => c.String(nullable: false, maxLength: 255, unicode: false));
        }
    }
}
