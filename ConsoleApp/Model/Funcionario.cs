using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    [Table("Funcionarios")]

    public class Funcionario 
    {
    
       
        public string Id { get; set; }


        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(15)]
        public string Cpf { get; set; }

        public DateTime DataContratacao { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public int Salario { get; set; }
        

        public Funcionario()
        {

        }
        public Funcionario(string Id,string Nome, string Cpf, 
            DateTime DataNascimento, string Cargo, int Salario )
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.DataNascimento = DateTime.Now ;
            this.Cargo = Cargo;
            this.Salario = Salario;
        }
        
    }
}
