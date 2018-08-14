using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    [Table("Modelos")]
    public class Modelo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]  
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
            this.Quantidade = QuantidadeNegativa(this.Quantidade);
        }

        //Método de Helper
        private static int QuantidadeNegativa(int qtd)
        {
            if(qtd <= 0)
            {
                return 0;
            }else
            {
                return qtd;
            }
        }
    }
}
