using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzleoito
{
    //LUIZ ARTUR BOING IMHOF 9207
    class Arvore  // Não é necessariamente uma árvore, mas ta valendo, basicamente só faz a busca por largura
    {
        public Arvore()
        {

        }

        public List<Nodo> BuscaPorNivel (Nodo raiz, Nodo objetivo, bool heuristica)
        {

            raiz.CalculaParametro1(objetivo);
            raiz.CalculaParametro2(objetivo);
            Console.WriteLine("Buscando a Solução (Pode levar alguns Minutos) \n");
            List<Nodo> caminho = new List<Nodo>();
            if (raiz.EhDestino(objetivo))
            {
                Console.WriteLine("Já é destino");
            }
            else
            {

                bool destinoEncontrado = false;

                List<Nodo> abertos = new List<Nodo>();
                List<Nodo> fechados = new List<Nodo>();

                abertos.Add(raiz);

                while (abertos.Count > 0 && !destinoEncontrado)
                {

                    Nodo atual = abertos[0];
                    fechados.Add(atual);
                    abertos.RemoveAt(0);
                    if (heuristica)
                        atual.MoverECalcular(objetivo);
                    else
                        atual.Mover();

                    for (int i = 0; i < atual.filhos.Count; i++)
                    {

                        Nodo filhoAtual = atual.filhos[i];
                        if (filhoAtual.EhDestino(objetivo))
                        {

                            destinoEncontrado = true;
                            BuscaCaminho(caminho, filhoAtual);
                            Console.WriteLine("Destino encontrado");
                        }
                        if (!Contem(abertos, filhoAtual) && !Contem(fechados, filhoAtual))
                        {
                            abertos.Add(filhoAtual);
                            abertos = abertos.OrderBy(m => m.par2).ToList();
                            // this.ordena(abertos);
                            //this.ordena(fechados);
                            //filhoAtual.ImprimirTabuleiro();
                        }
                    }

                }


            }            return caminho;
        }

        private void ordena(List<Nodo> abertos)
        {
            Comparador comparador = new Comparador();

            abertos.Sort(comparador);
        }

        public static bool Contem(List<Nodo> lista, Nodo t)
        {
            bool contem = false;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].EhRepetido(t.tabuleiro))
                    contem = true;
            }
            return contem;
        }


        public void BuscaCaminho (List<Nodo> caminho, Nodo n)
        {
            Nodo atual = n;
            caminho.Add(atual);

            while (atual.pai != null)
            {
                atual = atual.pai;
                caminho.Add(atual);
            }
        }

        
    }
}
