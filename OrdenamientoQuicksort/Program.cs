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
            // stopwatch.Stop();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            burbuja(vector);
            stopwatch.Stop();
            //   mostrar(vector);

            Console.WriteLine("El tiempo de ejecución fue: " + stopwatch.ElapsedMilliseconds + "[ms]");


        }

        public static void mostrar(int [] v)
        {
            for(int i=0; i < v.Length;i++)
            {
                Console.Write(" {0} ", v[i]);
            }
            Console.WriteLine("\n************************************************");
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
