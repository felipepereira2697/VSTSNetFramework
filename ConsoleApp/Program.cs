using ConsoleApp.BO;
using ConsoleApp.DAO;
using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            

            Console.WriteLine("*****************************************\n");
            Console.WriteLine("Seja bem vindo(a) ao Pereira CAR\n");
            Console.WriteLine("Selecione a opção desejada\n");
            Console.WriteLine(" 1 - Fabricantes\n 2 - Modelos\n 0 - Sair");
            string op = Console.ReadLine();
            switch(op)
            {

                case "1":
                    Console.WriteLine("Listando os fabricantes...\n");
                    Console.WriteLine("-----------------------------\n");
                    
                    break;
                case "2":
                    
                    ModeloBO modeloBO = new ModeloBO();
                    modeloBO.ListarTodosOsModelosConsole();

                    break;

                case "0":
                    Console.WriteLine("Fechando o sistema...\n");
                    Console.WriteLine("-----------------------------\n");

                    System.Threading.Thread.Sleep(3000);
                    Environment.Exit(-1);
                    break;
            }
            


            //Funcionario

            //1 - Lista de Fabricantes
            //2 - Lista de Modelos
            //3 - Vender um Modelo
            
            //4 - Quantidade de um modelo a partir do Id
            //5 - Verificar se o Fabricante faz parte da nossa rede a partir do nome
            //6 - Adicionar Modelo/Fabricante
            //7 - Verificar as caracteristicas do Modelo, vidro eletrico 
        }
    }
}
