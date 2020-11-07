using System;

namespace TareaMatrices4
{
    class Function
    {

        int a, b = 0, turn = 0;
        int[,] board;
        string[] names;

        //Constructor
        //Constructor de la clase con el procedimiento para la ejecucion
        public Function()
        {
            Console.Title = "Juego del Gato";
            Console.WriteLine("JUEGO DEL GATO");
            Console.WriteLine();
            FillBoard();
            Players();

        StartGame:
            Console.WriteLine($"Turno de {names[turn]}");
            Board();
            ChooseTurn();
            if (TurnCheck() == false)
            {
                NextTurn();
                Console.Clear();
                goto StartGame;
            }
            else
            {
                if (Utils.Repeat())
                {
                    RestartBoard();
                    goto StartGame;
                }
                Console.WriteLine();
                Console.WriteLine($"Se han jugado {b} partidas");
                Console.WriteLine("GRACIAS POR JUGAR!");
            }

        }

        //Functions
        //Rellena el tablero inicialmente con 0 en todas las posiciones
        private void FillBoard()
        {
            board = new int[3, 3];
            b = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 0;
                }
            }
        }

        //Reinicia el tablero y las variables involucradas
        private void RestartBoard()
        {
            board = new int[3, 3];
            b++;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 0;
                    turn = 0;

                    Console.Clear();
                    Console.WriteLine("Juego Reiniciado...");
                }
            }
        }

        //Registra el nombre de los jugadores en un array
        private void Players()
        {
            names = new string[2];
            Console.Write("Ingrese el nombre del jugador X: ");
            names[0] = Console.ReadLine();
            Console.Write("Ingrese el nombre del jugador O: ");
            names[1] = Console.ReadLine();
            Console.Clear();
        }

        //Asigna el simbolo correspondiente a cada jugador para el mapeado en el tablero
        private char PlayerSymbol(int player)
        {
            switch (player)
            {
                case 0:
                    return '-';
                case 1:
                    return 'X';
                case 2:
                    return 'O';
            }
            return '-';
        }

        //Cambia al turno correspondiente revisando el turno actual
        private void NextTurn()
        {
            if (turn == 0)
            {
                turn = 1;
            }
            else
            {
                turn = 0;
            }
        }

        //Segun el turno, solicita la posicion al juagdor, si esta esta ocupada le da una advertencia y la solicita de nuevo
        private void ChooseTurn()
        {
            int position;
        InvalidPosition:
            Console.Write("Ingresa el numero de la posicion deseada: ");
            position = Utils.ReadInt();
            switch (position)
            {
                case 1:
                    if (board[0, 0] != 0)
                    {
                        Console.WriteLine($"ERROR! La posision {position} ya esta ocupada");
                        goto InvalidPosition;
                    }
                    board[0, 0] = turn + 1;
                    break;
                case 2:
                    if (board[0, 1] != 0)
                    {
                        Console.WriteLine($"ERROR! La posision {position} ya esta ocupada");
                        goto InvalidPosition;
                    }
                    board[0, 1] = turn + 1;
                    break;
                case 3:
                    if (board[0, 2] != 0)
                    {
                        Console.WriteLine($"ERROR! La posision {position} ya esta ocupada");
                        goto InvalidPosition;
                    }
                    board[0, 2] = turn + 1;
                    break;
                case 4:
                    if (board[1, 0] != 0)
                    {
                        Console.WriteLine($"ERROR! La posision {position} ya esta ocupada");
                        goto InvalidPosition;
                    }
                    board[1, 0] = turn + 1;
                    break;
                case 5:
                    if (board[1, 1] != 0)
                    {
                        Console.WriteLine($"ERROR! La posision {position} ya esta ocupada");
                        goto InvalidPosition;
                    }
                    board[1, 1] = turn + 1;
                    break;
                case 6:
                    if (board[1, 2] != 0)
                    {
                        Console.WriteLine($"ERROR! La posision {position} ya esta ocupada");
                        goto InvalidPosition;
                    }
                    board[1, 2] = turn + 1;
                    break;
                case 7:
                    if (board[2, 0] != 0)
                    {
                        Console.WriteLine($"ERROR! La posision {position} ya esta ocupada");
                        goto InvalidPosition;
                    }
                    board[2, 0] = turn + 1;
                    break;
                case 8:
                    if (board[2, 1] != 0)
                    {
                        Console.WriteLine($"ERROR! La posision {position} ya esta ocupada");
                        goto InvalidPosition;
                    }
                    board[2, 1] = turn + 1;
                    break;
                case 9:
                    if (board[2, 2] != 0)
                    {
                        Console.WriteLine($"ERROR! La posision {position} ya esta ocupada");
                        goto InvalidPosition;
                    }
                    board[2, 2] = turn + 1;
                    break;
                default:
                    Console.WriteLine("ERROR! La posision es invalida");
                    goto InvalidPosition;
            }
        }

        //Revisa las posiciones para validar cuando alguno de los dos jugadores gane
        private bool TurnCheck()
        {
            int winner = 0;
            VerticalCheck();
            HorizontalCheck();
            InclinedCheck();

            if (winner != 0)
            {
                Console.Clear();
                Board();
                Console.WriteLine($"\n EL GANADOR ES: {names[winner - 1]}");
                return true;
            }
            if (FullCheck() == true)
            {
                Console.Clear();
                Board();
                Console.WriteLine("\n EMPATE, NO HAY GANADORES");
                return true;
            }
            void VerticalCheck()
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    {
                        winner = board[0, i];
                    }
                }
            }
            void HorizontalCheck()
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    {
                        winner = board[i, 0];
                    }
                }
            }
            void InclinedCheck()
            {
                if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                {
                    winner = board[0, 0];
                }
                else if (board[2, 0] != 0 && board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2])
                {
                    winner = board[2, 0];
                }
            }
            bool FullCheck()
            {
                int f = 0;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (board[i, j] != 0)
                            f++;
                if (f == 9)
                    return true;
                else
                    return false;
            }
            return false;
        }

        //Draws
        //Muestra el tablero de juego, es llamado constantemente para mostrarlo en cada cambio
        private void Board()
        {
            Console.WriteLine();
            Console.WriteLine("       █       █");
            Console.WriteLine($"   {PlayerSymbol(board[0, 0])}   █   {PlayerSymbol(board[0, 1])}   █   {PlayerSymbol(board[0, 2])}");
            Console.WriteLine("     1 █     2 █     3 ");
            Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.WriteLine("       █       █");
            Console.WriteLine($"   {PlayerSymbol(board[1, 0])}   █   {PlayerSymbol(board[1, 1])}   █   {PlayerSymbol(board[1, 2])}");
            Console.WriteLine("     4 █     5 █     6 ");
            Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.WriteLine("       █       █");
            Console.WriteLine($"   {PlayerSymbol(board[2, 0])}   █   {PlayerSymbol(board[2, 1])}   █   {PlayerSymbol(board[2, 2])}");
            Console.WriteLine("     7 █     8 █     9 ");
            Console.WriteLine();
        }
    }
}