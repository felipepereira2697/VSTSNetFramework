namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarIdFuncionario : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Funcionarios");
            AlterColumn("dbo.Funcionarios", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Funcionarios", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Funcionarios");
            AlterColumn("dbo.Funcionarios", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Funcionarios", "Id");
        }
    }
}
