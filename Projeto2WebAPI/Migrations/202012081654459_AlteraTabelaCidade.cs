namespace Projeto2WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteraTabelaCidade : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cidades", "nome_cidade", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Cidades", "uf_cidade", c => c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false));
            AlterColumn("dbo.Cidades", "cep_cidade", c => c.String(maxLength: 8, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cidades", "cep_cidade", c => c.String(maxLength: 8));
            AlterColumn("dbo.Cidades", "uf_cidade", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Cidades", "nome_cidade", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
