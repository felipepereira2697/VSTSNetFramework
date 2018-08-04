using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public interface IOperacoesBD
    {
        bool Adicionar(Object o);
        List<Object> Buscar();
        Object BuscarPorNome();
        Object BuscarPorId();
        bool Atualizar(Object o);
    }
}
