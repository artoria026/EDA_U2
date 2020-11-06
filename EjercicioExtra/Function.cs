using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExtra
{
    class Function
    {
        int dim, avgF, avgC;
        int[,] matriz;
        int[] fil, col;

        public Function()
        {
            DefineMat();
            FillMat();
            PrintMat();
            CalcResults();
            PrintResults();
        }

        private void DefineMat()
        {
            Console.Write("Dimension de la matriz cuadrada: ");
            dim = Utils.ReadInt();
            matriz = new int[dim, dim];
            fil = new int[dim];
            col = new int[dim];
        }

        private void FillMat()
        {
            Console.WriteLine();
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    Console.Write($"Ingrese el valor de la posicion | {i}:{j} |: ");
                    matriz[i, j] = Utils.ReadInt();
                }
                Console.WriteLine();
            }
        }

        private void PrintMat()
        {
            Console.WriteLine("Matriz:");

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    Console.Write($" {matriz[i, j]} ");

                }
                Console.WriteLine();
            }
        }

        private void CalcResults()
        {
            //Filas
            int aux = 0;
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    aux += matriz[i, j];
                }
                fil[i] = aux;
                aux = 0;
            }

            //Columnas
            int aux2 = 0;
            for (int k = 0; k < dim; k++)
            {
                for (int h = 0; h < dim; h++)
                {
                    aux2 += matriz[h, k];
                }
                col[k] = aux2;
                aux2 = 0;
            }
        }

        private void PrintResults()
        {
            Console.WriteLine("\nArreglo suma Filas:");
            foreach (int num in fil)
            {
                Console.Write($" {num} ");
                avgF += num;
            }
            Console.Write($"\nPromedio Filas: {avgF / dim}");
            Console.WriteLine();
            Console.WriteLine("\nArreglo suma Columnas:");
            foreach (int num in col)
            {
                Console.Write($" {num} ");
                avgC += num;
            }
            Console.Write($"\nPromedio Columnas: {avgC / dim}");

            Utils.ShortArray(fil);
            Console.WriteLine();
            Console.WriteLine("\nArreglo filas ordenado: ");
            foreach (int pst in fil) { Console.Write($" {pst} "); }

            Utils.ShortArray(col);
            Console.WriteLine();
            Console.WriteLine("\nArreglo columnas ordenado: ");
            foreach (int pst in col) { Console.Write($" {pst} "); }

            // ???????? 
            Console.Write($"\nPromedio Columnas: {avgC / dim}");
            //No se porque lo imprime dos veces en su ejemplo, pero no vaya a ser y me repruebe por eso...
        }
    }
}
