namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopularFuncionarios : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Funcionarios (Id,Nome, Cpf, DataContratacao, DataNascimento, Cargo, Salario) " +
                "VALUES(1,'John Lennon', '36589755585', 26/06/2017,09/10/1940, 'Gerente', 140000) ");

            Sql("INSERT INTO Funcionarios (Id,Nome, Cpf, DataContratacao, DataNascimento, Cargo, Salario) " +
                "VALUES(2,'Paul McCartney', '52154856689', 12/05/2003,12/06/1945, 'Vendedor', 7000) ");

            Sql("INSERT INTO Funcionarios (Id,Nome, Cpf, DataContratacao, DataNascimento, Cargo, Salario) " +
                "VALUES(3,'George Harrison', '54785120058', 20/03/2005,15/06/1960, 'Gerente', 70000) ");

            Sql("INSERT INTO Funcionarios (Id, Nome, Cpf, DataContratacao, DataNascimento, Cargo, Salario) " +
                "VALUES(4,'Ringo Starr', '12354125578', 28/08/2015,05/02/1935, 'Vendedor', 6200) ");

            Sql("INSERT INTO Funcionarios (Id, Nome, Cpf, DataContratacao, DataNascimento, Cargo, Salario) " +
                "VALUES(5,'Rocky Balboa', '58745596321', 26/01/2004,14/12/1965, 'Gerente', 120000) ");

            Sql("INSERT INTO Funcionarios (Id, Nome, Cpf, DataContratacao, DataNascimento, Cargo, Salario) " +
                "VALUES(6,'Leia Skywalker', '12354789965', 24/09/1998,18/09/1971, 'Vendedor', 8700) ");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Funcionarios");
        }
    }
}
