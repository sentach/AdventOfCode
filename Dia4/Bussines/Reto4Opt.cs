using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bussines
{
    public static class Reto4Opt
    {
        public static int Resuelve1(List<Dictionary<string,string>> datos)
        {   
            return datos.Count(x => x.Keys.Count(y => y != "cid") == 7);
        }

        public static int Resuelve2(List<Passport2> datos)
        {
            return datos.Count(Valida);
        }

        private static Regex hair = new Regex("^#[0-9a-f]{6}$", RegexOptions.Compiled);
        private static Regex id = new Regex("^[0-9]{9}$",RegexOptions.Compiled);
        private static string[] eyecolors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        private static bool Valida(Passport2 p)
        {
            return p.Valido
                && p.BirthYear >= 1920 && p.BirthYear <= 2002
                && p.IssueYear >= 2010 && p.IssueYear <= 2020
                && p.ExpYear >= 2020 && p.ExpYear <= 2030
                && ((p.HeightUnit == Passport2.Cm && p.Height >= 150 && p.Height <= 193) || (p.HeightUnit == Passport2.In && p.Height >= 59 && p.Height <= 76))
                && hair.Match(p.HairColor).Success
                && eyecolors.Contains(p.EyeColor)
                && id.Match(p.Id).Success;
        }
    }
}
