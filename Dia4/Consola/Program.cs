using System;
using Bussines;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = Reader.Lector(".\\datos.txt");
            Console.WriteLine($"Resultado 1: {Reto4.Calcular1(datos)}");

            Console.WriteLine($"Resultado 2: {Reto4.Calcular2(datos)}");
        }
    }
}
