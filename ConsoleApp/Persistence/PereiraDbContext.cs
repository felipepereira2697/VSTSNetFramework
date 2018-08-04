using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Model;
namespace ConsoleApp.Persistence
{
    public class PereiraDbContext : DbContext
    {
        //Modelo que mapeia as entidades e relações que são definidas para tabelas em um db
        //Depois de ter um modelo a classe principal interage com esse contexto
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        
        
    }
}
