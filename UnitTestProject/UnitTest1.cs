using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            modelos.Add(new Modelo { Id = 1,Name = "Enzo 411"});
            Fabricante fab = new Fabricante(1,"Ferrari", modelos);

            Assert.AreEqual(1, fab.Id);
            Assert.AreEqual("Ferrari", fab.Nome);
            
        }

        
    }
}
