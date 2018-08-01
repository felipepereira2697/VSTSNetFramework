using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        //Aqui vamos facilitar o mapeamento do Entity framework 

        public Fabricante Fabricante { get; set; }
        public int FabricanteId { get; set; }

        public Modelo() { }
        public Modelo(int Id, string Nome, int Quantidade)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Quantidade = Quantidade <= 0 ? this.Quantidade = 0 : this.Quantidade = Quantidade ;
        }
    }
}
