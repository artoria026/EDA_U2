using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioArreglos1
{
    class Function
    {
        int num_students, cont = 0;
        int[] students;
        string[] names;
        double[,] cal;
        double[] avg;

        int top, bot;

        public Function()
        {
            NumStudents();
            FillCal();
            CalcResults();
            PrintResults();
        }

        private void NumStudents()
        {
            Console.Write("Ingrese el numero de alumnos: ");
            num_students = Utils.ReadInt();
            students = new int[num_students];
            names = new string[num_students];
            avg = new double[num_students];
            cal = new double[num_students, 3];
        }

        private void FillCal()
        {
            for (int i = 0; i < num_students; i++)
            {
                Console.Write($"\nNombre del alumno {i + 1}: ");
                names[i] = Console.ReadLine();

                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Calificacion {j + 1}: ");
                    cal[cont, j] = Utils.ReadDouble();
                }
                cont++;
            }
        }

        private void CalcResults()
        {
            double aux;
            for (int k = 0; k < num_students; k++)
            {
                aux = 0;
                for (int l = 0; l < 3; l++)
                {
                    aux += cal[k, l];
                }
                avg[k] = aux / 3;
            }

            double aux_bot = avg[0], aux_top = avg[0];
            for (int i = 0; i < num_students; i++)
            {
                if (aux_bot > avg[i])
                {
                    aux_bot = avg[i];
                    bot = i;
                }
                if (aux_top < avg[i])
                {
                    aux_top = avg[i];
                    top = i;
                }
            }

        }

        private void PrintResults()
        {
            Console.WriteLine("\nAlumnos:");
            foreach (string name in names)
            {
                Console.Write($"{name} ");
            }

            Console.WriteLine("\nPromedios:");
            foreach (double final in avg)
            {
                Console.Write($"{final}  ");
            }

            Console.WriteLine($"\nEl alumno con mayor promedio es: {names[top]} con promedio: {avg[top]}");
            Console.WriteLine($"El alumno con menor promedio es: {names[bot]} con promedio: {avg[bot]}");

            PrintApr();
        }

        private void PrintApr()
        {
            Console.WriteLine("Aprobados:");
            for (int i = 0; i < num_students; i++)
            {
                if (avg[i] >= 8)
                {
                    Console.WriteLine($"{names[i]} : {avg[i]}");
                }
            }

            Console.WriteLine("Reprobados:");
            for (int i = 0; i < num_students; i++)
            {
                if (avg[i] < 8)
                {
                    Console.WriteLine($"{names[i]} : {avg[i]}");
                }
            }
        }

    }
}
