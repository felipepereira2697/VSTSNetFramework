using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Modelo> Modelos { get; set; }

        public Fabricante()
        {
            this.Modelos = new Collection<Modelo>();
        }

        public Fabricante(int Id, string Name, ICollection<Modelo> Modelos)
        {
            this.Id = Id;
            this.Nome = Name;
            this.Modelos = Modelos;
        }

    }
}
