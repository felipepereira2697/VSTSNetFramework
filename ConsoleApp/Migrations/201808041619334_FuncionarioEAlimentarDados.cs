namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FuncionarioEAlimentarDados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Cargo = c.String(nullable: false),
                        Salario = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(nullable: false, maxLength: 15),
                        DataContratacao = c.DateTime(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Funcionarios");
        }
    }
}
