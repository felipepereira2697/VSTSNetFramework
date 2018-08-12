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
        private readonly FuncionarioDAO dao = new FuncionarioDAO();

        //Regra de negocio para a FuncionarioBO
        public bool ValidarCpf(Funcionario f)
        {
            return !Regex.IsMatch(f.Cpf,"[a-zA-Z]");
        }

        public List<Funcionario> BuscarFuncionarioPorCargo(string nomeCargo)
        {
            
            List <Funcionario> funcionarios= new List<Funcionario>();
            
            //Ordenando pelo nome, como isso pode mudar, decidi optar por deixar na regra de negocio
            funcionarios = dao.BuscarPorCargo(nomeCargo).OrderBy(x => x.Nome).ToList();

            return funcionarios;

        }

        public bool AdicionarNovoFuncionario(Funcionario f)
        {

            if(ValidarCpf(f) && ValidarIdadeFuncionario(f))
            {
                
                return dao.Adicionar(f);
            }
            //deu problema no cpf
            return false;
        }
        public bool ValidarIdadeFuncionario(Funcionario funcionario)
        {
            DateTime dataAtual = DateTime.Now;
            dataAtual = dataAtual.AddYears(-18);
            if(funcionario.DataNascimento < dataAtual)
            {
                return true;
            }
            return false;
        }
        public Funcionario BuscarFuncionarioPorNome(string nome)
        {
            
            if(NomeValido(nome))
            {
                return dao.BuscarPorNome(nome);
                
            }else
            {

                Console.WriteLine("Não encontrou ninguem com o nome: "+nome);
                //pra nao retornar nulo
                return new Funcionario();
            }
            

            //Aqui vamos receber uma Lista da DAO e vamos verificar se nao temos mais de uma ocorrencia de nome
        }

        private static bool NomeValido(string nome)
        {
            //se não tem somente letras deve retornar falso para nao validar operacoes com nome que tenha numero
            if (Regex.IsMatch(nome, @"^[0-9]+$"))
            {
                return false;
            }
            return true;
        }

        private static bool ValidaCargo(string cargo)
        {
            //Um cargo nao pode conter nenhum caracter especial, nem numero
            if (Regex.IsMatch(cargo, @"^[0-9]+$"))
            {
                return false;
            }
            return true;

        }
        public Funcionario BuscarFuncionarioPorNomeECargo(string nome, string cargo)
        {
            
            List<Funcionario> resultado = new List<Funcionario>();
            if (NomeValido(nome) && ValidaCargo(cargo))
            {
                resultado = dao.BuscarPorNomeECargo(nome, cargo);

                if (resultado.Count > 1)
                {
                    //significa que tem duplicado, pega o primeiro e retorna
                    Console.WriteLine("Cadastro duplicado para o funcionario: "+nome);
                }
                return resultado.FirstOrDefault();
            }

            return null;

        }

        public bool PromoverAoCargoDeGerente(Funcionario gerente, Funcionario vendedor)
        {
            
            if (!vendedor.Cargo.Equals("Gerente"))
            {
                vendedor.Cargo = "Gerente";
                bool resultado = dao.Atualizar(vendedor);
                return resultado;
            }
            return false;
            
        }

        public List<Funcionario> BuscarTodos()
        {
            return dao.Buscar().OrderBy(x => x.Nome).ToList();
        }

        public void ListarTodosOsFuncionariosConsole()
        {
            List<Funcionario> funcionarios = BuscarTodos();
            Console.WriteLine("Listando todos os funcionarios");
            Console.WriteLine("-------------------------------------------------\n");
            foreach (var item in funcionarios)
            {
                Console.WriteLine($"Nome: {item.Nome} \n\t Cargo: {item.Cargo}\n ");
            }
            Console.ReadKey();
        }

        public List<Funcionario> BuscarTodosOrdenandoPorCargo()
        {
            return dao.Buscar().OrderBy(x => x.Cargo).ToList();
        }

        public Funcionario BuscarPorIdFuncionario(string id)
        {
            if(ValidarId(id))
            {
                int idInt = Convert.ToInt32(id);
                return dao.BuscarPorId(idInt);
            }
            return new Funcionario();
            
        }

        private static bool ValidarId(string id)
        {
            if(Regex.IsMatch(id, "[a-zA-Z]"))
            {
                return false;
            }
            return true;
        }
    }
}
