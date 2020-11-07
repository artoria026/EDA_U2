using System;

namespace TareaMatrices4
{
    internal class Utils
    {
        public static int a = 0;
        public static double b = 0.0;

        //Ingresar un numero entero
        public static int ReadInt()
        {
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Inserte un numero valido...");
                ReadInt();
            }
            return a;
        }

        //Preguntar si se desea continuar con la operacion
        public static bool Repeat()
        {
            Console.WriteLine();
            Console.Write("Desea volver a intentarlo? Si/No:  ");
            string opc = Console.ReadLine().ToLower();
            return (opc.CompareTo("si") == 0 || opc.CompareTo("s") == 0) ? true : false;
        }

        //Envia un mensaje a pantalla
        public static void WrongOption()
        {
            Console.Write("Fallo, pulse cualquier tecla para contnuar...");
            Console.ReadKey();
        }

        //Mensaje de salida
        public static void endProgram()
        {
            Console.WriteLine("\n");
            Console.Write("Presione cualquier tecla para salir");
            Console.ReadKey();
        }

        public static int[] ShortArray(int[] array)
        {
            int aux, aux2;

            for (int i = 0; i < array.Length; i++)
            {
                aux = array[i];
                aux2 = i - 1;

                while (aux2 >= 0 && array[aux2] < aux)
                {
                    array[aux2 + 1] = array[aux2];
                    aux2--;
                }
                array[aux2 + 1] = aux;
            }
            return array;
        }

        public static bool PrimoCheck(int num)
        {
            if (num == 1)
            {
                return false;
            }
            else
            {
                int div = 2;
                int rest = 0;
                while (div < num)
                {
                    rest = num % div;
                    if (rest == 0)
                    {
                        return false;
                    }
                    div = div + 1;
                }
                return true;
            }
        }
    }
}
