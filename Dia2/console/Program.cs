using bussines;
using System;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = Reader.LeerDatos(".\\datos.txt");
            Console.WriteLine($"Password validas 1 {RetoPrimero.Validar(datos)}");
            Console.WriteLine($"Password validas 2 {RetoSegundo.Validar(datos)}");
        }
    }
}
