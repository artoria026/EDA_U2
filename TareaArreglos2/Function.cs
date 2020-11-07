using System;

namespace TareaArreglos2
{
    class Function
    {
        int x, y, top, bot, contP = 0;
        int[,] matriz;
        int[] fil, prim;

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
            Console.WriteLine("Ingrese el tamaño de la matriz");
            Console.Write("Filas: ");
            x = Utils.ReadInt();
            Console.Write("Columnas: ");
            y = Utils.ReadInt();
            matriz = new int[x, y];
            fil = new int[x];
        }

        private void FillMat()
        {
            Console.WriteLine();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
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
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
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
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    aux += matriz[i, j];
                    if (Utils.PrimoCheck(matriz[i, j])) contP++;
                }
                fil[i] = aux;
                aux = 0;
            }

            int auxT = fil[0];
            int auxB = fil[0];
            for (int i = 0; i < fil.Length; i++)
            {
                if (auxT < fil[i])
                {
                    auxT = fil[i];
                    top = i;
                }
                if (auxB > fil[i])
                {
                    auxB = fil[i];
                    bot = i;
                }
            }
            CalcPrim();
        }

        private void CalcPrim()
        {
            int aux = 0;
            prim = new int[contP];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Utils.PrimoCheck(matriz[i, j]))
                    {
                        prim[aux] = matriz[i, j];
                        aux++;
                    }
                }
            }
        }

        private void PrintResults()
        {
            Console.WriteLine("\nArreglo con sumas:");
            foreach (int num in fil) { Console.Write($" {num} "); }
            Console.Write($"\nFila con mayor sumatoria: {top + 1}");
            Console.Write($"\nFila con menor sumatoria: {bot + 1}");
            Console.WriteLine("\nNúmeros primos en la matriz:");
            foreach (int p in prim) { Console.Write($" {p} "); }
            Console.Write($"\nCantidad de número primos en la matriz: {contP}");
        }
    }
}
