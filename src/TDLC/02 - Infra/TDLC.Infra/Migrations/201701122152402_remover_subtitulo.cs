namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remover_subtitulo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_conteudopublicacao", "subtitulo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_conteudopublicacao", "subtitulo", c => c.String(maxLength: 255, unicode: false));
        }
    }
}
