using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.DAO;
using ConsoleApp.Model;
using ConsoleApp.Persistence;

namespace ConsoleApp.BO
{
    public class ModeloBO
    {
        private ModeloDAO dao;

        public bool VenderModelo(Modelo modelo, int quantidadeVendida)
        {
            if(modelo.Quantidade >= quantidadeVendida)
            {
                modelo.Quantidade -= quantidadeVendida;
                //atualiza o modelo dao.AtualizarQuantidadeModelo(modelo, quantidade);
                return true;
            }

            return false;
        }

        public List<Modelo> BuscarModelosPorNomeFabricante(string nomeFabricante)
        {
            nomeFabricante = nomeFabricante.ToUpper();
            List<Modelo> modelos = new List<Modelo>();
            using (var context = new PereiraDbContext())
            {
                modelos = context.Modelos.Where(x => x.Fabricante.Nome.Equals(nomeFabricante)).ToList();
            }

            return modelos;
        }

        public bool VerificaExistenciaModelo(string nomeModelo)
        {
            if(BuscarModeloPorNome(nomeModelo) == null)
            {
                return false;
            }
            return true;
        }

        

        public Modelo BuscarModeloPorNome(string nomeModelo)
        {
            Modelo modelo = new Modelo();
            using (var context = new PereiraDbContext())
            {
                modelo = context.Modelos.Where(m => m.Nome.Equals(nomeModelo)).FirstOrDefault();
            }

            return modelo;
        }

        public List<Modelo> BuscarTodosOsModelos()
        {
            List<Modelo> todos = new List<Modelo>();
            using (var context = new PereiraDbContext())
            {
                todos = context.Modelos.ToList();
            }

            return todos;
        }

        public bool VerificarDuplicidadeModelo(Modelo modelo)
        {
            List<Modelo> todos = BuscarTodosOsModelos();
            List<Modelo> iguais = new List<Modelo>();
            
            iguais = todos.FindAll(x => x.Nome.Equals(modelo.Nome));

            if(iguais.Count > 1)
            {
                return true;
            }

            return false;
            
        }

        public bool VerificaQuantidadeNegativa(int quantidade)
        {
            if(quantidade < 0 )
            {
                return false;
            }
            return true;
        }
        public bool AdicionarNovoModelo(Modelo modelo)
        {
            //verificar se o modelo ja existe e se quantidade que será inserida nao é negativa
            bool existe = VerificaExistenciaModelo(modelo.Nome);
            bool qtdNegativa = VerificaQuantidadeNegativa(modelo.Quantidade);

            if(existe || qtdNegativa)
            {
                return false;
            }

            return dao.Adicionar(modelo);
            
        }
    }
}
