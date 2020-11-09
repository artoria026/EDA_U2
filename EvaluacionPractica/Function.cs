using System;

namespace EvaluacionPractica
{
    class Function
    {
        int[,] matriz = new int[4, 4], matriz_aux = new int[4, 4];
        int[] auxArray = new int[16];

        public Function()
        {
            FillMat();
            WipeArray();
            PrintOriginMath();
            FillSecondMat();
            PrintSecondMath();
            Console.Write($"\nNumero menor: {auxArray[0]}");
            Console.Write($"\nNumero mayor: {auxArray[15]}");
        }

        private void FillMat()
        {
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"Ingrese el valor de la posicion | {i}:{j} |: ");
                    matriz[i, j] = Utils.ReadInt();
                }
                Console.WriteLine();
            }
        }

        private void PrintOriginMath()
        {
            Console.WriteLine("Matriz inicial:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($" {matriz[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private void PrintSecondMath()
        {
            Console.WriteLine("Matriz auxiliar:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($" {matriz_aux[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private void WipeArray()
        {
            int aux = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    auxArray[aux] = matriz[i, j];
                    aux++;
                }
            }
            Utils.ShortArray(auxArray);
        }

        private void FillSecondMat()
        {
            int aux = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matriz_aux[i, j] = auxArray[aux];
                    aux++;
                }
            }
        }
    }
}
