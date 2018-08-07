using ConsoleApp.BO;
using ConsoleApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
         o salario de gerente nao deve ultrapassar 10000
         
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
    }
}
