using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzleoito
{
    
    //LUIZ ARTUR BOING IMHOF 9207
    class Program
    {
        //Alterar o inicial, para o tabuleiro desejado e o objetivo para o final desejado e então iniciar o programa
       
        public static void Main(string[] args)
        {

            // DEFINIR AQUI O ESTADO INICIAL, O ESTADO DE OBJETIVO E SE USA HEURISTICA OU NÃO
            int[] inicial =
            {
                0,1,3,
                7,6,8,
                2,5,4
            };
            int[] objetivo =
            {
                1,2,3,
                4,5,6,
                7,8,0
            };

             bool usaheuristica = true;



            
            Nodo origem = new Nodo(inicial);
            Console.WriteLine("Tabuleiro inicial: ");
            origem.ImprimirTabuleiro();
            Nodo destino = new Nodo(objetivo);
            Console.WriteLine("Tabuleiro destino: ");

            destino.ImprimirTabuleiro();
            Arvore tree = new Arvore();

            List<Nodo> solucao = tree.BuscaPorNivel(origem, destino, usaheuristica);
            
            if(solucao.Count>0)
            {
                solucao.Reverse();//Para mostrar do início para o final (podia ter feito com o For ao contrario)
                for (int i = 0; i < solucao.Count; i++)
                {
                    
                    solucao[i].ImprimirTabuleiro();
                    //solucao[i].movimentoToString();
                }
            }
            else
            {
                Console.WriteLine("Não encontrado");
            }

            Console.WriteLine("Pressione enter para sair");
            Console.ReadLine();//Não sei como fazer o C# deixar o console aberto antes de finalizar o programa, aí li que dava de fazer isso aqui
            
            /*
            Nodo origem = new Nodo(inicial);
            Console.WriteLine("Tabuleiro inicial: ");
            Nodo destino = new Nodo(objetivo);
            Console.WriteLine("Tabuleiro destino: ");
            destino.CalculaParametro1(destino);
            destino.CalculaParametro2(destino);
            destino.ImprimirTabuleiro();

            origem.CalculaParametro1(destino);
            origem.CalculaParametro2(destino);
            origem.ImprimirTabuleiro();

            Console.WriteLine("Pressione enter para sair");
            Console.ReadLine();
            */
        }
    }
}
