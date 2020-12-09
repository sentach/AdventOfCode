using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class Dia9
    {
        public static long Reto1(List<long> datos)
        {
            var cola = new Queue<long>();
            foreach(var dato in datos)
            {
                if(cola.Count<25)
                {
                    cola.Enqueue(dato);
                    continue;
                }
                var copia = cola.ToArray();
                bool encontrado = false;
                for(int i=0; i<cola.Count;i++)
                {
                    var busc = dato - copia[i];
                    if (busc < 0) { continue; }
                    if (cola.Contains(busc)) 
                    { 
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado) { return dato; }
                _ = cola.Dequeue();
                cola.Enqueue(dato);
            }
            throw new ArgumentException("No se puede resolver");
        }
        public static long Reto2(List<long> datos, long value)
        {
            var temp = new List<long>();
            for(int i=0;i<datos.Count-1; i++)
            {
                temp.Add(datos[i]);
                for(int j=i+1;j<datos.Count;j++)
                {
                    temp.Add(datos[j]);
                    if(temp.Sum()==value)
                    {
                        return temp.Max() + temp.Min();
                    }
                    if(temp.Sum()>value)
                    {
                        temp.Clear();
                        break;
                    }
                }
            }
            throw new Exception("Not solution found");
        }
    }
}
