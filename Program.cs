using System;

namespace Aplicacion1
{
    class Burbuja
    {
        private int[] vector = new int[8];
        public Burbuja(int[] vector)
        {
            this.vector = vector;
        }

        public int[] solucionMetodoBurbuja()
        {
            bool permutacion = true;
            int temporal, tope = 0, tamano = vector.Length;

            while (permutacion == true)
            {
                permutacion = false;
                tope++;
                for (int i = 0; i < tamano - tope; i++)
                {
                    if (vector[i] > vector[i + 1])
                    {
                        permutacion = true;
                        temporal = vector[i];
                        vector[i] = vector[i + 1];
                        vector[i + 1] = temporal;
                    }
                }
            }

            return vector;
        }

        public void imprimirVectorOrdenado(int[] vector)
        {
            foreach(int i in vector)
            {
                Console.WriteLine(i + " ");
            }
        }
    }

    class BusquedaBinaria
    {
        public int solucionBusquedaBinaria(int[] vector, int posicionInicial, int posicionFinal, int buscarNumero)
        {
            int posicion;

            while (posicionInicial <= posicionFinal)
            {
                posicion = (posicionInicial + posicionFinal) / 2;

                if (vector[posicion] == buscarNumero)
                {
                    return posicion;
                }
                else if (vector[posicion] < buscarNumero)
                {
                    posicionInicial = posicion + 1;
                }
                else
                {
                    posicionFinal = posicion - 1;
                }
            }

            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args) 
        {
            Random rand = new Random();
            int tamanoVector = rand.Next(20, 100);
            Console.WriteLine("El tamaño del vector fue de: " + tamanoVector);
            int[] vector = new int[tamanoVector];
            int[] vectorQick = new int[tamanoVector];
            int[] vectorCouting = new int[tamanoVector];
            int numero, buscarNumero, numeroAleatorio;

            for(int i=0; i < vector.Length; i++)
            {
                numeroAleatorio = rand.Next(1, 200);
                vector[i] = numeroAleatorio;
                vectorQick[i] = numeroAleatorio;
                vectorCouting[i] = numeroAleatorio;
            }

            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine(vector[i] + " ");
            }

            Console.WriteLine("Ejecutando el metodo burbuja");
            Burbuja burbuja = new Burbuja(vector);
            burbuja.solucionMetodoBurbuja();
            burbuja.imprimirVectorOrdenado(vector);

            Console.WriteLine("Ingrese el numero que va buscar: ");
            numero = int.Parse(Console.ReadLine());
            BusquedaBinaria busquedaBinaria = new BusquedaBinaria();
            buscarNumero = busquedaBinaria.solucionBusquedaBinaria(vector, 0, (vector.Length - 1), numero);
            Console.WriteLine(buscarNumero);
        }
    }
}
