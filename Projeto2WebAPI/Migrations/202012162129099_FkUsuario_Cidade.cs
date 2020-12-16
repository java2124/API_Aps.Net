namespace Projeto2WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkUsuario_Cidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuário", "cod_cidade", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuário", "cod_cidade");
            AddForeignKey("dbo.Usuário", "cod_cidade", "dbo.Cidades", "cod_cidade", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuário", "cod_cidade", "dbo.Cidades");
            DropIndex("dbo.Usuário", new[] { "cod_cidade" });
            DropColumn("dbo.Usuário", "cod_cidade");
        }
    }
}
