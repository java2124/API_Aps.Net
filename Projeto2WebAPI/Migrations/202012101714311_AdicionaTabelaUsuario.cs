namespace Projeto2WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaTabelaUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuário",
                c => new
                    {
                        cod_cliente = c.Int(nullable: false, identity: true),
                        nome_cliente = c.String(nullable: false, maxLength: 100, unicode: false),
                        sobrenome_cliente = c.String(maxLength: 100, unicode: false),
                        cpf_cliente = c.String(nullable: false, maxLength: 11, unicode: false),
                        celular_cliente = c.String(maxLength: 11),
                        tel_cliente = c.String(maxLength: 10),
                        rg_cliente = c.String(nullable: false, maxLength: 9, unicode: false),
                        email_cliente = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.cod_cliente);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuário");
        }
    }
}
