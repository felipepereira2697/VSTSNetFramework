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
        
        //public enum Cargos { Vendedor=1, Gerente = 2 };
        
        private readonly FuncionarioDAO dao = new FuncionarioDAO();

        public FuncionarioBO()
        {
        
        }
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

            if(ValidarCpf(f) && ValidarIdadeFuncionario(f) && ValidarSalarioFuncionario(f))
            {
                
                return dao.Adicionar(f);
            }
            //deu problema no cpf
            return false;
        }

        public bool ValidarSalarioFuncionario(Funcionario f)
        {
            bool validou = true;
            if(f.Cargo.Equals("Vendedor"))
            {
                //Salario de até 5000
                if(f.Salario <= 5000)
                {
                    validou = true;
                    
                }else
                {
                    validou = false;
                }
            }else if(f.Cargo.Equals("Gerente"))
            {
                if(f.Salario >= 6000 && f.Salario <= 10000)
                {
                    validou = true;
                    
                }else
                {
                    validou = false;
                    
                }
                
            }else
            {
                validou = false;
                
            }
            return validou;
        }

        public void RecolherDadosConsole()
        {
            Random randomico = new Random();
            Console.WriteLine("Legal! Vamos adicionar um novo membro a nossa equipe!\n");
            Console.WriteLine("Vamos precisar de algumas informações básicas\n");
            Console.WriteLine("Digite o nome do novo funcionário(a)\n");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o cargo:\n");
            string cargo = Console.ReadLine();
            Console.WriteLine("Digite o salário para o cargo de " + cargo + "\n");
            string salario = Console.ReadLine();
            Console.WriteLine("Por favor, digite o CPF:\n ");
            string cpf = Console.ReadLine();
            string id = (randomico.Next(1, 10000)).ToString();
            Console.WriteLine("Dia do nascimento:\n");
            string diaNascimento = Console.ReadLine();
            Console.WriteLine("Mês do nascimento:\n");
            string mesNascimento = Console.ReadLine();
            Console.WriteLine("Ano do nascimento:\n");
            string anoNascimento = Console.ReadLine();

            int anoInt = Convert.ToInt32(anoNascimento);
            int mesInt = Convert.ToInt32(mesNascimento);
            int diaInt = Convert.ToInt32(diaNascimento);
            DateTime dataNascimento = new DateTime(anoInt, mesInt, diaInt);
            DateTime dataContratacao = DateTime.Now;

            bool retornou = AdicionarNovoFuncionarioViaConsole(id, nome, cpf, dataNascimento, cargo, Convert.ToInt32(salario));
            
            if(retornou)
            {
                Console.WriteLine("Seja muito bem vindo(a) " + nome + " o seu cargo de " + cargo + " já te espera!");
            }
            else
            {
                Console.WriteLine("Desculpe-nos o transtorno, favor contactar o seu administrador de sistema");
            }
            Console.ReadKey();
        }

        public bool ValidarIdadeFuncionario(Funcionario funcionario)
        {
            DateTime dataAtual = DateTime.Now;
            dataAtual = dataAtual.AddYears(-18);
            DateTime maior65 = DateTime.Now;
            maior65 = maior65.AddYears(-65);

            if(funcionario.DataNascimento < dataAtual && funcionario.DataNascimento > maior65  )
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

        public bool AdicionarNovoFuncionarioViaConsole(string id, string nome, string cpf, DateTime dataNascimento, string cargo, int salario)
        {
            Funcionario novoFuncionario = new Funcionario(id, nome, cpf, dataNascimento, cargo, Convert.ToInt32(salario));
            bool retorno = AdicionarNovoFuncionario(novoFuncionario);
            if(retorno)
            {
                return true;
            }
            return false;
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
        public bool MaiorQue21(Funcionario f)
        {
            DateTime dataAtual = DateTime.Now.AddYears(-21);
            if(f.DataNascimento <= dataAtual)
            {
                return true;
            }
            return false;
        }
        public bool AtualizarCargo(Funcionario funcionario)
        {
            bool atualizou = true;
            if (MaiorQue21(funcionario))
            {
                atualizou = dao.AtualizarCargoParaGerente(funcionario);
                
            }else
            {
                atualizou = false;
            }
            return atualizou;
        }

        public bool ChecarCargo(Funcionario funcionario)
        {
            bool cargoValido = true;
            if(funcionario.Cargo.Equals("Vendedor"))
            {
                cargoValido =  true;
            }
            else if(funcionario.Cargo.Equals("Gerente"))
            {
                cargoValido =  true;
            }else
            {
                cargoValido =  false;
            }
            return cargoValido;
        }
    }
}
