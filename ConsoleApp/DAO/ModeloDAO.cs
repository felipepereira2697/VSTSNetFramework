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
            if(o != null)
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

        public bool Atualizar(Modelo atualizado)
        {
            try
            {
                using (var context = new PereiraDbContext())
                {

                    Modelo antigo =context.Modelos.Where(m => m.Id == atualizado.Id).First();
                    antigo.Quantidade = atualizado.Quantidade;
                    int salvou = context.SaveChanges();
                    if(salvou > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception )
            {

                throw;
            }
            

            
        }

        public List<Modelo> Buscar()
        {
            List<Modelo> todos = new List<Modelo>();
            using (var context = new PereiraDbContext())
            {
                todos = context.Modelos.ToList();
            }
            return todos;

        }

        public Modelo BuscarPorId(int id)
        {
            using (var context = new PereiraDbContext())
            {
                return context.Modelos.Where(x => x.Id == id).First();
            }
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
                modelo.Nome = "";
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
