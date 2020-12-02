using System;
using System.Collections.Generic;
using System.IO;

namespace Dia1
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = LoadDatos();
            var numeros = ObtenNumeros(datos);
            Console.WriteLine($"N1 = {numeros.Item1}, N2 = {numeros.Item2} resultado={numeros.Item2*numeros.Item1}");
            var trio = Obtener3(datos);
            var resultado = trio[0]*trio[1]*trio[2];
            Console.WriteLine($"N1={trio[0]}, N2={trio[1]},N3={trio[2]}. Resultado={resultado}");
        }

        static int[] Obtener3(List<int> datos)
        {
            for(int i=0; i<datos.Count-2;i++)
            {
                for(int j=i+1; j<datos.Count-1;j++)
                {
                    for(int k=j+1;k<datos.Count;k++)
                    {
                        var n1=datos[i];
                        var n2=datos[j];
                        var n3=datos[k];
                        if(n1+n2+n3==2020)
                        {
                            return new int[]{n1,n2,n3};
                        }                    
                    }           
                }
            }
            return new int[3];
        }

        static Tuple<int, int> ObtenNumeros(List<int> datos)
        {
            int n1=0, n2=0;
            for(int i=0; i<datos.Count-1;i++)
            {
                for(int j=i+1; j<datos.Count;j++)
                {
                    if(datos[i]+datos[j]==2020)
                    {
                        n1=datos[i];
                        n2=datos[j];
                        return new Tuple<int, int>(n1,n2);
                    }                    
                }
            }
            return new Tuple<int, int>(0,0);
        }

        static List<int> LoadDatos()
        {
            var result = new List<int>();
            using(var reader = File.OpenText(".\\datos.txt"))
            {
                while(!reader.EndOfStream)
                {
                    var l = reader.ReadLine();
                    if(int.TryParse(l, out int dato))
                    {
                        result.Add(dato);
                    }
                }
            }
            return result;
        }
    }
}
