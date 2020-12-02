using System.Collections.Generic;
using System.IO;

namespace bussines
{
    public static class Reader
    {
        public static List<Datos> LeerDatos(string file)
        {
            var result = new List<Datos>();
            using(var reader = File.OpenText(".\\datos.txt"))
            {
                while(!reader.EndOfStream)
                {
                    var linea = reader.ReadLine();
                    result.Add(new Datos(linea));
                }
            }
            return result;
        }
    }
}