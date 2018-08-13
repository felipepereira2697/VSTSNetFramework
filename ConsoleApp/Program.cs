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
            Console.WriteLine(" 1 - Lista de fabricantes\n 2 - Lista de modelos\n 3 - Lista de funcionarios\n" +
                " 4 - Adicionar um novo funcionário\n 5 - Adicionar um novo modelo\n 0 - Sair");
            string op = Console.ReadLine();
            FuncionarioBO funcBO = new FuncionarioBO();
            ModeloBO modeloBO = new ModeloBO();
            FabricanteBO bo = new FabricanteBO();
            switch (op)
            {

                case "1":
                    bo.ListarTodosOsFabricantesConsole();
                    break;
                case "2":
                    modeloBO.ListarTodosOsModelosConsole();
                    break;

                case "3":   
                    funcBO.ListarTodosOsFuncionariosConsole();
                    break;

                case "4":
                    funcBO.RecolherDadosConsole();
                    break;

                case "5":
                    modeloBO.RecolherDadosParaAdicionarModeloViaConsole();
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
