using Bussines;
using System;
using System.Linq;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Calucula id {Reto5.CalculaId("FFFFFFFRRL")}");
            var datos = Reader.Lector1(".\\datos.txt");
            Console.WriteLine($"Calcula mas {Reto5.Resuelve1(datos)}");

            Console.WriteLine($"Resuelve 2 {Reto5.Resuelve2(datos)}");
            
            /*
            foreach (var dato in datos.OrderByDescending(x => x.Replace("L","S")))
            {
                Console.WriteLine(dato);
            }
            */
        }
    }
}
