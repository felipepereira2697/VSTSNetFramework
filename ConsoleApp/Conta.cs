using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Conta
    {
        public string Nome { get; set; }
        public int Saldo { get; set; }

        public Conta() { }

        public Conta(string Nome, int Saldo)
        {
            this.Nome = Nome;
            this.Saldo = Saldo;
        }

        public int ConsultaSaldo()
        {
            return this.Saldo;  
        }
    }
}
