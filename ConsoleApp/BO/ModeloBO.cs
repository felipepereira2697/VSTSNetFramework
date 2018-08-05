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
        private ModeloDAO dao = new ModeloDAO();

        public ModeloBO()
        {
            
        }
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
            if(dao.BuscarPorNome(nomeModelo).Nome.Equals(""))
            {
                return false;
            }
            return true;
        }

        public List<Modelo> BuscarTodosOsModelos()
        {
            return dao.Buscar().OrderBy(x => x.Nome).ToList();
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

        public void ListarTodosOsModelosConsole()
        {
            List<Modelo> modelos = BuscarTodosOsModelos();
            Console.WriteLine("Listando todos os modelos disponiveis");
            Console.WriteLine("-------------------------------------------------\n");
            foreach (var item in modelos)
            {
                Console.WriteLine($"Nome: {item.Nome} \n\t Quantidade: {item.Quantidade} unidades\n ");
            }
            Console.ReadKey();
        }
    }
}
