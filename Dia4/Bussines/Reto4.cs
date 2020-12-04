using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

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
                    //Console.WriteLine($"byr->{pass}");
                    continue; 
                }
                if (!iyr.Match(pass).Success) 
                {
                    //Console.WriteLine($"iyr->{pass}");
                    continue; 
                }
                if (!eyr.Match(pass).Success) 
                {
                    //Console.WriteLine($"eyr->{pass}");
                    continue; 
                }
                if (!hgt.Match(pass).Success) 
                {
                    //Console.WriteLine($"hgt->{pass}");
                    continue; 
                }
                if (!hcl.Match(pass).Success) 
                {
                    //Console.WriteLine($"hcl->{pass}");
                    continue; 
                }
                if (!ecl.Match(pass).Success) 
                {
                    //Console.WriteLine($"ecl->{pass}");
                    continue; 
                }
                if (!pid.Match(pass).Success) 
                {
                    //Console.WriteLine($"pid->{pass}");
                    continue; 
                }
                result++;
            }
            return result;
        }

        private static Regex byr2 = new Regex("byr:(\\d{4})", RegexOptions.Compiled);
        private static Regex iyr2 = new Regex("iyr:(\\d{4})", RegexOptions.Compiled);
        private static Regex eyr2 = new Regex("eyr:(\\d{4})", RegexOptions.Compiled);
        private static Regex hgt2 = new Regex("hgt:(\\d{2,3})(\\w{2})", RegexOptions.Compiled);
        private static Regex hcl2 = new Regex("hcl:#[0-9a-f]{6}", RegexOptions.Compiled);
        private static Regex ecl2 = new Regex("ecl:(\\w{3})", RegexOptions.Compiled);
        private static Regex pid2 = new Regex("pid:(\\d+)", RegexOptions.Compiled);
        private static Regex cid2 = new Regex("cid:\\w+", RegexOptions.Compiled);

        private static string[] eyecolors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        public static int Calcular2(List<string> datos)
        {
            var result = new List<string>();
            foreach(var pass in datos)
            {
                var passData = string.Empty;
                var byear = byr2.Match(pass);
                if (!byear.Success)
                {
                    continue;
                }
                else
                {
                    if (byear.Captures.Count > 1) 
                    { 
                        continue; 
                    }
                    int anio = Convert.ToInt32(byear.Groups[1].Value);
                    if(anio < 1920 || anio > 2002) 
                    {
                        continue; 
                    }
                    passData = byear.Value;
                }

                var issue = iyr2.Match(pass);
                if (!issue.Success)
                {
                    continue;
                }
                else
                {
                    if (issue.Captures.Count > 1)
                    {
                        continue;
                    }
                    int iss = Convert.ToInt32(issue.Groups[1].Value);
                    if (iss < 2010 || iss > 2020)
                    {
                        continue;
                    }
                    passData += " " + issue.Value;
                }
                var exp = eyr2.Match(pass);
                if (!exp.Success)
                {
                    continue;
                }
                else
                {
                    if (exp.Captures.Count > 1)
                    {
                        continue;
                    }
                    int expy = Convert.ToInt32(exp.Groups[1].Value);
                    if (expy < 2020 || expy > 2030)
                    {
                        continue;
                    }
                    passData += " " + exp.Value;
                }
                var altura = hgt2.Match(pass);
                if (!altura.Success)
                {
                    continue;
                }
                else
                {
                    if (altura.Captures.Count > 1)
                    {
                        continue;
                    }
                    int alt = Convert.ToInt32(altura.Groups[1].Value);
                    var med = altura.Groups[2].Value;
                    if (med == "cm")
                    {
                        if (alt < 150 || alt > 193)
                        {
                            continue;
                        }
                    }
                    else if (med == "in")
                    {
                        if (alt < 59 || alt > 76)
                        {
                            continue;
                        }
                    }
                    else 
                    {
                        continue; 
                    }
                    passData += " " + altura.Value + (med == "cm" ? "" : " ");
                }
                var hcl = hcl2.Match(pass);
                if (!hcl.Success)
                {
                    continue;
                }
                else
                {
                    if (hcl.Captures.Count > 1)
                    {
                        continue;
                    }
                    passData += " " + hcl.Value;
                }
                var eyecolor = ecl2.Match(pass);
                if (!eyecolor.Success)
                {
                    continue;
                }
                else
                {
                    if (eyecolor.Captures.Count > 1)
                    {
                        continue;
                    }
                    var color = eyecolor.Groups[1].Value;
                    if(!eyecolors.Contains(color))
                    {
                        continue;
                    }
                    passData += " " + eyecolor.Value;
                }
                var pid = pid2.Match(pass);
                if (!pid.Success)
                {
                    continue;
                }
                else
                {
                    if (pid.Captures.Count > 1)
                    {
                        continue;
                    }
                    if (pid.Groups[1].Value.Length != 9)
                    {
                        //Console.WriteLine("pid:" + pid.Groups[1].Value);
                        continue;
                    }
                }
                passData += " " + pid.Value;
                                
                result.Add(passData);
            }
            
            return result.Distinct().Count();
        }
    }
}
