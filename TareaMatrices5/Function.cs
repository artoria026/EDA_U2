using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TareaMatrices5
{
    class Function
    {
        char[,] tab1 = new char[10, 10], tab2 = new char[10, 10], tab2REP = new char[10, 10], tab1REP = new char[10, 10];
        int turn = 0;
        bool checkFlag, P1W, P2W, PPM;
        int contP1 = 0, contP2 = 0;
        char marker = 'X';

        public Function()
        //Constructor de la funcion, dentro de ejecutan algunos metodos iniciales para el funcionamiento del programa
        {
            FillBox();
            GameIntro();
            GameCurse();
        }

        private void GameCurse()
        //Orden del proceso del programa, determina el flujo de llamada a los metodos involucrados
        {
            for (int i = 0; i < 2; i++)
            {
                SetFrigate();
                SetDestructor();
                SetCarrier();
                if (turn == 0) ShowTab1();
                else ShowTab2();
                Thread.Sleep(5000);
                NextTurn();
            }
            do
            {
                MakeShot();
            } while (!P1W || !P2W || !PPM);
        }

        private void GameIntro()
        //Secuencia de instrucciones para comenzar a jugar, tutorial del juego
        {
            Console.WriteLine("Bienvenidos al juego de Battall Naval");
            if (RepeatIntro())
            {
                Console.WriteLine("Este es el tablero de juego: ");
                ShowTab1();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Dentro podras colocar tus barcos");
                Console.WriteLine("Tendras que usar 3 fragatas, 2 destructores y 1  portaviones");
                Console.WriteLine("Las fragatas apareceran con el simbolo: \"#\"");
                Console.WriteLine("Los destructores apareceran con el simbolo: \"# | #\"");
                Console.WriteLine("Los destructores apareceran con el simbolo: \"# | # | #\"");
                Console.WriteLine("Podrás ordenarlos de manera horizontal o vertical");
                Console.Write("\nPresiona una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Atencion!");
                Console.WriteLine("Este es el tablero de tu adversario: ");
                TestTab();
                Console.WriteLine("Tendra sus barcos dispuestos por el mapa de manera similar");
                Console.WriteLine("Tendrás que introducir las coordenadas dónde crees que se encuentran sus barcos, y disparar");
                Console.WriteLine("Para hundir cada barco tendrás que disparar en cada coordanada en la que se encuentre");
                Console.WriteLine("Preparate para jugar");
                Console.Write("\nPresiona una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //MISC METHODS
        private void NextTurn()
        //Metodo para cambiar el turno de los jugadores
        {
            if (turn == 0) turn = 1;
            else turn = 0;
        }

        private void MakeShot()
        //Metodo para efectuar los disparos de los jugadores
        {
            int x, y;


            if (turn == 0) ShowTab2REP();
            else ShowTab1REP();
            Console.WriteLine($"Jugador {turn + 1}, Introduce las coordenadas de tu disparo");
            Console.Write("X: ");
            x = Utils.ReadInt();
            Console.Write("Y: ");
            y = Utils.ReadInt();
            Console.WriteLine($"Coordenadas {x}:{y}\nPresiona una tecla para continuar");
            Console.ReadKey();

            if (x > 10 || y > 10)
            {
                Console.WriteLine("No puedes ingresar coordenadas mayores que el tamaño del mapa");
                Console.Write("Presiona una tecla para continuar...");
                Console.ReadKey();
                MakeShot();
            }
            else
            {

                if (turn == 0)
                {
                    if (tab2REP[y - 1, x - 1] == '#')
                    {
                        Console.WriteLine("Ya usaste esa coordenada, no sea tramposo klero!\nPierdes turno!!!");
                        Console.Write("Presiona una tecla para continuar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (tab2[y - 1, x - 1] == '#')
                        {
                            tab2REP[y - 1, x - 1] = '#';
                            contP1++;
                            Console.WriteLine("Has acertado un disparo!");
                            Console.Write("Presiona una tecla para continuar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            tab2REP[y - 1, x - 1] = 'X';
                            Console.WriteLine("Has fallado un disparo!");
                            Console.Write("Presiona una tecla para continuar...");
                            Console.ReadKey();
                        }
                        ShowTab2REP();
                        Console.Write("Presiona una tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    if (tab1REP[y - 1, x - 1] == '#')
                    {
                        Console.WriteLine("Ya usaste esa coordenada, no sea tramposo klero!\nPierdes turno!!!");
                        Console.Write("Presiona una tecla para continuar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (tab1[y - 1, x - 1] == '#')
                        {
                            tab1REP[y - 1, x - 1] = '#';
                            contP2++;
                            Console.WriteLine("Has acertado un disparo!");
                            Console.Write("Presiona una tecla para continuar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            tab1REP[y - 1, x - 1] = 'X';
                            Console.WriteLine("Has fallado un disparo!");
                            Console.Write("Presiona una tecla para continuar...");
                            Console.ReadKey();
                        }
                        ShowTab1REP();
                        Console.Write("Presiona una tecla para continuar...");
                        Console.ReadKey();
                    }
                }

                if (contP1 == 10)
                {
                    P1W = true;
                    Console.Clear();
                    Console.WriteLine("El jugador 1 ha ganado");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (contP2 == 10)
                {
                    P2W = true;
                    Console.Clear();
                    Console.WriteLine("El jugador 2 ha ganado");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                NextTurn();
            }
        }

        private bool Check(int x, int y)
        //Metodo para revisar que las coordenadas ingresadas no existan ya en la matriz
        {
            checkFlag = false;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (turn == 0)
                    {
                        if (tab1[i, j] == tab1[x, y] && tab1[i, j] == '#') checkFlag = true;
                        else checkFlag = false;
                    }
                    else
                    {
                        if (tab2[i, j] == tab2[x, y] && tab2[i, j] == '#') checkFlag = true;
                        else checkFlag = false;
                    }
                }
            }
            return checkFlag;
        }
        //FILL METHODS
        private void SetFrigate()
        //Metodo que pregunta y asigna las coordenadas de las fragatas a los jugadores
        {
            for (int i = 0; i < 3; i++)
            {
                if (turn == 0) ShowTab1();
                else ShowTab2();
                int x = 0, y = 0;
                checkFlag = true;
                while (checkFlag)
                {
                    do
                    {
                        Console.WriteLine($"Introduce las coordenadas de la fragata {i + 1}");
                        Console.Write("X: ");
                        x = Utils.ReadInt();
                    } while (x <= 0 || x > 10);
                    do
                    {
                        Console.Write("Y: ");
                        y = Utils.ReadInt();
                        if (y > 10) Console.WriteLine("No puede exceder el tamaño del tablero");
                    } while (y <= 0 || y > 10);
                    Check((y - 1), (x - 1));
                }
                if (turn == 0) Frigate1(y - 1, x - 1);
                else Frigate2(y - 1, x - 1);
                Console.Clear();
            }
        }

        private void SetDestructor()
        {
            int dir;
            for (int i = 0; i < 2; i++)
            {
                if (turn == 0) ShowTab1();
                else ShowTab2();
                do
                {
                    Console.WriteLine($"En que direccion desea insertar el destructor? Posicion vertical:");
                    dir = 0;
                } while (dir != 0 && dir != 1);


                int x = 0, y = 0;
                checkFlag = true;
                if (dir == 1)
                {
                    while (checkFlag)
                    {
                        do
                        {
                            Console.WriteLine($"Introduce las coordenadas del Destructor {i + 1}");
                            Console.Write("X: ");
                            x = Utils.ReadInt();
                            if (x > 9) Console.WriteLine("No puede exceder el tamaño del tablero");
                        } while (x <= 0 || x > 9);
                        do
                        {
                            Console.Write("Y: ");
                            y = Utils.ReadInt();
                            if (y > 10) Console.WriteLine("No puede exceder el tamaño del tablero");
                        } while (y <= 0 || y > 10);
                        Check((y - 1), (x - 1));
                    }
                    if (turn == 0) DestructorH1(y - 1, x - 1);
                    else DestructorH2(y - 1, x - 1);
                }
                else
                {
                    do
                    {
                        Console.WriteLine($"Introduce las coordenadas del Destructor {i + 1}");
                        Console.Write("X: ");
                        x = Utils.ReadInt();
                        if (x > 10) Console.WriteLine("No puede exceder el tamaño del tablero");
                    } while (x <= 0 || x > 10);
                    do
                    {
                        Console.Write("Y: ");
                        y = Utils.ReadInt();
                        if (y > 10) Console.WriteLine("No puede exceder el tamaño del tablero");
                    } while (y <= 0 || y > 9);
                    Check((x - 1), (y - 1));
                }
                if (turn == 0) DestructorV1(y - 1, x - 1);
                else DestructorV2(y - 1, x - 1);
            }
        }

        private void SetCarrier()
        {
            int dir;
            if (turn == 0) ShowTab1();
            else ShowTab2();
            do
            {
                Console.WriteLine("En que direccion desea insertar el Portaviones? Posicion vertical:");
                dir = 0;
            } while (dir != 0 && dir != 1);

            int x = 0, y = 0;
            checkFlag = true;
            if (dir == 1)
            {
                while (checkFlag)
                {
                    do
                    {
                        Console.WriteLine($"Introduce las coordenadas del Portaviones");
                        Console.Write("X: ");
                        x = Utils.ReadInt();
                        if (x > 8) Console.WriteLine("No puede exceder el tamaño del tablero");
                    } while (x <= 0 || x > 8);
                    do
                    {
                        Console.Write("Y: ");
                        y = Utils.ReadInt();
                        if (y > 10) Console.WriteLine("No puede exceder el tamaño del tablero");
                    } while (y <= 0 || y > 10);
                    Check((y - 1), (x - 1));
                }
                if (turn == 0) CarrierH1(y - 1, x - 1);
                else CarrierH2(y - 1, x - 1);
            }
            else
            {
                do
                {
                    Console.WriteLine($"Introduce las coordenadas del Portaviones");
                    Console.Write("X: ");
                    x = Utils.ReadInt();
                    if (x > 10) Console.WriteLine("No puede exceder el tamaño del tablero");
                } while (x <= 0 || x > 10);
                do
                {
                    Console.Write("Y: ");
                    y = Utils.ReadInt();
                    if (y > 8) Console.WriteLine("No puede exceder el tamaño del tablero");
                } while (y <= 0 || y > 8);
                Check((y - 1), (x - 1));
            }
            if (turn == 0) CarrierV1(y - 1, x - 1);
            else CarrierV2(y - 1, x - 1);
        }



        //SHIP METHODS
        private void Frigate1(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador para el barco mas chico del jugador 1

        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab1[i, j] = '#';
                    }
                }
            }
        }
        private void Frigate2(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador para el barco mas chico del jugador 2
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab2[i, j] = '#';
                    }
                }
            }
        }

        private void DestructorH1(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador en horizontal para el barco mediano del jugador 1
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab1[i, j] = '#';
                        tab1[i, (j + 1)] = '#';
                    }
                }
            }
        }

        private void DestructorH2(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador en horizontal para el barco mediano del jugador 2
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab2[i, j] = '#';
                        tab2[i, (j + 1)] = '#';
                    }
                }
            }
        }

        private void DestructorV1(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador en vertical para el barco mediano del jugador 1
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab1[i, j] = '#';
                        tab1[(i + 1), j] = '#';
                    }
                }
            }
        }

        private void DestructorV2(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador en vertical para el barco mediano del jugador 2
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab2[i, j] = '#';
                        tab2[(i + 1), j] = '#';
                    }
                }
            }
        }

        private void CarrierV1(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador en vertical para el barco grande del jugador 1
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab1[i, j] = '#';
                        tab1[(i + 1), j] = '#';
                        tab1[(i + 2), j] = '#';
                    }
                }
            }
        }

        private void CarrierV2(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador en vertical para el barco grande del jugador 2
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab2[i, j] = '#';
                        tab2[(i + 1), j] = '#';
                        tab2[(i + 2), j] = '#';
                    }
                }
            }
        }

        private void CarrierH1(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador en horizontal para el barco grande del jugador 1
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab1[i, j] = '#';
                        tab1[i, (j + 1)] = '#';
                        tab1[i, (j + 2)] = '#';
                    }
                }
            }
        }

        private void CarrierH2(int x, int y)
        //Ubicar la posicion asignada en la matriz y poner el marcador en horizontal para el barco grande del jugador 2
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        tab2[i, j] = '#';
                        tab2[i, (j + 1)] = '#';
                        tab2[i, (j + 2)] = '#';
                    }
                }
            }
        }


        //TAB TOOLS
        private void FillBox()
        //Volver los tableros a la posicion inicial
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tab1[i, j] = ' ';
                    tab2[i, j] = ' ';
                    tab1REP[i, j] = ' ';
                    tab2REP[i, j] = ' ';
                }
            }
        }


        //TAB
        private void ShowTab1()
        //Muestra el tablero del jugador 1
        {
            Console.Clear();
            Console.WriteLine("\n    *****     Tablero Jugador 1     *****");
            Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine("  ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            Console.WriteLine($" 1| {tab1[0, 0]} | {tab1[0, 1]} | {tab1[0, 2]} | {tab1[0, 3]} | {tab1[0, 4]} | {tab1[0, 5]} | {tab1[0, 6]} | {tab1[0, 7]} | {tab1[0, 8]} | {tab1[0, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 2| {tab1[1, 0]} | {tab1[1, 1]} | {tab1[1, 2]} | {tab1[1, 3]} | {tab1[1, 4]} | {tab1[1, 5]} | {tab1[1, 6]} | {tab1[1, 7]} | {tab1[1, 8]} | {tab1[1, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 3| {tab1[2, 0]} | {tab1[2, 1]} | {tab1[2, 2]} | {tab1[2, 3]} | {tab1[2, 4]} | {tab1[2, 5]} | {tab1[2, 6]} | {tab1[2, 7]} | {tab1[2, 8]} | {tab1[2, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 4| {tab1[3, 0]} | {tab1[3, 1]} | {tab1[3, 2]} | {tab1[3, 3]} | {tab1[3, 4]} | {tab1[3, 5]} | {tab1[3, 6]} | {tab1[3, 7]} | {tab1[3, 8]} | {tab1[3, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 5| {tab1[4, 0]} | {tab1[4, 1]} | {tab1[4, 2]} | {tab1[4, 3]} | {tab1[4, 4]} | {tab1[4, 5]} | {tab1[4, 6]} | {tab1[4, 7]} | {tab1[4, 8]} | {tab1[4, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 6| {tab1[5, 0]} | {tab1[5, 1]} | {tab1[5, 2]} | {tab1[5, 3]} | {tab1[5, 4]} | {tab1[5, 5]} | {tab1[5, 6]} | {tab1[5, 7]} | {tab1[5, 8]} | {tab1[5, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 7| {tab1[6, 0]} | {tab1[6, 1]} | {tab1[6, 2]} | {tab1[6, 3]} | {tab1[6, 4]} | {tab1[6, 5]} | {tab1[6, 6]} | {tab1[6, 7]} | {tab1[6, 8]} | {tab1[6, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 8| {tab1[7, 0]} | {tab1[7, 1]} | {tab1[7, 2]} | {tab1[7, 3]} | {tab1[7, 4]} | {tab1[7, 5]} | {tab1[7, 6]} | {tab1[7, 7]} | {tab1[7, 8]} | {tab1[7, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 9| {tab1[8, 0]} | {tab1[8, 1]} | {tab1[8, 2]} | {tab1[8, 3]} | {tab1[8, 4]} | {tab1[8, 5]} | {tab1[8, 6]} | {tab1[8, 7]} | {tab1[8, 8]} | {tab1[8, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($"10| {tab1[9, 0]} | {tab1[9, 1]} | {tab1[9, 2]} | {tab1[9, 3]} | {tab1[9, 4]} | {tab1[9, 5]} | {tab1[9, 6]} | {tab1[9, 7]} | {tab1[9, 8]} | {tab1[9, 9]} |");
            Console.WriteLine("  └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
        }

        private void ShowTab2()
        //Muestra el tablero del jugador 2
        {
            Console.Clear();
            Console.WriteLine("\n    *****     Tablero Jugador 2     *****");
            Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine("  ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            Console.WriteLine($" 1| {tab2[0, 0]} | {tab2[0, 1]} | {tab2[0, 2]} | {tab2[0, 3]} | {tab2[0, 4]} | {tab2[0, 5]} | {tab2[0, 6]} | {tab2[0, 7]} | {tab2[0, 8]} | {tab2[0, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 2| {tab2[1, 0]} | {tab2[1, 1]} | {tab2[1, 2]} | {tab2[1, 3]} | {tab2[1, 4]} | {tab2[1, 5]} | {tab2[1, 6]} | {tab2[1, 7]} | {tab2[1, 8]} | {tab2[1, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 3| {tab2[2, 0]} | {tab2[2, 1]} | {tab2[2, 2]} | {tab2[2, 3]} | {tab2[2, 4]} | {tab2[2, 5]} | {tab2[2, 6]} | {tab2[2, 7]} | {tab2[2, 8]} | {tab2[2, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 4| {tab2[3, 0]} | {tab2[3, 1]} | {tab2[3, 2]} | {tab2[3, 3]} | {tab2[3, 4]} | {tab2[3, 5]} | {tab2[3, 6]} | {tab2[3, 7]} | {tab2[3, 8]} | {tab2[3, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 5| {tab2[4, 0]} | {tab2[4, 1]} | {tab2[4, 2]} | {tab2[4, 3]} | {tab2[4, 4]} | {tab2[4, 5]} | {tab2[4, 6]} | {tab2[4, 7]} | {tab2[4, 8]} | {tab2[4, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 6| {tab2[5, 0]} | {tab2[5, 1]} | {tab2[5, 2]} | {tab2[5, 3]} | {tab2[5, 4]} | {tab2[5, 5]} | {tab2[5, 6]} | {tab2[5, 7]} | {tab2[5, 8]} | {tab2[5, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 7| {tab2[6, 0]} | {tab2[6, 1]} | {tab2[6, 2]} | {tab2[6, 3]} | {tab2[6, 4]} | {tab2[6, 5]} | {tab2[6, 6]} | {tab2[6, 7]} | {tab2[6, 8]} | {tab2[6, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 8| {tab2[7, 0]} | {tab2[7, 1]} | {tab2[7, 2]} | {tab2[7, 3]} | {tab2[7, 4]} | {tab2[7, 5]} | {tab2[7, 6]} | {tab2[7, 7]} | {tab2[7, 8]} | {tab2[7, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 9| {tab2[8, 0]} | {tab2[8, 1]} | {tab2[8, 2]} | {tab2[8, 3]} | {tab2[8, 4]} | {tab2[8, 5]} | {tab2[8, 6]} | {tab2[8, 7]} | {tab2[8, 8]} | {tab2[8, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($"10| {tab2[9, 0]} | {tab2[9, 1]} | {tab2[9, 2]} | {tab2[9, 3]} | {tab2[9, 4]} | {tab2[9, 5]} | {tab2[9, 6]} | {tab2[9, 7]} | {tab2[9, 8]} | {tab2[9, 9]} |");
            Console.WriteLine("  └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
        }

        private void TestTab()
        //Muestra el tablero de prueba para el tutorial
        {
            Console.WriteLine("\n    *****     Tablero Jugador 2     *****");
            Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine("  ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            Console.WriteLine($" 1|   | # |   |   |   |   |   |   |   |   |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 2|   |   |   |   |   |   |   |   |   |   |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 3|   |   |   |   |   | # |   |   |   |   |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 4|   |   |   |   |   |   |   |   |   |   |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 5|   |   | # |   |   |   |   |   | # |   |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 6|   |   | # |   |   |   |   |   | # |   |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 7|   |   |   |   |   |   |   |   |   |   |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 8|   |   |   |   | # |   | # |   |   |   |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 9|   |   |   |   |   |   | # |   |   |   |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($"10|   |   |   |   |   |   | # |   |   |   |");
            Console.WriteLine("  └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
        }

        private void ShowTab1REP()
        //Muestra la representacion del tablero del jugador 1
        {
            Console.Clear();
            Console.WriteLine("\n    *****     Tablero Jugador 1     *****");
            Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine("  ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            Console.WriteLine($" 1| {tab1REP[0, 0]} | {tab1REP[0, 1]} | {tab1REP[0, 2]} | {tab1REP[0, 3]} | {tab1REP[0, 4]} | {tab1REP[0, 5]} | {tab1REP[0, 6]} | {tab1REP[0, 7]} | {tab1REP[0, 8]} | {tab1REP[0, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 2| {tab1REP[1, 0]} | {tab1REP[1, 1]} | {tab1REP[1, 2]} | {tab1REP[1, 3]} | {tab1REP[1, 4]} | {tab1REP[1, 5]} | {tab1REP[1, 6]} | {tab1REP[1, 7]} | {tab1REP[1, 8]} | {tab1REP[1, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 3| {tab1REP[2, 0]} | {tab1REP[2, 1]} | {tab1REP[2, 2]} | {tab1REP[2, 3]} | {tab1REP[2, 4]} | {tab1REP[2, 5]} | {tab1REP[2, 6]} | {tab1REP[2, 7]} | {tab1REP[2, 8]} | {tab1REP[2, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 4| {tab1REP[3, 0]} | {tab1REP[3, 1]} | {tab1REP[3, 2]} | {tab1REP[3, 3]} | {tab1REP[3, 4]} | {tab1REP[3, 5]} | {tab1REP[3, 6]} | {tab1REP[3, 7]} | {tab1REP[3, 8]} | {tab1REP[3, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 5| {tab1REP[4, 0]} | {tab1REP[4, 1]} | {tab1REP[4, 2]} | {tab1REP[4, 3]} | {tab1REP[4, 4]} | {tab1REP[4, 5]} | {tab1REP[4, 6]} | {tab1REP[4, 7]} | {tab1REP[4, 8]} | {tab1REP[4, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 6| {tab1REP[5, 0]} | {tab1REP[5, 1]} | {tab1REP[5, 2]} | {tab1REP[5, 3]} | {tab1REP[5, 4]} | {tab1REP[5, 5]} | {tab1REP[5, 6]} | {tab1REP[5, 7]} | {tab1REP[5, 8]} | {tab1REP[5, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 7| {tab1REP[6, 0]} | {tab1REP[6, 1]} | {tab1REP[6, 2]} | {tab1REP[6, 3]} | {tab1REP[6, 4]} | {tab1REP[6, 5]} | {tab1REP[6, 6]} | {tab1REP[6, 7]} | {tab1REP[6, 8]} | {tab1REP[6, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 8| {tab1REP[7, 0]} | {tab1REP[7, 1]} | {tab1REP[7, 2]} | {tab1REP[7, 3]} | {tab1REP[7, 4]} | {tab1REP[7, 5]} | {tab1REP[7, 6]} | {tab1REP[7, 7]} | {tab1REP[7, 8]} | {tab1REP[7, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 9| {tab1REP[8, 0]} | {tab1REP[8, 1]} | {tab1REP[8, 2]} | {tab1REP[8, 3]} | {tab1REP[8, 4]} | {tab1REP[8, 5]} | {tab1REP[8, 6]} | {tab1REP[8, 7]} | {tab1REP[8, 8]} | {tab1REP[8, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($"10| {tab1REP[9, 0]} | {tab1REP[9, 1]} | {tab1REP[9, 2]} | {tab1REP[9, 3]} | {tab1REP[9, 4]} | {tab1REP[9, 5]} | {tab1REP[9, 6]} | {tab1REP[9, 7]} | {tab1REP[9, 8]} | {tab1REP[9, 9]} |");
            Console.WriteLine("  └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
        }

        private void ShowTab2REP()
        //Muestra la representacion del tablero del jugador 2
        {
            Console.Clear();
            Console.WriteLine("\n    *****     Tablero Jugador 2     *****");
            Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine("  ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            Console.WriteLine($" 1| {tab2REP[0, 0]} | {tab2REP[0, 1]} | {tab2REP[0, 2]} | {tab2REP[0, 3]} | {tab2REP[0, 4]} | {tab2REP[0, 5]} | {tab2REP[0, 6]} | {tab2REP[0, 7]} | {tab2REP[0, 8]} | {tab2REP[0, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 2| {tab2REP[1, 0]} | {tab2REP[1, 1]} | {tab2REP[1, 2]} | {tab2REP[1, 3]} | {tab2REP[1, 4]} | {tab2REP[1, 5]} | {tab2REP[1, 6]} | {tab2REP[1, 7]} | {tab2REP[1, 8]} | {tab2REP[1, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 3| {tab2REP[2, 0]} | {tab2REP[2, 1]} | {tab2REP[2, 2]} | {tab2REP[2, 3]} | {tab2REP[2, 4]} | {tab2REP[2, 5]} | {tab2REP[2, 6]} | {tab2REP[2, 7]} | {tab2REP[2, 8]} | {tab2REP[2, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 4| {tab2REP[3, 0]} | {tab2REP[3, 1]} | {tab2REP[3, 2]} | {tab2REP[3, 3]} | {tab2REP[3, 4]} | {tab2REP[3, 5]} | {tab2REP[3, 6]} | {tab2REP[3, 7]} | {tab2REP[3, 8]} | {tab2REP[3, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 5| {tab2REP[4, 0]} | {tab2REP[4, 1]} | {tab2REP[4, 2]} | {tab2REP[4, 3]} | {tab2REP[4, 4]} | {tab2REP[4, 5]} | {tab2REP[4, 6]} | {tab2REP[4, 7]} | {tab2REP[4, 8]} | {tab2REP[4, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 6| {tab2REP[5, 0]} | {tab2REP[5, 1]} | {tab2REP[5, 2]} | {tab2REP[5, 3]} | {tab2REP[5, 4]} | {tab2REP[5, 5]} | {tab2REP[5, 6]} | {tab2REP[5, 7]} | {tab2REP[5, 8]} | {tab2REP[5, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 7| {tab2REP[6, 0]} | {tab2REP[6, 1]} | {tab2REP[6, 2]} | {tab2REP[6, 3]} | {tab2REP[6, 4]} | {tab2REP[6, 5]} | {tab2REP[6, 6]} | {tab2REP[6, 7]} | {tab2REP[6, 8]} | {tab2REP[6, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 8| {tab2REP[7, 0]} | {tab2REP[7, 1]} | {tab2REP[7, 2]} | {tab2REP[7, 3]} | {tab2REP[7, 4]} | {tab2REP[7, 5]} | {tab2REP[7, 6]} | {tab2REP[7, 7]} | {tab2REP[7, 8]} | {tab2REP[7, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($" 9| {tab2REP[8, 0]} | {tab2REP[8, 1]} | {tab2REP[8, 2]} | {tab2REP[8, 3]} | {tab2REP[8, 4]} | {tab2REP[8, 5]} | {tab2REP[8, 6]} | {tab2REP[8, 7]} | {tab2REP[8, 8]} | {tab2REP[8, 9]} |");
            Console.WriteLine("  ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
            Console.WriteLine($"10| {tab2REP[9, 0]} | {tab2REP[9, 1]} | {tab2REP[9, 2]} | {tab2REP[9, 3]} | {tab2REP[9, 4]} | {tab2REP[9, 5]} | {tab2REP[9, 6]} | {tab2REP[9, 7]} | {tab2REP[9, 8]} | {tab2REP[9, 9]} |");
            Console.WriteLine("  └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
        }



        //BASIC METHODS
        private bool RepeatIntro()
        //Metodo para preguntar si desea ver el tutorial al inicio del juego
        {
            Console.Write("Quiere leer las instrucciones? Si/No:  ");
            string opc = Console.ReadLine().ToLower();
            return (opc.CompareTo("si") == 0 || opc.CompareTo("s") == 0) ? true : false;
        }

        private bool RepeatTurn()
        //Metodo para preguntar si desea terminar su turno
        {
            Console.Write($"Quiere terminar su turno Jugador {turn}? Si/No:  ");
            string opc = Console.ReadLine().ToLower();
            return (opc.CompareTo("si") == 0 || opc.CompareTo("s") == 0) ? true : false;
        }
    }
}
