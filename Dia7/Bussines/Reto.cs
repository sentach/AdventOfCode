using System;
using System.Collections.Generic;
using System.Linq;

namespace Bussines
{
    public class Reto
    {
        public static int Resultado1(Dictionary<string, List<string>> datos, string bag)
        {
            var lista = new Queue<string>();
            var result = new HashSet<string>();
            var l = datos.Where(x => x.Value.Contains(bag)).Select(x => x.Key).ToList();
            foreach (var dato in l)
            {
                lista.Enqueue(dato);
                result.Add(dato);
            }

            while (lista.Count!=0)
            {
                var bolsa = lista.Dequeue();
                l = datos.Where(x => x.Value.Contains(bolsa)).Select(x => x.Key).ToList();
                foreach (var dato in l)
                {
                    lista.Enqueue(dato);
                    result.Add(dato);
                }
            }
            return result.Count;
        }

        public static long Resultado2(Dictionary<string, List<Bolsa>> datos, string bag)
        {
            long result = 0;
            foreach (var dato in datos[bag])
            {
                result +=dato.Numero * Devuelve(datos, dato.Color);
            }
            return result;
        }

        private static long Devuelve(Dictionary<string, List<Bolsa>> datos, string bag)
        {
            long result = 1;
            
            foreach (var dato in datos[bag])
            {
                result += dato.Numero * Devuelve(datos, dato.Color);
            }
            return result;
        }
    }
}
