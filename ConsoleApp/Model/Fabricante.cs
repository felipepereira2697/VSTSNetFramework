using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    [Table("Fabricantes")]
    public class Fabricante
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
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
        public Fabricante(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;
        }
    }
}
