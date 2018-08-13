using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.DAO;
using ConsoleApp.Model;

namespace ConsoleApp.BO
{
    public class FabricanteBO
    {
        private FabricanteDAO dao = new FabricanteDAO();
        //Toda regra de negócio da Fabricante aqui
        public List<Fabricante> BuscarTodos()
        {
            return dao.Buscar().OrderBy(x => x.Nome).ToList();
        }

        public void ListarTodosOsFabricantesConsole()
        {
            Console.WriteLine("Listando os fabricantes...\n");
            Console.WriteLine("-----------------------------\n");
            List<Fabricante> fabricantes = BuscarTodos();
            foreach (var item in fabricantes)
            {
                Console.WriteLine($"Id: {item.Id} \n\t Nome: {item.Nome}\n ");
            }
            Console.ReadKey();
        }

        public bool VerificarExistenciaFabricante(Fabricante f)
        {
            List<Fabricante> fabricantes = BuscarTodos();
            Fabricante existente = fabricantes.Where(x => x.Nome.Equals(f.Nome)).FirstOrDefault();
            if(existente == null)
            {
                return true;
            }
            return false;
        }
        public bool AdicionarNovoFabricante(Fabricante f)
        {
            //checar se ja nao existe
            if(VerificarExistenciaFabricante(f))
            {
                f.Nome = f.Nome.ToUpper();
                return dao.Adicionar(f);

            }
            return false;
        }
    }
}
