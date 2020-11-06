using System;

namespace EjercicioMatrices3
{
    class Function
    {
        string[] materias = { "Español", "Matematicas", "Historia", "Ingles" };
        string[] names;
        double[,] cal;
        double[] avg_students, avg_mat;
        double avg_counter, avg_group;
        int dim, top_mat, bot_mat, top_stu, bot_stu;

        public Function()
        {
            DefineMath();
            FillMat();
            CalcResults();
            PrintMat();
            CalcRank();
            PrintResults();
        }

        private void DefineMath()
        {
            Console.Write("Ingrese el numero de alumnos a capturar: ");
            dim = Utils.ReadInt();
            cal = new double[dim, materias.Length];
            names = new string[dim];
            avg_students = new double[dim];
            avg_mat = new double[materias.Length];
        }

        private void FillMat()
        {
            for (int i = 0; i < dim; i++)
            {
                Console.Write("\nAlumno: ");
                names[i] = Console.ReadLine();
                for (int j = 0; j < materias.Length; j++)
                {
                    Console.Write($"{materias[j]}: ");
                    cal[i, j] = Utils.ReadDouble();
                }
            }
        }

        private void PrintMat()
        {
            Console.Write("\n Alumno     ");
            foreach (string ass in materias) { Console.Write($" {ass} "); }
            Console.Write(" Promedio ");
            for (int i = 0; i < dim; i++)
            {
                Console.Write($"\n{names[i]}");
                for (int j = 0; j < materias.Length; j++)
                {
                    Console.Write($"  {cal[i, j]}  ");
                }
                Console.Write($" {avg_students[i]} ");
            }
            Console.Write("\nPromedio Materias: ");
            foreach (double avg in avg_mat) { Console.Write($" {avg / dim} "); }
            Console.Write($" {avg_group} Promedio Grupal");
        }

        private void CalcResults()
        {
            double aux_avg = 0;
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < materias.Length; j++)
                {
                    aux_avg += cal[i, j];
                }
                avg_students[i] = aux_avg / materias.Length;
                avg_counter += aux_avg;
                aux_avg = 0;
            }
            avg_counter = avg_counter / dim;

            aux_avg = 0;
            for (int k = 0; k < materias.Length; k++)
            {
                for (int h = 0; h < dim; h++)
                {
                    aux_avg += cal[h, k];
                }
                avg_mat[k] = aux_avg;
                aux_avg = 0;
            }
            foreach (double avgG in avg_students) { avg_group += avgG; }
            avg_group = avg_group / dim;
        }

        private void PrintResults()
        {
            Console.WriteLine();
            Console.Write($"\nMateria con promedio mas bajo: {materias[top_mat]}");
            Console.Write($"\nMateria con promedio mas alto: {materias[bot_mat]}");
            Console.Write($"\nAlumno con promedio mas bajo: {names[bot_stu]} con: {avg_students[bot_stu]}");
            Console.Write($"\nAlumno con promedio mas alto: {names[top_stu]} con: {avg_students[top_stu]}");
        }

        private void CalcRank()
        {
            double auxT = avg_mat[0];
            double auxB = avg_mat[0];
            for (int i = 0; i < materias.Length; i++)
            {
                if (auxT > avg_mat[i])
                {
                    auxT = avg_mat[i];
                    top_mat = i;
                }
                if (auxB < avg_mat[i])
                {
                    auxB = avg_mat[i];
                    bot_mat = i;
                }
            }

            auxT = avg_students[0];
            auxB = avg_students[0];
            for (int j = 0; j < avg_students.Length; j++)
            {
                if (auxT < avg_students[j])
                {
                    auxT = avg_students[j];
                    top_stu = j;
                }
                if (auxB > avg_students[j])
                {
                    auxB = avg_students[j];
                    bot_stu = j;
                }
            }
        }
    }

}
