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
            using (var context = new PereiraDbContext())
            {
                return context.Funcionarios.Where(x => x.Nome.Equals(nome)).First();
            }
        }

        public List<Funcionario> BuscarPorNomeECargo(string nome, string cargo)
        {
             
            using (var context = new PereiraDbContext())
            {
                IQueryable<Funcionario> resultado = from f in context.Funcionarios
                                                    where f.Nome.Equals(nome) && f.Cargo.Equals(cargo)
                                                    select f;
                return resultado.ToList();
            }
        }
    }
}
