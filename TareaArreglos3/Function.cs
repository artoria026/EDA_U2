using System;
using System.Text.RegularExpressions;

namespace TareaArreglos3
{
    class Function
    {
        int a, b = 0, attempt = 0;
        string word, word_vali;
        char char_vali;
        char[] chars, box, match;

        //Constructor
        public Function()
        {
        StartGame:
            b++;
            attempt = 0;
            Console.Clear();
            Console.WriteLine("JUEGO DEL AHORCADO");
            Console.WriteLine();
            WordArray();

            ResetBox();
            ShowBox();
            while (GameCheck())
            {
                Option();

            }

            if (Utils.Repeat())
            {
                goto StartGame;
            }
            Console.WriteLine();
            Console.WriteLine("Fin del juego");
            Console.WriteLine($"Numero de veces jugadas: {b}");
        }

        //Funciones
        //Reinicia ele stado del array usado para mostrar las palabras encontradas y la dimension del array
        private void ResetBox()
        {
            box = new char[chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                box[i] = '_';
            }
        }

        //Captura la palabra a buscar en una variable tipo string
        private void WordCapture()
        {
            Console.WriteLine("Jugador 1:");
            Console.Write("Ingrese la palabra que se va a adivinar: ");
            word = Console.ReadLine();
        }

        //Convierte la palabra ingresada en un array de tipo char, mostrandolo en la pantalla
        private void WordArray()
        {
            word = ValidateWord().ToUpper();
            chars = word.ToCharArray();

            Console.Write("La palabra que se va a buscar es:  ");
            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write($" {chars[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        //Switch para seleccionar si ingresar una palabra o una letra unica
        private void Option()
        {
            int opc;
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("1 - Ingresar una letra");
            Console.WriteLine("2 - Ingresar una palabra");
            opc = Utils.ReadInt();
            match = new char[chars.Length];

            switch (opc)
            {
                case 1:
                    CharacterCheck();
                    CompareChar();
                    break;
                case 2:
                    WordCheck();
                    CompareArray();
                    break;
                default:
                    Option();
                    break;

            }
        }

        //Recorre dos o mas arreglos para verificar si la palabra o caracter ingresado son los correctos
        private void CompareArray()
        {
            int aux = 0;
            if (chars.Length != match.Length)
            {
                attempt++;
                Utils.WrongOption();
            }
            else
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (chars[i] == match[i])
                    {
                        aux++;
                    }
                }
                if (aux == chars.Length)
                {
                    for (int i = 0; i < chars.Length; i++)
                    {
                        box[i] = chars[i];
                    }

                }
                else
                {
                    attempt++;
                    Utils.WrongOption();
                }
            }
            ShowBox();
        }

        //Valida que los los intentos y los dos arrays a mostrar
        private void CompareChar()
        {
            bool flag2 = true;

            for (int i = 0; i < chars.Length; i++)
            {
                if (char_vali == chars[i])
                {
                    box[i] = char_vali;
                    flag2 = false;
                }
            }
            if (flag2)
            {
                attempt++;
                Utils.WrongOption();
            }
            ShowBox();
        }

        //Checks
        //Revisar si se cumplieron los intentos o si los arrays son iguales (adivino la palabra)
        private bool GameCheck()
        {
            bool flag = true;
            int aux = 0;

            Console.WriteLine();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == box[i])
                {
                    aux++;
                }
                if (aux == chars.Length)
                {
                    flag = false;
                    ShowBox();
                    Console.WriteLine("Ha ganado!!!");
                }
                if (attempt == 5)
                {
                    flag = false;
                    ShowBox();
                    Console.WriteLine("Ha perdido!!!");
                }
            }
            return flag;
        }

        //Verifica que solo se haya introducido una letra, sin numeros o espacios en blanco
        private bool CharacterCheck()
        {
            bool flag = false;
            string pattern = @"\d+", aux;
            Regex defaultRegex = new Regex(pattern);

            Console.WriteLine("Ingresa una letra");
            aux = Console.ReadLine().ToUpper();
            if (String.IsNullOrEmpty(aux) || Regex.IsMatch(aux, pattern) || aux.Contains(" ") || aux.Length > 1)
            {
                Console.WriteLine("Letra invalida!!!");
                CharacterCheck();
            }
            else
            {
                flag = true;
                char_vali = char.Parse(aux);
            }
            return flag;
        }

        //Verifica que se ingrese una palabra, sin espacios en blanco o caracteres numericos
        private bool WordCheck()
        {
            bool flag = false;
            string pattern = @"\d+";
            Regex defaultRegex = new Regex(pattern);

            Console.WriteLine("Ingrese la palabra");
            word_vali = Console.ReadLine().ToUpper();
            if (String.IsNullOrEmpty(word_vali) || Regex.IsMatch(word_vali, pattern) || word_vali.Contains(" "))
            {
                Console.Write("Tiene que ingresar una palabra, sin numeros o espacios en blanco");
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

        //Valida que se ingrese una palabra sin espacios, sin numeros y sin ser NULL
        private string ValidateWord()
        {
            bool flag = true;
            string pattern = @"\d+";
            Regex defaultRegex = new Regex(pattern);

            while (flag)
            {
                WordCapture();
                if (String.IsNullOrEmpty(word) || Regex.IsMatch(word, pattern) || word.Contains(" "))
                {
                    Console.WriteLine("Palabra invalida");
                    Console.WriteLine("- No puede tener numeros");
                    Console.WriteLine("- No puede tener ser una palabra vacia");
                    Console.WriteLine("- No puede ingresar mas de una palabra");
                    Console.WriteLine();
                    Console.Write("Presione una tecla para volver a intentar...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    flag = false;
                    Console.Clear();
                }
            }
            return word;
        }

        //Draws
        //Muestra la dimension de la palabra y el progreso del jugador
        private void ShowBox()
        {
            Console.Clear();
            Console.WriteLine("Jugador 2:");
            HangBoy();
            Console.WriteLine();
            for (int i = 0; i < box.Length; i++)
            {
                Console.Write($" {box[i] }");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Intentos fallidos: {attempt} de: 5 ");
        }

        //Muestra el monito
        private void HangBoy()
        {
            switch (attempt)
            {
                case 1:
                    Console.WriteLine("________");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;
                case 2:
                    Console.WriteLine("________");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine("|      |\\");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;
                case 3:
                    Console.WriteLine("________");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine("|     /|\\");
                    Console.WriteLine("|      ");
                    Console.WriteLine("|");
                    break;
                case 4:
                    Console.WriteLine("________");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine("|     /|\\");
                    Console.WriteLine("|       \\");
                    Console.WriteLine("|");
                    break;
                case 5:
                    Console.WriteLine("________");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine("|     /|\\");
                    Console.WriteLine("|     / \\");
                    Console.WriteLine("|");
                    break;
                default:
                    Console.WriteLine("________");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    break;
            }

        }
    }
}
