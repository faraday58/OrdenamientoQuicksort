using System;
using System.Diagnostics;
namespace OrdenamientoQuicksort
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Ingresa el tamaño");
            int Tamaño=int.Parse( Console.ReadLine());
            Random random = new Random();
            byte [] buffer = new byte[Tamaño];
            random.NextBytes(buffer);
            int[] vector = new int[Tamaño];
            for(int i=0;i < vector.Length;i++)
            {
                vector[i] = buffer[i];
            }


            //    mostrar(vector);
            // Stopwatch stopwatch = new Stopwatch();
            // stopwatch.Start();
            //quicksort(vector, 0, vector.Length - 1);
            //// stopwatch.Stop();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            burbuja(vector);
            stopwatch.Stop();
             mostrar(vector);

            Console.WriteLine("El tiempo de ejecución fue: " + stopwatch.ElapsedMilliseconds + "[ms]");

            Console.WriteLine("Ingresa el número a buscar ");
            int X = int.Parse(Console.ReadLine());

            int indice = Binario(vector, X);

            if (indice != -1)
                Console.WriteLine(" El valor fue encontrado en la posición :" + indice);
            else
            {
                Console.WriteLine("Valor no encontrado");
            }


        }

        public static void mostrar(int [] v)
        {
            for(int i=0; i < v.Length;i++)
            {
                Console.Write(" {0} ", v[i]);
            }
            Console.WriteLine("\n************************************************");
        }


        public static int Binario(int[] V, int X)
        {
            int izq;
            int der;
            int centro;
            bool exito=false;

            izq = 0;
            der = V.Length - 1;
            centro = (izq + der) / 2;

            while (izq <= der && !exito )
            {
                
                if(V[centro] == X)
                {
                    exito = true;
                }
                else
                {
                    if( X > V[centro] )
                    {
                        izq = centro + 1;
                    }
                    else
                    {
                        der = centro - 1;
                    }

                }
                centro = (izq + der) / 2;
            }
            if (exito)
            {
                return centro;
            }
            else
            {
                centro = -1;
                return centro;
            }
        }


        public static void burbuja(int [] vector)
        {
            int aux = 0;
            for(int i=0; i < vector.Length; i++)
            {
                for(int j=0; j < vector.Length-1; j++)
                {
                    if(vector[j] > vector[j+1])
                    {
                        aux = vector[j];
                        vector[j] = vector[j+1];
                        vector[j+1] = aux;
                    }
                }
            }
        }


        public static void quicksort(int[] vector, int primero, int ultimo)
        {
            int i; //Contador
            int j; //Contador
            int central; //índice Central
            int pivote;
            central = (primero + ultimo) / 2;
            pivote = vector[central];
            i = primero;
            j = ultimo;

            do
            {

                while (vector[i] < pivote) i++;
                while (vector[j] > pivote) j--;

                if(i <= j )
                {
                    int temp = vector[i];
                    vector[i] = vector[j];
                    vector[j] = temp;
                    i++;
                    j--;
                }

            } while (i <= j);

            if( primero < j)
            {
                quicksort(vector, primero, j);
            }
            if(i < ultimo)
            {
                quicksort(vector, i, ultimo);
            }

        }
    }
}
