using System;

namespace EjercicioMatrices2
{
    class Function
    {
        int dim;
        int[,] matriz;
        int[] diagonal1, diagonal2;

        public Function()
        {
            DefinelMat();
            FillMat();
            PrintMat();
            PrintResults();
        }

        private void DefinelMat()
        {
            Console.Write("Dimension de la matriz: ");
            dim = Utils.ReadInt();
            matriz = new int[dim, dim];
            diagonal1 = new int[dim];
            diagonal2 = new int[dim];
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
                SumDiag1();
                SumDiag2();
            }
        }

        private void PrintMat()
        {
            Console.WriteLine("Matriz");

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    Console.Write($" {matriz[i, j]} ");

                }
                Console.WriteLine();
            }
        }

        private void SumDiag1()
        {
            int aux = 0;

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    if (i == j)
                    {
                        diagonal1[aux] = matriz[i, j];
                        aux++;
                    }
                }
            }

        }

        private void SumDiag2()
        {
            int aux = 0;

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    if (j + i == dim - 1)
                    {
                        diagonal2[aux] = matriz[i, j];
                        aux++;
                    }
                }
            }

        }

        private void PrintResults()
        {
            int aux = 0;
            Console.WriteLine("\nDiagonal 1:");
            foreach (int nums in diagonal1)
            {
                Console.Write($" {nums} ");
                aux += nums;
            }

            Console.WriteLine("\nDiagonal 2:");
            foreach (int nums in diagonal2)
            {
                Console.Write($" {nums} ");
                aux += nums;
            }

            Console.Write($"\nPromedio de las dos diagonales: {aux / (dim * 2)}");
        }

    }
}
