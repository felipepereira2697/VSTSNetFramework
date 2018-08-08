using ConsoleApp.Model;
using ConsoleApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public class FuncionarioDAO : IOperacoesBD<Funcionario>
    {
        public bool Adicionar(Funcionario o)
        {
            using (var context = new PereiraDbContext())
            {
                if(o != null)
                {
                    context.Funcionarios.Add(o);
                    context.SaveChanges();
                    return true;
                }
                
            }
            return false;
        }
        public List<Funcionario> BuscarPorCargo(string nomeCargo)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            using (var context = new PereiraDbContext())
            {
                funcionarios =  context.Funcionarios.Where(c => c.Cargo.Equals(nomeCargo)).ToList();
                return funcionarios;
            }

        }
        public bool Atualizar(Funcionario o)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> Buscar()
        {
            throw new NotImplementedException();
        }

        public Funcionario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Funcionario BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
