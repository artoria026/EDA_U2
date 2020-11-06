using System;
using System.Text.RegularExpressions;

namespace TareaArreglos1
{
    class Function
    {
        int[] letras = new int[10];
        char a;
        char[] match;
        string word_vali;
        int contP = 0;

        public Function()
        {
            FillMat();
            SearchWord();
        }

        private void FillMat()
        {
            Console.WriteLine("Ingrese el 10 letras");
            for (int i = 0; i < letras.Length; i++)
            {
                Console.Write($"Letra {i + 1}: ");
                CharacterCheck();
                letras[i] = a;
            }
            Console.WriteLine();
            foreach (char lt in letras) { Console.Write(lt + " | "); }
        }

        private bool CharacterCheck()
        {
            bool flag = false;
            string pattern = @"\d+", aux;
            Regex defaultRegex = new Regex(pattern);

            aux = Console.ReadLine().ToUpper();
            if (String.IsNullOrEmpty(aux) || Regex.IsMatch(aux, pattern) || aux.Contains(" ") || aux.Length > 1)
            {
                Console.Write("\nLetra invalida, ingrese una sola letra: ");
                CharacterCheck();
            }
            else
            {
                flag = true;
                a = char.Parse(aux);
            }
            return flag;
        }

        private bool WordCheck()
        {
            bool flag = false;
            string pattern = @"\d+";
            Regex defaultRegex = new Regex(pattern);

            Console.Write("\nPalabra a buscar: ");
            word_vali = Console.ReadLine().ToUpper();
            if (String.IsNullOrEmpty(word_vali) || Regex.IsMatch(word_vali, pattern) || word_vali.Contains(" "))
            {
                Console.WriteLine("Tiene que ingresar una palabra, sin numeros o espacios en blanco");
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                WordCheck();
            }
            else
            {
                flag = true;
                match = word_vali.ToCharArray();
            }
            return flag;
        }

        private void SearchWord()
        {
            contP++;
            WordCheck();
            int match_count = 0;
            for (int i = 0; i < letras.Length; i++)
            {
                for (int j = 0; j < match.Length; j++)
                {
                    if (match[j] == letras[i])
                    {
                        match_count++;
                    }
                }
            }
            if (match_count == match.Length)
            {
                Console.WriteLine($"La palabra {word_vali} ha sido encontrada");
            }
            else
            {
                Console.WriteLine($"La palabra {word_vali} no ha sido encontrada");
            }
            if (Utils.Repeat())
            {
                SearchWord();
            }
            else
            { Console.WriteLine($"\nTotal de palabras buscadas: {contP}"); }
        }
    }
}
