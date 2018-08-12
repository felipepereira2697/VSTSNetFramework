using ConsoleApp.BO;
using ConsoleApp.DAO;
using ConsoleApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class FuncionarioTest
    {
        //Alguns Cenarios de teste

        /*
         
             Um gerente pode promover um vendedor ao cargo de gerente
             Somente deve existir cargo de gerente e vendedor
             Os salarios de vendedor nao devem ultrapassar os 5000
             o salario de gerente nao deve ultrapassar 10000 e nem ser abaixo de 6000
         
                gerente deve remover vendedor  --> delete
                Ajustar code smells



             o funcionario só pode ser cadastrado caso tenha mais de 18 anos para os cargos de vendedor
             e 21 para o caso de gerente
             
             */

        [TestMethod]
        public void DeveValidarOCpfDoFuncionario()
        {
            Funcionario f = new Funcionario();
            f.Cargo = "Vendedor";
            f.Cpf = "djsklkdsl213123";
            FuncionarioBO bo = new FuncionarioBO();
            bool validou = bo.ValidarCpf(f);
            Assert.IsFalse(validou);
            
        }
        [TestMethod]
        public void DeveTestarInserirFuncionarios()
        {
            //GregorianCalendar calendario = new GregorianCalendar();
            Random randomico = new Random();
            Funcionario f = new Funcionario();
            f.Cargo = "Vendedor";
            f.Cpf = "12343212345";
            f.DataContratacao = DateTime.Now;
            f.DataNascimento = new DateTime(1997,06,26);

            f.Id = (randomico.Next(1, 10000)).ToString();
            f.Nome = "Felipe Vendedor Novo"+ (randomico.Next(1, 10000)).ToString();
            f.Salario = 5000;

            //Tivemos problemas ao chamar Direto a DAO quando usamos cpf invalido

            //FuncionarioDAO dao = new FuncionarioDAO();
            //bool adicionou = dao.Adicionar(f);

            FuncionarioBO bo = new FuncionarioBO();
            bool adicionou = bo.AdicionarNovoFuncionario(f);
             

            //Quero que insira no banco real
            Assert.IsTrue(adicionou);
        }

        [TestMethod]
        public void NaoDevePermitirAInsercaoDeFuncionarioComCpfIncorreto()
        {
            Random randomico = new Random();
            Funcionario f = new Funcionario();
            f.Cargo = "Vendedor";
            f.Cpf = "4213cpfnaovalido892";
            f.DataContratacao = DateTime.Now;
            f.DataNascimento = new DateTime(1997, 06, 26);

            f.Id = (randomico.Next(1, 10000)).ToString();
            f.Nome = "Felipe Gerente";
            f.Salario = 7000;

            //Nao podemos chamar direto da DAO

            FuncionarioBO bo = new FuncionarioBO();
            bool adicionou = bo.AdicionarNovoFuncionario(f);

            //Quero que insira no banco real
            Assert.IsFalse(adicionou);
        }

        [TestMethod]
        public void DeveBuscarTodosOsFuncionariosComCargoDeVendedor()
        {
            FuncionarioBO bo = new FuncionarioBO();
            string nomeCargo = "Vendedor";
            List<Funcionario> vendedores = bo.BuscarFuncionarioPorCargo(nomeCargo);

            Assert.IsTrue(vendedores.Count > 0);
        }

        [TestMethod]
        public void DeveBuscarTodosOsFuncionariosComCargoDeGerente()
        {
            FuncionarioBO bo = new FuncionarioBO();
            string nomeCargo = "Gerente";
            List<Funcionario> gerentes = bo.BuscarFuncionarioPorCargo(nomeCargo);

            Assert.IsTrue(gerentes.Count > 0);
        }
        [TestMethod]
        public void BuscarFuncionarioPorNomeECargoUmFuncionarioSoPodeTerUmCargo()
        {
            FuncionarioBO bo = new FuncionarioBO();
            string nome = "John Lennon";
            string cargo1 = "Vendedor";
            string cargo2 = "Gerente";

            //Nome da pessoa é unico e ela só pode ter um cargo
            Funcionario f = bo.BuscarFuncionarioPorNomeECargo(nome, cargo1);
            Funcionario f2 = bo.BuscarFuncionarioPorNomeECargo(nome, cargo2);

            Assert.IsNull(f);
            Assert.IsNotNull(f2);
           
        }
        /*
        [TestMethod]
        public void OGerenteDevePromoverUmVendedorAGerente()
        {
            FuncionarioBO bo = new FuncionarioBO();
            Funcionario vendedor = bo.BuscarFuncionarioPorNome("Felipe Vendedor Novo");
            Funcionario gerente = bo.BuscarFuncionarioPorNome("John Lennon");

            bool promovido = bo.PromoverAoCargoDeGerente(gerente,vendedor);

            Assert.IsNotNull(promovido);
            
        }
        */
        
        [TestMethod]
        public void DeveTrazerTodosOsFuncionariosDaEmpresaEmOrdemAlfabetica()
        {
            FuncionarioBO bo = new FuncionarioBO();
            List<Funcionario> funcionarios = bo.BuscarTodos();

            //Empresa deve ter ao menos um funcionario que é um gerente
            Assert.IsTrue(funcionarios.Count > 1);
        }

        [TestMethod]
        public void DeveTrazerEOrdernarOsFuncionariosDaEmpresaPeloCargo()
        {
            FuncionarioBO bo = new FuncionarioBO();
            List<Funcionario> funcionarios = bo.BuscarTodosOrdenandoPorCargo();

            Assert.IsTrue(funcionarios.Count > 1);
            Assert.AreEqual("Gerente", funcionarios.First().Cargo);
            Assert.AreEqual("Vendedor", funcionarios.Last().Cargo);
        }

        [TestMethod]
        public void DeveBuscarPorIdUmFuncionario()
        {
            FuncionarioBO bo = new FuncionarioBO();

            Funcionario  f = bo.BuscarPorIdFuncionario("1");
            Funcionario fNome = bo.BuscarFuncionarioPorNome("John Lennon");

            Assert.AreEqual(f.Id, fNome.Id);
            Assert.AreEqual(f.Nome, fNome.Nome);

        }
        
        [TestMethod]
        public void DeveContratarFuncionariosSomenteComMaisDe18Anos()
        {
            //o funcionario só pode ser cadastrado caso tenha mais de 18 anos para os cargos de vendedor
            Funcionario maior = new Funcionario();
            Funcionario menor = new Funcionario();

            Random randomico = new Random();
            
            maior.Cargo = "Vendedor";
            maior.Cpf = "12343212345";
            maior.DataContratacao = DateTime.Now;
            maior.DataNascimento = new DateTime(1997, 06, 26);

            maior.Id = (randomico.Next(1, 10000)).ToString();
            maior.Nome = "Wellison Vendedor Novo" + (randomico.Next(1, 10000)).ToString();
            maior.Salario = 5000;


            menor.Cargo = "Vendedor";
            menor.Cpf = "12343212345";
            menor.DataContratacao = DateTime.Now;
            menor.DataNascimento = new DateTime(2015, 06, 26);

            menor.Id = (randomico.Next(1, 10000)).ToString();
            menor.Nome = "Wellison Vendedor Novo" + (randomico.Next(1, 10000)).ToString();
            menor.Salario = 3000;


            FuncionarioBO bo = new FuncionarioBO();
            bool resMaior = bo.AdicionarNovoFuncionario(maior);
            bool resMenor = bo.AdicionarNovoFuncionario(menor);

            Assert.IsTrue(resMaior);
            Assert.IsFalse(resMenor);

        }

    }
}
