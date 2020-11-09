using System;

namespace EjercicioArreglos2
{
    class Carrera
    {
        TIC Ti;
        DN Dn;


        public Carrera()
        {
            Ti = new TIC();
            Dn = new DN();
            PrintResults();
        }

        private void PrintResults()
        {
            Console.WriteLine($"Edad promedio de TI: {TIC.AgeAvg()}");
            Console.WriteLine($"Edad promedio de DN: {DN.AgeAvg()}");
            Console.WriteLine($"El profesor mas joven de TI: {TIC.MYT()}");
            Console.WriteLine($"El profesor mas joven de DN: {DN.MYT()}");
            Console.WriteLine($"Profesores con edad menor al promedio en TI: {TIC.MTA()}");
            Console.WriteLine($"Profesores con edad menor al promedio en DN: {DN.MTA()}");
            Console.WriteLine($"Total de mujeres en TI: {TIC.TotalW()}");
            Console.WriteLine($"Total de mujeres en DN: {DN.TotalW()}");
            Console.WriteLine($"Total de profesores titulados en TI: {TIC.TotalT()}");
            Console.WriteLine($"Total de profesores titulados en DN: {DN.TotalT()}");
        }
    }
}
