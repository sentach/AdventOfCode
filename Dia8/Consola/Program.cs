using Bussines;
using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = Reader.Lector1(".\\datos.txt");
            var exe = new Executer(datos);
            Console.WriteLine($"El reto1 es {exe.Execute()}");
        }
    }
}
