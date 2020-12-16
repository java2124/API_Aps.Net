namespace Projeto2WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteraTabelaUsuario : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuário", "celular_cliente", c => c.String(maxLength: 11, unicode: false));
            AlterColumn("dbo.Usuário", "tel_cliente", c => c.String(maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuário", "tel_cliente", c => c.String(maxLength: 10));
            AlterColumn("dbo.Usuário", "celular_cliente", c => c.String(maxLength: 11));
        }
    }
}
