using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Puzzleoito
{
    //LUIZ ARTUR BOING IMHOF 9207
    class Nodo
    {
        public List<Nodo> filhos = new List<Nodo>();
        public Nodo pai;
        public int[] tabuleiro = new int[9];
        public int zeroIndice = 0;
        public int par1 = 0;
        public int par2 = 0;

        public string movimento;//Está aqui para corrigir no futuro, não está funcionando
        
        public Nodo (int[] p)
        {
            IniciaTabuleiro(p);
        }

        public void IniciaTabuleiro(int[] p)
        {
            for (int i = 0; i < tabuleiro.Length; i++)
                this.tabuleiro[i] = p[i];
            

        }

        public void CalculaParametro1(Nodo destino)
        {
            int parametro = 0;
            foreach (int i in this.tabuleiro)
            {
                //Console.WriteLine("parametro 1: i = " + i);
                if (this.tabuleiro[i] == destino.tabuleiro[i])
                    parametro = parametro + 1;
            }
            this.par1 = parametro;

        }

        public void CalculaParametro2(Nodo destino)
        {
            int parametro = 0;
            int aux = 0;


            for (int i = 0; i < tabuleiro.Length; i++)
            {
                int x_final = 0;
                int y_final = 0;

                int x_atual = i % 3;
                int y_atual = i / 3;
                //Console.WriteLine(" i " + i + "  mod 3 = " + x_atual);
                //Console.WriteLine(" i " + i + "  div 3 = " + y_atual);
                aux = this.tabuleiro[i];
                if(aux != 0)
                {
                    int j = 0;
                    bool achou = false;
                    while (!achou)
                    {
                        if (destino.tabuleiro[j] == aux)
                            achou = true;
                        j++;
                    }
                    j = j-1;
                    x_final = j % 3;
                    y_final = j / 3;
                    //Console.WriteLine(" j " +j + "  mod 3 = " + x_final);
                    //Console.WriteLine(" j " + j + "  div 3 = " + y_final);
                    parametro = parametro + (Math.Abs(x_atual - x_final) + (Math.Abs(y_atual - y_final)));
                }

                
                //Console.WriteLine("p2 = " +parametro);

            }
            this.par2 = parametro;
        }


        public void MoverDireita(int[] t, int i)
        {
            if (i % 3 < 2) //se o módulo do indice com o numero de colunas (3) for >=2, pode mover para direita
            {

                this.movimento = "Mover de: " + (i + 1) + " para " + i;
                int[] tabuleiroNovo = new int[9];   
                CopiarTabuleiro(tabuleiroNovo, t);

                int aux = tabuleiroNovo[i + 1];
                tabuleiroNovo[i + 1] = tabuleiroNovo[i];
                tabuleiroNovo[i] = aux;

                Nodo filho = new Nodo(tabuleiroNovo);
                //CALCULAR OS VALORES DO PARÂMETRO AQUI 
                filhos.Add(filho);
                filho.pai = this;

                
               //filho.ImprimirTabuleiro();

            }
        }

        

        public void MoverEsquerda(int[] t, int i)
        {
            if (i % 3 > 0) //se o módulo do indice com o numero de colunas (3) for >0, pode mover para direita
            {
                this.movimento = "Mover de: " + (i-1) + " para " + i;
                int[] tabuleiroNovo = new int[9];
                CopiarTabuleiro(tabuleiroNovo, t);

                int aux = tabuleiroNovo[i - 1];
                tabuleiroNovo[i - 1] = tabuleiroNovo[i];
                tabuleiroNovo[i] = aux;

                Nodo filho = new Nodo(tabuleiroNovo);
                //CALCULAR OS VALORES DO PARÂMETRO AQUI 
                filhos.Add(filho);
                filho.pai = this;

                
                //filho.ImprimirTabuleiro();
            }
        }
        public void MoverBaixo(int[] t, int i)
        {
            if (i + 3 < 9) //Indíces 6,7,8 não podem mover para baixo (ultima linha)
            {
                this.movimento = "Mover de: " + (i + 3) + " para " + i;
                int[] tabuleiroNovo = new int[9];
                CopiarTabuleiro(tabuleiroNovo, t);

                int aux = tabuleiroNovo[i + 3];
                tabuleiroNovo[i + 3] = tabuleiroNovo[i];
                tabuleiroNovo[i] = aux;

                Nodo filho = new Nodo(tabuleiroNovo);
                //CALCULAR OS VALORES DO PARÂMETRO AQUI 
                filhos.Add(filho);
                filho.pai = this;

                

                //filho.ImprimirTabuleiro();
            }
        }
        public void MoverCima(int[] t, int i)
        {
            if (i - 3 >= 0) // indices 0,1,2 não podem ser movidos para cima
            {
                this.movimento = "Mover de: " + (i - 3) + " para " + i;
                int[] tabuleiroNovo = new int[9];
                CopiarTabuleiro(tabuleiroNovo, t);

                int aux = tabuleiroNovo[i - 3];
                tabuleiroNovo[i - 3] = tabuleiroNovo[i];
                tabuleiroNovo[i] = aux;

                Nodo filho = new Nodo(tabuleiroNovo);
                filhos.Add(filho);
                filho.pai = this;

                
                //filho.ImprimirTabuleiro();
            }
        }
       

        public void CopiarTabuleiro(int [] a, int[] b)
        {
            for (int i = 0; i < tabuleiro.Length; i++)
                a[i] = b[i];
        }

        public bool EhDestino(Nodo destino)
        {
            //com For não deu certo
            if ((destino.tabuleiro[0] == this.tabuleiro[0]) &&
                (destino.tabuleiro[1] == this.tabuleiro[1]) &&
                (destino.tabuleiro[2] == this.tabuleiro[2]) &&
                (destino.tabuleiro[3] == this.tabuleiro[3]) &&
                (destino.tabuleiro[4] == this.tabuleiro[4]) &&
                (destino.tabuleiro[5] == this.tabuleiro[5]) &&
                (destino.tabuleiro[6] == this.tabuleiro[6]) &&
                (destino.tabuleiro[7] == this.tabuleiro[7]) &&
                (destino.tabuleiro[8] == this.tabuleiro[8]))
            {
                return true;
            }
            return false;

        }

        public void Mover()
        {
            //checa o indice do zero e tenta realizar todos os movimentos

            for (int i = 0; i < tabuleiro.Length; i++)
            {
                if(tabuleiro[i]==0)
                    zeroIndice = i;
            }

            MoverCima(tabuleiro, zeroIndice);
            MoverBaixo(tabuleiro, zeroIndice);
            MoverEsquerda(tabuleiro, zeroIndice);
            MoverDireita(tabuleiro, zeroIndice);
           
        }

        

        internal void MovimentoToString()
        {
            Console.WriteLine("\n" + movimento);
        }

        public bool EhRepetido (int [] t)
        {
            bool mesmoTabuleiro = true;
            for (int i = 0; i<t.Length; i++)
            {
                if (tabuleiro[i] != t[i])
                {
                    mesmoTabuleiro = false;
                }
            }
            return mesmoTabuleiro;
        }

        public void ImprimirTabuleiro ()
        {
            
            for (int i = 0; i<this.tabuleiro.Length; i++)
            {
                if ((i % 3) == 0){
                    Console.WriteLine("");
                    Console.Write(this.tabuleiro[i] + " ");
                }
                else
                    Console.Write( this.tabuleiro[i] + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Parametro 1 = " + this.par1);
            Console.WriteLine("Parametro 2 = " + this.par2);
        }

        //Parte com heuristica


        public void MoverECalcular(Nodo destino)
        {
            //checa o indice do zero e tenta realizar todos os movimentos

            for (int i = 0; i < tabuleiro.Length; i++)
            {
                if (tabuleiro[i] == 0)
                    zeroIndice = i;
            }

            MoverCima(tabuleiro, zeroIndice, destino);
            MoverBaixo(tabuleiro, zeroIndice, destino);
            MoverEsquerda(tabuleiro, zeroIndice, destino);
            MoverDireita(tabuleiro, zeroIndice, destino);

        }
        public void MoverDireita(int[] t, int i, Nodo destino)
        {
            if (i % 3 < 2) //se o módulo do indice com o numero de colunas (3) for >=2, pode mover para direita
            {

                this.movimento = "Mover de: " + (i + 1) + " para " + i;
                int[] tabuleiroNovo = new int[9];
                CopiarTabuleiro(tabuleiroNovo, t);

                int aux = tabuleiroNovo[i + 1];
                tabuleiroNovo[i + 1] = tabuleiroNovo[i];
                tabuleiroNovo[i] = aux;

                Nodo filho = new Nodo(tabuleiroNovo);
                filho.CalculaParametro1(destino);
                filho.CalculaParametro2(destino);
                
                filhos.Add(filho);

                //filhos = filhos.OrderByDescending(m => m.par2).ThenBy(m => m.par2).ToList();
                filho.pai = this;


                //filho.ImprimirTabuleiro();

            }
        }



        public void MoverEsquerda(int[] t, int i, Nodo destino)
        {
            if (i % 3 > 0) //se o módulo do indice com o numero de colunas (3) for >0, pode mover para direita
            {
                this.movimento = "Mover de: " + (i - 1) + " para " + i;
                int[] tabuleiroNovo = new int[9];
                CopiarTabuleiro(tabuleiroNovo, t);

                int aux = tabuleiroNovo[i - 1];
                tabuleiroNovo[i - 1] = tabuleiroNovo[i];
                tabuleiroNovo[i] = aux;

                Nodo filho = new Nodo(tabuleiroNovo);
                //CALCULAR OS VALORES DO PARÂMETRO AQUI 
                filho.CalculaParametro1(destino);
                filho.CalculaParametro2(destino);

                filhos.Add(filho);

                //filhos = filhos.OrderByDescending(m => m.par2).ThenBy(m => m.par2).ToList();
                filho.pai = this;


                //filho.ImprimirTabuleiro();
            }
        }
        public void MoverBaixo(int[] t, int i, Nodo destino)
        {
            if (i + 3 < 9) //Indíces 6,7,8 não podem mover para baixo (ultima linha)
            {
                this.movimento = "Mover de: " + (i + 3) + " para " + i;
                int[] tabuleiroNovo = new int[9];
                CopiarTabuleiro(tabuleiroNovo, t);

                int aux = tabuleiroNovo[i + 3];
                tabuleiroNovo[i + 3] = tabuleiroNovo[i];
                tabuleiroNovo[i] = aux;

                Nodo filho = new Nodo(tabuleiroNovo);
                //CALCULAR OS VALORES DO PARÂMETRO AQUI 
                filho.CalculaParametro1(destino);
                filho.CalculaParametro2(destino);
                filhos.Add(filho);

                //filhos = filhos.OrderByDescending(m => m.par2).ThenBy(m => m.par2).ToList();
                filho.pai = this;



                //filho.ImprimirTabuleiro();
            }
        }
        public void MoverCima(int[] t, int i, Nodo destino)
        {
            if (i - 3 >= 0) // indices 0,1,2 não podem ser movidos para cima
            {
                this.movimento = "Mover de: " + (i - 3) + " para " + i;
                int[] tabuleiroNovo = new int[9];
                CopiarTabuleiro(tabuleiroNovo, t);

                int aux = tabuleiroNovo[i - 3];
                tabuleiroNovo[i - 3] = tabuleiroNovo[i];
                tabuleiroNovo[i] = aux;

                Nodo filho = new Nodo(tabuleiroNovo);
                filho.CalculaParametro1(destino);
                filho.CalculaParametro2(destino);
                filhos.Add(filho);
                

                //filhos = filhos.OrderByDescending(m => m.par2).ThenBy(m => m.par2).ToList();

                filho.pai = this;


                //filho.ImprimirTabuleiro();
            }
        }
    }



}
