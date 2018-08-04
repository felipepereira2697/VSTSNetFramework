using ConsoleApp.Model;
using ConsoleApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public class ModeloDAO : IOperacoesBD
    {
        public ModeloDAO()
        {

        }
        //CRUD da classe Modelo
        public bool Adicionar(object o)
        {
            if(o == null)
            {
                using (var context = new PereiraDbContext())
                {
                    context.Modelos.Add((Modelo)o);
                    return true;
                }
            }
            return false;
        }

        public bool Atualizar(object o)
        {
            throw new NotImplementedException();
        }

        public List<object> Buscar()
        {
            throw new NotImplementedException();
        }

        public object BuscarPorId()
        {
            throw new NotImplementedException();
        }

        public object BuscarPorNome()
        {
            throw new NotImplementedException();
        }
    }
}
