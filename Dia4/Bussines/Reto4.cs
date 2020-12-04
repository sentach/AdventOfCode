using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Bussines
{
    public class Reto4    
    {
        
        private static Regex byr = new Regex("byr:");
        private static Regex iyr = new Regex("iyr:");
        private static Regex eyr = new Regex("eyr:");
        private static Regex hgt = new Regex("hgt:");
        private static Regex hcl = new Regex("hcl:");
        private static Regex ecl = new Regex("ecl:");
        private static Regex pid = new Regex("pid:");
        private static Regex cid = new Regex("cid:");
                
        public static int Calcular1(List<string> datos)
        {
            int result = 0;
            foreach(var pass in datos)
            {
                if (!byr.Match(pass).Success) 
                {
                    Console.WriteLine($"byr->{pass}");
                    continue; 
                }
                if (!iyr.Match(pass).Success) 
                {
                    Console.WriteLine($"iyr->{pass}");
                    continue; 
                }
                if (!eyr.Match(pass).Success) 
                {
                    Console.WriteLine($"eyr->{pass}");
                    continue; 
                }
                if (!hgt.Match(pass).Success) 
                {
                    Console.WriteLine($"hgt->{pass}");
                    continue; 
                }
                if (!hcl.Match(pass).Success) 
                {
                    Console.WriteLine($"hcl->{pass}");
                    continue; 
                }
                if (!ecl.Match(pass).Success) 
                {
                    Console.WriteLine($"ecl->{pass}");
                    continue; 
                }
                if (!pid.Match(pass).Success) 
                {
                    Console.WriteLine($"pid->{pass}");
                    continue; 
                }
                result++;
            }
            return result;
        }
    }
}
