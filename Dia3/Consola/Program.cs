using Bussines;
using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = Reader.Lector(".\\datos.txt");
            Console.WriteLine($"Resultado: {Reto1.Calcular1(datos)}");
            var l1 = Reto1.Calcular2(datos, 1, 1);
            var l2 = Reto1.Calcular2(datos, 3, 1);
            var l3 = Reto1.Calcular2(datos, 5, 1);
            var l4 = Reto1.Calcular2(datos, 7, 1);
            var l5 = Reto1.Calcular2(datos, 1, 2);

            Console.WriteLine($"l1:{l1} l2:{l2} l3:{l3} l4:{l4} l5:{l5}");
            Console.WriteLine($"Resultado: {l1 * l2 * l3 * l4 * l5}");
        }
    }
}
