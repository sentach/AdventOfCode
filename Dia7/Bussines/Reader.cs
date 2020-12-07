using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Bussines
{

    public class Reader
    {
        private static Regex _reglas = new Regex(@"([\w\s]*) bags contain ([\w\s,]*)", RegexOptions.Compiled);
        private static Regex _bolsas = new Regex(@"((\d) ([\w\s]*) bags?,?)+", RegexOptions.Compiled);
        public static Dictionary<string, List<string>> Lector1(string fileName)
        {
            var result = new Dictionary<string, List<string>>();
            using var reader = File.OpenText(fileName);
            while (!reader.EndOfStream)
            {
                var buff = _reglas.Match(reader.ReadLine());
                if (!buff.Success) { continue; }
                var key = buff.Groups[1].Value;
                var lista = buff.Groups[2].Value;
                var valor = new List<string>();
                var grupos = _bolsas.Match(lista);
                while (grupos.Captures.Count != 0)
                {
                    valor.Add(grupos.Groups[3].Value);
                    grupos = grupos.NextMatch();
                }

                if (result.ContainsKey(key))
                {
                    result[key].AddRange(valor);
                }
                else
                {
                    result.Add(key, valor);
                }
            }
            return result;
        }

        public static Dictionary<string, List<Bolsa>> Lector2(string fileName)
        {
            var result = new Dictionary<string, List<Bolsa>>();
            using var reader = File.OpenText(fileName);
            while (!reader.EndOfStream)
            {
                var buff = _reglas.Match(reader.ReadLine());
                if (!buff.Success) { continue; }
                var key = buff.Groups[1].Value;
                var lista = buff.Groups[2].Value;
                var valor = new List<Bolsa>();
                var grupos = _bolsas.Match(lista);
                while (grupos.Captures.Count != 0)
                {
                    valor.Add(new Bolsa { Color = grupos.Groups[3].Value, Numero = Convert.ToInt32(grupos.Groups[2].Value) });
                    grupos = grupos.NextMatch();
                }

                if (result.ContainsKey(key))
                {
                    result[key].AddRange(valor);
                }
                else
                {
                    result.Add(key, valor);
                }
            }
            return result;
        }
    }
}