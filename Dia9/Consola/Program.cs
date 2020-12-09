using Bussines;
using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = Reader.Lector1(".\\datos.txt");
            var sol1 = Dia9.Reto1(datos);
            Console.WriteLine($"Resultado reto1 : {sol1}");
            Console.WriteLine($"Resultado reto2 : {Dia9.Reto2(datos, sol1)}");
        }
    }
}
