using Bussines;
using System;
using System.Linq;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = Reader.Lector1(".\\datos.txt");

            Console.WriteLine($"Resultado 1 {datos.Sum(x => x.Length)}");

            var datos2 = Reader.Lector2(".\\datos.txt");

            Console.WriteLine($"Resultado 2 {datos2.Sum(x => x.Length)}");
            /*
            foreach(var dato in datos2)
            {
                Console.WriteLine(dato);
            }
            */
        }
    }
}
