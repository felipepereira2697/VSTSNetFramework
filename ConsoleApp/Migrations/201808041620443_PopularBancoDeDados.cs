namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopularBancoDeDados : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Fabricantes (Nome) VALUES('FERRARI')");
            Sql("INSERT INTO Fabricantes (Nome) VALUES('BMW')");
            Sql("INSERT INTO Fabricantes (Nome) VALUES('MERCEDES - BENZ')");
            Sql("INSERT INTO Fabricantes (Nome) VALUES('BUGATTI')");
            Sql("INSERT INTO Fabricantes (Nome) VALUES('AUDI')");

            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Ferrari Enzo', 20, (SELECT Id FROM Fabricantes WHERE Nome = 'FERRARI')) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Ferrari Spider', 5, (SELECT Id FROM Fabricantes WHERE Nome = 'FERRARI')) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Ferrari Ultimate Model', 2, (SELECT Id FROM Fabricantes WHERE Nome = 'FERRARI')) ");


            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('BMW X5s', 40, (SELECT Id FROM Fabricantes WHERE Nome = 'BMW')) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('BMW X1 Special Edition', 4, (SELECT Id FROM Fabricantes WHERE Nome = 'BMW')) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('BMW Coupe ', 50, (SELECT Id FROM Fabricantes WHERE Nome = 'BMW')) ");

            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Mercedes CL 200', 90,(SELECT Id FROM Fabricantes WHERE Nome = 'MERCEDES - BENZ' )) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Mercedes McLaren 500', 3, (SELECT Id FROM Fabricantes WHERE Nome = 'MERCEDES - BENZ' )) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Mercedes AMG TIgt2', 14, (SELECT Id FROM Fabricantes WHERE Nome = 'MERCEDES - BENZ' )) ");

            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Buggati Veyron', 13, (SELECT Id FROM Fabricantes WHERE Nome = 'BUGATTI' )) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Buggati Chiron', 19, (SELECT Id FROM Fabricantes WHERE Nome = 'BUGATTI')) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Bugatti Eb110', 1, (SELECT Id FROM Fabricantes WHERE Nome = 'BUGATTI')) ");

            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Audi R8', 20, (SELECT Id FROM Fabricantes WHERE Nome = 'AUDI')) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Audi TT', 15, (SELECT Id FROM Fabricantes WHERE Nome = 'AUDI')) ");
            Sql("INSERT INTO Modelos (Nome, Quantidade, FabricanteId) VALUES('Audi RS6', 17, (SELECT Id FROM Fabricantes WHERE Nome = 'AUDI')) ");


        }
        
        public override void Down()
        {
            Sql("DELETE FROM Fabricante");
        }
    }
}
