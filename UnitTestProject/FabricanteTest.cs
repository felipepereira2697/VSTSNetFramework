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
    public class FabricanteTest
    {
        [TestMethod]
        public void DeveBuscarTodosOsFabricantesEmOrdemAlfabetica()
        {
            FabricanteBO bo = new FabricanteBO();
            List<Fabricante> todos = new List<Fabricante>();
            todos = bo.BuscarTodos();
            Assert.IsTrue(todos.Count > 1);
        }
    }
}
