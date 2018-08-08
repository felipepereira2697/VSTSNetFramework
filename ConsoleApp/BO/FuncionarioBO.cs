using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleApp.DAO;
using ConsoleApp.Model;

namespace ConsoleApp.BO
{
    public class FuncionarioBO
    {
        public FuncionarioDAO dao;

        //Regra de negocio para a FuncionarioBO
        public bool ValidarCpf(Funcionario f)
        {
            return !Regex.IsMatch(f.Cpf,"[a-zA-Z]");
        }

        public bool AdicionarNovoFuncionario(Funcionario f)
        {
            if(ValidarCpf(f))
            {
                dao = new FuncionarioDAO();
                return dao.Adicionar(f);
            }
            //deu problema no cpf
            return false;
        }
    }
}
