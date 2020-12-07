using Bussines;
using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = Reader.Lector1(".\\datos.txt");
            Console.WriteLine($"Resultado 1 {Reto.Resultado1(datos, "shiny gold")}");

            var datos2 = Reader.Lector2(".\\datos.txt");
            Console.WriteLine($"Resultado 2 {Reto.Resultado2(datos2, "shiny gold")}");

        }
    }
}
