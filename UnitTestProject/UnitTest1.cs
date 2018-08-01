using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ConsoleApp.BO;
using ConsoleApp.DAO;
using ConsoleApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestaConstrutorDaClasseFabricante()
        {
            ICollection<Modelo> modelos = new Collection<Modelo>();
            modelos.Add(new Modelo { Id = 1,Nome = "Enzo 411"});
            Fabricante fab = new Fabricante(1,"Ferrari", modelos);

            Assert.AreEqual(1, fab.Id);
            Assert.AreEqual("Ferrari", fab.Nome);   
        }

        [TestMethod]
        public void TestaConstrutorDaClasseModelo()
        {
            Modelo modelo = new Modelo(2, "BMW - X1", 10);

            Assert.AreEqual(2, modelo.Id);
            Assert.AreEqual("BMW - X1", modelo.Nome);
            Assert.AreEqual(10, modelo.Quantidade);
        }

        [TestMethod]
        public void DevePermitirVendaDeModeloSomenteComAQuantidadeCorreta()
        {
            //Criar uma fabrica 
            Fabricante fab = new Fabricante();
            fab.Nome = "Mercedes - Benz";
            fab.Id = 1;
            ICollection<Modelo> modelos = new Collection<Modelo>();
            modelos.Add(new Modelo { Nome = "CLK - 180", Id = 12, Quantidade = 10 });

            ModeloBO bo = new ModeloBO();
            int quantidadeVendida = 3;
            bool vendeu = bo.VenderModelo(modelos.First(),quantidadeVendida);

            Assert.IsTrue(vendeu);



        }
        
    }
}
