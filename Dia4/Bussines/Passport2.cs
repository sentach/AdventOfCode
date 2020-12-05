namespace Bussines
{
    public class Passport2
    {
        public const string Cm = "cm";
        public const string In = "in";

        public string Id { get; set; }
        public int BirthYear { get; set; }
        public int IssueYear { get; set; }
        public int ExpYear { get; set; }
        public string HeightUnit { get; set; }
        public int Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string CountryId { get; set; }
        public bool Valido { get; set; }

        public Passport2(string linea)
        {
            Valido = true;
            var items = linea.Split(" ");
            foreach(var item in items)
            {
                var dato = item.Split(":");
                switch (dato[0])
                {
                    case "byr":
                        if (int.TryParse(dato[1], out int birth)) { BirthYear = birth; } else { Valido = false; }
                        break;
                    case "iyr":
                        if (int.TryParse(dato[1], out int issue)) { IssueYear = issue; } else { Valido = false; }
                        break;
                    case "eyr":
                        if (int.TryParse(dato[1], out int exp)) { ExpYear = exp; } else { Valido = false; }
                        break;
                    case "hgt":
                        if (dato[1].EndsWith(Cm))
                        {
                            if (int.TryParse(dato[1].Replace(Cm, ""), out int unitcm)) { Height = unitcm; HeightUnit = Cm; }
                            else { Valido = false; }
                        }
                        else if (dato[1].EndsWith(In))
                        {
                            if (int.TryParse(dato[1].Replace(In, ""), out int unitin)) { Height = unitin; HeightUnit = In; }
                            else { Valido = false; }
                        }
                        else { Valido = false; }
                        break;
                    case "hcl":
                        HairColor = dato[1];
                        break;
                    case "ecl":
                        EyeColor = dato[1];
                        break;
                    case "pid":
                        Id = dato[1];
                        break;
                    case "cid":
                        CountryId = dato[1];
                        break;
                }
                
                if (!Valido) { break; }
            }
            if (Valido)
            {
                if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(EyeColor) || string.IsNullOrEmpty(HairColor) || string.IsNullOrEmpty(HeightUnit)
                    || Height == 0 || ExpYear == 0 || IssueYear == 0 || BirthYear == 0)
                {
                    Valido = false;
                }
            }
        }
    }
}
