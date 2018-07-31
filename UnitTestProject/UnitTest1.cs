using System;
using ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Conta c = new Conta();
            c.Nome = "Felipe";
            c.Saldo = 1000;

            int res = c.ConsultaSaldo();

            Assert.AreEqual(1000, res);
        }

        [TestMethod]
        public void TestaOConstrutorDaClasseConta()
        {
            string nome = "Felipe";
            int saldo = 1911991;
            Conta c = new Conta(nome,saldo );
            Assert.AreEqual(nome,c.Nome);
            Assert.AreEqual(saldo, c.Saldo);
        }
    }
}
