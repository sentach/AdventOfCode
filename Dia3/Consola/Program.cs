using Bussines;
using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = Reader.Lector(".\\datos.txt");
            Console.WriteLine($"Resultado: {Reto1.Calcular(datos)}");
        }
    }
}
