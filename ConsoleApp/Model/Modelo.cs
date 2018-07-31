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
        public string Name { get; set; }

        //Aqui vamos facilitar o mapeamento do Entity framework 

        public Fabricante Fabricante { get; set; }
        public int FabricanteId { get; set; }
    }
}
