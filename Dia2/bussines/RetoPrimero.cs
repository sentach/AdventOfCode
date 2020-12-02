using System.Collections.Generic;
using System.Linq;

namespace bussines
{
    public class RetoPrimero
    {
        public static int Validar(List<Datos> datos)
        {
            foreach(var dato in datos)
            {
                var n = dato.Password.Count(x => x == dato.Letra);
                dato.Valido = dato.Minimo <= n && n <= dato.Maximo;
            }

            return datos.Count(x => x.Valido);
        }
    }
}
