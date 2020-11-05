using System;

namespace EjercicioMatrices1
{
    class Function
    {
        int x, y, num, cont = 0;
        private int[,] matriz;
        private string[] match;

        public Function()
        {
            DefineMat();
            FillMat();
            PrintMat();
            SearchNumber();
        }

        private void DefineMat()
        {
            Console.WriteLine("Ingrese el tamaño de la matriz");
            Console.Write("Eje X: ");
            x = Utils.ReadInt();
            Console.Write("Eje Y: ");
            y = Utils.ReadInt();
            matriz = new int[x, y];
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
            Console.WriteLine("Matriz llenada por el usuario:");

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write($" {matriz[i, j]} ");

                }
                Console.WriteLine();
            }
        }

        private void SearchNumber()
        {
            Console.Write("\nIngrese el numero a buscar: ");
            num = Utils.ReadInt();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (num == matriz[i, j])
                    {
                        cont++;
                    }
                }

            }

            if (cont != 0)
            {
                int ttl = cont;
                cont = 0;
                Console.WriteLine($"El numero {num} ha sido encontrado");
                Console.WriteLine($"El numero {num} se encuentra {ttl} veces en la matriz");
                match = new string[ttl];

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (num == matriz[i, j])
                        {
                            match[cont] = i + "," + j;
                            cont++;
                        }
                    }
                }
                Console.Write("Posiciones en las que se encuentra: ");
                foreach (string matches in match)
                {
                    Console.Write($" [{matches}] ");
                }
                Console.Write($"\nLa suma de los numeros repetidos es: {ttl * num}");
            }
            else
            {
                Console.WriteLine($"EL numero {num} no se encuentra en la matriz");
            }


        }
    }
}
