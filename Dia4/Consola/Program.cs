using System;
using Bussines;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = Reader.Lector(".\\datos.txt");
            Console.WriteLine($"Resultado {Reto4.Calcular1(datos)}");
        }
    }
}
