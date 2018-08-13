using ConsoleApp.Model;
using ConsoleApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public class FabricanteDAO : IOperacoesBD<Fabricante>
    {
        public bool Adicionar(Fabricante o)
        {
            using (var context = new PereiraDbContext())
            {
                context.Fabricantes.Add(o);
                int salvou = context.SaveChanges();
                if(salvou > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool Atualizar(Fabricante o)
        {
            throw new NotImplementedException();
        }

        public List<Fabricante> Buscar()
        {
            using (var context = new PereiraDbContext())
            {
                return context.Fabricantes.ToList();
            }
        }

        public Fabricante BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Fabricante BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
