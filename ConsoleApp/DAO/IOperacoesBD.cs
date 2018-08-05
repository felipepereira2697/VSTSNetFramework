using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    //Interface genérica para a implementação dos Cruds
    public interface IOperacoesBD<T>
    {
        bool Adicionar(T o);
        List<T> Buscar();
        T BuscarPorNome(string nome);
        T BuscarPorId();
        bool Atualizar(T o);
    }
}
