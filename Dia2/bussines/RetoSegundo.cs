using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussines
{
    public class RetoSegundo
    {
        public static int Validar(List<Datos> datos)
        {
            foreach(var dato in datos)
            {
                dato.Valido = dato.Password[dato.Minimo - 1] == dato.Letra ^ dato.Password[dato.Maximo - 1] == dato.Letra;
            }

            return datos.Count(x => x.Valido);
        }
    }
}
