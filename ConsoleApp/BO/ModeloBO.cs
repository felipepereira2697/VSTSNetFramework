using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Model;
using ConsoleApp.Persistence;

namespace ConsoleApp.BO
{
    public class ModeloBO
    {
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

        public List<Modelo> BuscarModeloPorNome(string nomeFabricante)
        {
            nomeFabricante = nomeFabricante.ToUpper();
            List<Modelo> modelos = new List<Modelo>();
            using (var context = new PereiraDbContext())
            {
                modelos = context.Modelos.Where(x => x.Fabricante.Nome.Equals(nomeFabricante)).ToList();
            }

            return modelos;
        }
    }
}
