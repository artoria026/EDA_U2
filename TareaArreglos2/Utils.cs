using System;

namespace TareaMatrices2
{
    internal class Utils
    {
        public static int a = 0;
        public static double b = 0.0;


        //Leer un numero entero con TryCatch
        public static int ReadInt()
        {
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Inserte un numero entero...");
                Console.Write("Numero: ");
                ReadInt();
            }
            return a;
        }

        //Leer un numero double con TryCatch
        public static double ReadDouble()
        {
            try
            {
                b = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Inserte un numero valido...");
                Console.Write("Numero: ");
                ReadDouble();
            }
            return b;
        }

        //Pregunta al usuario para repetir un proceso
        public static bool Repeat()
        {
            Console.WriteLine("\n");
            Console.Write("Desea volver a intentarlo? Si/No:  ");
            string opc = Console.ReadLine().ToLower();
            return (opc.CompareTo("si") == 0 || opc.CompareTo("s") == 0) ? true : false;
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
