using ConsoleApp.Model;
using ConsoleApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public class ModeloDAO : IOperacoesBD<Modelo>
    {
        public ModeloDAO()
        {

        }
        //CRUD da classe Modelo
        public bool Adicionar(Modelo o)
        {
            if(o == null)
            {
                using (var context = new PereiraDbContext())
                {
                    context.Modelos.Add(o);
                    //realizar o commit no bd
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool Atualizar(Modelo o)
        {
            throw new NotImplementedException();
            //context.SaveChanges();
        }

        public List<Modelo> Buscar()
        {
            throw new NotImplementedException();
        }

        public Modelo BuscarPorId()
        {
            throw new NotImplementedException();
        }

        public Modelo BuscarPorNome(string nome)
        {
            Modelo modelo = new Modelo();
            using (var context = new PereiraDbContext())
            {
                modelo = context.Modelos.Where(m => m.Nome.Equals(nome)).FirstOrDefault();
            }
            if(modelo == null)
            {
                Modelo m = new Modelo();
                m.Nome = "";
                return m;
            }
            return modelo;
        }

        public int BuscarQuantidade(Modelo m)
        {
            int  quantidade = 0;
            using (var context = new PereiraDbContext())
            {
                quantidade = context.Modelos.Where(x => x.Nome.Equals(m.Nome)).Select(q => q.Quantidade).First();
            }

            return quantidade;
        }
    }
}
