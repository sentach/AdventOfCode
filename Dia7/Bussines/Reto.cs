using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static int Resultado2(Dictionary<string, List<Bolsa>> datos, string bag)
        {
            int result = 0;
            foreach(var dato in datos[bag])
            {
                result += Devuelve(datos, dato.Color, dato.Numero); 
            }

            //result -= datos[bag].Sum(x => x.Numero);
            
            return result;
        }

        private static int Devuelve(Dictionary<string, List<Bolsa>> datos, string bag, int numero)
        {
            if (datos[bag].Count == 0) {
                Console.WriteLine(numero);
                return numero; 
            }

            int result = 0;
            foreach(var dato in datos[bag])
            {
                result += (dato.Numero * Devuelve(datos, dato.Color, dato.Numero));
            }
            return result;
        }
    }
}
