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
                
                return true;
            }

            return false;
        }

        

        public bool VerificaExistenciaModelo(Modelo modelo)
        {
            if(dao.BuscarPorNome(modelo.Nome).Nome.Equals(""))
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
            
            List<Modelo> iguais = todos.FindAll(x => x.Nome.Equals(modelo.Nome));

            if(iguais.Count > 1)
            {
                return true;
            }

            return false;
            
        }

        public void RecolherDadosParaAdicionarModeloViaConsole(FabricanteBO fabBO)
        {
            
            Console.WriteLine("Opa, mais um modelo chegando quentinho para a PereiraCAR\n");
            Console.WriteLine("Digite o nome do modelo\n");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a quantidade de "+nome+"\n");
            string qtd = Console.ReadLine();

            fabBO.ListarTodosOsFabricantesConsole();

            Console.WriteLine("Digite o Id do fabricante desse modelo: \n");
            string idFabricante = Console.ReadLine();
            
            Modelo m = new Modelo { Nome = nome, Quantidade = Convert.ToInt32(qtd), FabricanteId = Convert.ToInt32(idFabricante) };
            if(AdicionarNovoModelo(m))
            {
                Console.WriteLine("Conseguimos adicionar o modelo "+m.Nome+" ao nosso catalogo");
            }
            Console.ReadKey();
        }

        public bool VerificaQuantidadeNegativa(int quantidade)
        {
            if(quantidade < 0 )
            {
                return true;
            }
            return false;
        }

        private bool VerificaDescricao(string descricao)
        {
            //Verificar a quantidade de caracteres na descricao, nao pode passar os 255
           
            if(descricao.Length <= 255 && descricao.Length > 0)
            {
                return true;
            }
            return false;

        }
        public bool AdicionarNovoModelo(Modelo modelo)
        {
            //verificar se o modelo ja existe e se quantidade que será inserida nao é negativa
            bool existe = VerificaExistenciaModelo(modelo);
            bool qtdNegativa = VerificaQuantidadeNegativa(modelo.Quantidade);
            bool limiteDescricao = VerificaDescricao(modelo.Descricao);
            if(existe || qtdNegativa || limiteDescricao==false)
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
