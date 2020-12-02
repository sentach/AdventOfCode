
using System;
using System.Text.RegularExpressions;

namespace bussines
{
    public class Datos
    {
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public char Letra { get; set; }
        public string Password { get; set; }
        public bool Valido { get; set; }

        private Regex _reg = new Regex("^(\\d*)-(\\d*) (\\w): (\\w*)$");
        public Datos(string valor)
        {
            var r = _reg.Match(valor);
            Minimo = Convert.ToInt32(r.Groups[1].Value);
            Maximo = Convert.ToInt32(r.Groups[2].Value);
            Letra = Convert.ToChar(r.Groups[3].Value);
            Password = r.Groups[4].Value;

            Valido = false;
        }
    }
}