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

            using (var context = new PereiraDbContext())
            {
                Funcionario antigo = context.Funcionarios.Where(x => x.Id == o.Id).FirstOrDefault();
                antigo.Cargo = o.Cargo;
                antigo.Cpf = o.Cpf;
                antigo.DataContratacao = o.DataContratacao;
                antigo.DataNascimento = o.DataNascimento;
                antigo.Nome = o.Nome;
                antigo.Salario = o.Salario;
                int salvou = context.SaveChanges();
                if(salvou > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public List<Funcionario> Buscar()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            using (var context = new PereiraDbContext())
            {
                funcionarios =  context.Funcionarios.ToList();

                return funcionarios;
            }
        }

        public Funcionario BuscarPorId(int id)
        {
            string idString = Convert.ToString(id);
            using (var context = new PereiraDbContext())
            {
                return context.Funcionarios.Where(x => x.Id.Equals(idString)).First();
            }

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
