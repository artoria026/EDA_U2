using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace EjercicioArreglos2
{
    class TIC
    {
        static string[] names = new string[3];
        static int[] age = new int[3];
        static char[] generes = new char[3];
        static bool[] titles = new bool[3];
        static double avg;
        int ttqf;


        public TIC()
        {
            Console.WriteLine("\nTecnolgias de la informacion");
            DefineClass();
        }

        private void DefineClass()
        {
            Definettqf();
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write("\nIngrese el nombre del profesor: ");
                names[i] = Console.ReadLine();
                Console.Write("Ingrese la edad del profesor: ");
                age[i] = Utils.ReadInt();
                generes[i] = DefineGender();
                titles[i] = DefineTitle();
            }
            Printtqf();
        }

        private void Definettqf()
        {
            Console.WriteLine("\n1-Ingenieria \n2-TSU \n3-Ambas");
            ttqf = Utils.ReadInt();
            if (ttqf != 1 && ttqf != 2 && ttqf != 3) Definettqf();
        }

        private char DefineGender()
        {
            char lt = 'H';
            string pattern = @"\d+", aux;
            Regex defaultRegex = new Regex(pattern);

            Console.Write("Ingrese el genero del profesor H/M: ");
            aux = Console.ReadLine().ToUpper();
            if (String.IsNullOrEmpty(aux) || Regex.IsMatch(aux, pattern) || aux.Contains(" ") || aux.Length > 1 || aux != "M" && aux != "H")
            {
                Console.WriteLine("Genero invalido!!!");
                DefineGender();
            }
            else
            {
                lt = char.Parse(aux);
            }
            return lt;
        }

        private bool DefineTitle()
        {
            bool flag = false;

            string pattern = @"\d+", aux;
            Regex defaultRegex = new Regex(pattern);

            Console.Write("Titulo?: Si/No: ");
            aux = Console.ReadLine().ToUpper();
            if (String.IsNullOrEmpty(aux) || Regex.IsMatch(aux, pattern) || aux.Contains(" ") || aux != "SI" && aux != "NO")
            {
                Console.WriteLine("Opcion invalida");
                DefineTitle();
            }
            else
            {
                if (aux == "SI") flag = true;
                else flag = false;
            }
            return flag;
        }

        public static double AgeAvg()
        {
            double aux = 0;
            for (int i = 0; i < age.Length; i++)
            {
                aux += age[i];
            }
            avg = aux / age.Length;
            return avg;
        }

        public static String MYT()
        {
            String name;
            int aux = age[0];
            int aux_p = 0;
            for (int i = 0; i < age.Length; i++)
            {
                if (age[i] < aux)
                {
                    aux = age[i];
                    aux_p = i;
                }
            }
            name = names[aux_p];
            return name;
        }

        public static int MTA()
        {
            int cont = 0;
            for (int i = 0; i < age.Length; i++)
            {
                if (age[i] < avg)
                {
                    cont++;
                }
            }
            return cont;
        }

        public static int TotalW()
        {
            int m = 0;
            for (int i = 0; i < generes.Length; i++)
            {
                if (generes[i] == 'M')
                    m++;
            }
            return m;
        }

        public static int TotalT()
        {
            int aux = 0;
            for (int i = 0; i < titles.Length; i++)
            {
                if (titles[i])
                    aux++;
            }
            return aux;
        }

        private void Printtqf()
        {
            switch (ttqf)
            {
                case 1:
                    Console.WriteLine("Ingenieria");
                    break;
                case 2:
                    Console.WriteLine("TSU");
                    break;
                case 3:
                    Console.WriteLine("Ambas");
                    break;
                default:
                    Console.WriteLine("Nada");
                    break;
            }
        }
    }
}
