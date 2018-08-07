using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleApp.Model;

namespace ConsoleApp.BO
{
    public class FuncionarioBO
    {
        //Regra de negocio para a FuncionarioBO
        public bool ValidarCpf(Funcionario f)
        {
            return !Regex.IsMatch(f.Cpf,"[a-zA-Z]");
        }
    }
}
