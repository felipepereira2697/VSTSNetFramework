using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ConsoleApp.BO;
using ConsoleApp.DAO;
using ConsoleApp.Model;
using ConsoleApp.Persistence;
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
        
        //Fazer teste: NaoDeveDeixarComprarModeloSemFabricante

        [TestMethod]
        public void NaoDevePermitirCompraDeModeloComQuantidadeNegativa()
        {
            Modelo m = new Modelo(1, "Bmw x3", -1);
            Assert.AreEqual(0, m.Quantidade);
        }
        
        [TestMethod]
        public void DeveBuscarTodosOsModelosDeFerrariNoBancoDeDados()
        {
            ModeloDAO dao = new ModeloDAO();
            string nomeFabricante = "FERRARI";
            string nomeFabricanteMinusculo = "ferrari";
            List<Modelo> modelos = dao.BuscarModelosPorNomeFabricante(nomeFabricante);
            List<Modelo> modelosMinusculo = dao.BuscarModelosPorNomeFabricante(nomeFabricanteMinusculo);
            //No minimo deve ter um modelo de ferrari
            Assert.IsTrue(modelos.Count >= 1);
            Assert.IsTrue(modelosMinusculo.Count >= 1);
            Assert.IsTrue(modelosMinusculo.Count == modelos.Count);
        }

        [TestMethod]
        public void DeveVerificarSeOModeloJaExisteNoBancoDeDadosERetornarVerdadeiro()
        {
            ModeloBO bo = new ModeloBO();
            ModeloDAO dao = new ModeloDAO();
            string nomeModelo = "Ferrari Enzo";
            
            bool existe = bo.VerificaExistenciaModelo(dao.BuscarPorNome(nomeModelo));

            Assert.IsTrue(existe);
        }

        //Regras de negócio para o MODELO
        [TestMethod]
        public void DeveVerificarQueNaoTenhaUmMesmoModeloLigadoAFabricantesDiferentes()
        {
            //Ferrari Enzo ligado à Ferrari e Buggati --> NÃO PERMITIDO
            ModeloBO bo = new ModeloBO();
            Modelo m = new Modelo();
            //Deve buscar o modelo no banco de dados e verificar se ele está atrelado a mais de um Fabricante
            bool duplicou = bo.VerificarDuplicidadeModelo(m);

            Assert.IsFalse(duplicou);
        }
        [TestMethod]
        public void NaoDeveSerPossivelAdicionarUmaQuantidadeNegativaDeModelos()
        {
            ModeloDAO dao= new ModeloDAO();

            ModeloBO bo = new ModeloBO();

            Modelo m = dao.BuscarPorNome("Buggati Veyron");

            bool adicionou = bo.AdicionarNovoModelo(dao.BuscarPorNome("Buggati Veyron"));

            Assert.IsFalse(adicionou);


        }
        //Todo modelo deve ter um unico fabricante
        [TestMethod]
        public void DeveRetornarAQuantidadeDeUmModelo()
        {
            ModeloDAO dao = new ModeloDAO();

            int qtd = dao.BuscarQuantidade(dao.BuscarPorNome("BMW Coupe"));

            Assert.IsTrue(qtd == 50);
        }

        [TestMethod]
        public void DeveVerificarAExistenciaDoModeloERetornarFalso()
        {
            ModeloDAO dao = new ModeloDAO();
            Modelo modelo = dao.BuscarPorNome("BMW Coupe Nao Existe");

            ModeloBO bo = new ModeloBO();
            bool retornou = bo.VerificaExistenciaModelo(modelo);

            Assert.IsFalse(retornou);
        }

        [TestMethod]
        public void DeveTrazerTodosOsModelosPorOrdemAlfabetica()
        {
            //Refatorar BO e DAO para que o main chame a BO somente uma linha
            ModeloBO bo  = new ModeloBO();
            ModeloDAO dao = new ModeloDAO();
            //quando vem da dao vem tudo bagunçado
            List<Modelo> todosModelosVindosDiretoDaDAO = dao.Buscar();
            List<Modelo> todosModelosVindosDaBO = bo.BuscarTodosOsModelos();

            bool listasIguais = todosModelosVindosDaBO.SequenceEqual(todosModelosVindosDiretoDaDAO);

            Assert.IsFalse(listasIguais);
        }

        //Pendente de MOCK
        
        [TestMethod]
        public void DeveAtualizarAQuantidadeDeUmModeloSelecionado()
        {
         
            ModeloDAO dao = new ModeloDAO();
            Modelo modelo = dao.BuscarPorNome("Audi RS6");
            //Atual era 17 vai atualizar de verdade
            modelo.Quantidade = 13;
            
            bool atualizou = dao.Atualizar(modelo);
            
            Assert.IsNotNull(atualizou);
        }
        

        [TestMethod]
        public void DeveBuscarOModeloPorId()
        {
            ModeloDAO dao = new ModeloDAO();
            Modelo m = dao.BuscarPorNome("BMW Coupe");
            Modelo resultado = dao.BuscarPorId(m.Id);

            Assert.AreEqual(m.Id, resultado.Id);
        }

        [TestMethod]
        public void DeveAdicionarUmaNovaFerrari()
        {
            Modelo ferrari = new Modelo{ Nome = "Ferrari 2018", FabricanteId = 1, Quantidade = 12 };
            ModeloDAO dao = new ModeloDAO();
            bool retorno = dao.Adicionar(ferrari);

            Assert.IsTrue(retorno);

        }


    }
}
