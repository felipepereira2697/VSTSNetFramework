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
         Deve Validar o cpf do funcionario verificando tbm se ja nao existe um cpf desse no banco
         Uma pessoa só pode ter um cargo
         Um gerente pode promover um vendedor ao cargo de gerente
         Somente deve existir cargo de gerente e vendedor
         Os salarios de vendedor nao devem ultrapassar os 5000
         o salario de gerente nao deve ultrapassar 10000 e nem ser abaixo de 6000
         
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
            f.Cargo = "Gerente";
            f.Cpf = "42135208892";
            f.DataContratacao = DateTime.Now;
            f.DataNascimento = new DateTime(1997,06,26);

            f.Id = (randomico.Next(1, 10000)).ToString();
            f.Nome = "Felipe Gerente";
            f.Salario = 7000;

            FuncionarioDAO dao = new FuncionarioDAO();
            bool adicionou = dao.Adicionar(f);

            //Quero que insira no banco real
            Assert.IsTrue(adicionou);
        }
    }
}
