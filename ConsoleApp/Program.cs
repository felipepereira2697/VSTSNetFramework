using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta c = new Conta();
            c.Nome = "Felipe";
            c.Saldo = 10000;
            Console.WriteLine($"Saldo do {c.Nome} é de {c.ConsultaSaldo()} ") ;
            Console.ReadKey();
        }
    }
}
