using System;
using Bussines;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            const string file = ".\\datos.txt";
            var datos = Reader.Lector(file);
            Console.WriteLine($"Resultado 1: {Reto4.Calcular1(datos)}");

            Console.WriteLine($"Resultado 2: {Reto4.Calcular2(datos)}");

            var datosOpt1 = Reader.Lector1(file);
            Console.WriteLine($"Resul opt 1: {Reto4Opt.Resuelve1(datosOpt1)}");

            var datosOpt2 = Reader.Lector2(file);
            Console.WriteLine($"Resul opt 2: {Reto4Opt.Resuelve2(datosOpt2)}");
        }
    }
}
