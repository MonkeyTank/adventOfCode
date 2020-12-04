using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventOfCode
{
    class Passport
    {
        private Dictionary<string, string> passportData;
        private bool validity;

        public Passport(Dictionary<string, string> passportData)
        {
            this.passportData = passportData;
            isValid();
        }

        private bool isValid()
        {
            if (BirthYear != null
                && IssueYear != null
                && ExpirationYear != null
                && Height != null
                && HairColor != null
                && EyeColor != null
                && PassportID != null)
            {
                if (isValidBirthYear()
                    && isValidExpirationYear()
                    && isValidEyeColor()
                    && isValidHairColor()
                    && isValidHeight()
                    && isValidIssueYear()
                    && isValidPID()) 
                {
                    validity = true;
                    return true;
                }
            }

            validity = false;
            return false;
        }

        public bool Validity
        {
            get { return validity; }
        }

        public string BirthYear
        {
            get 
            {
                string output;
                if(passportData.TryGetValue("byr", out output))
                {
                    return output;
                }
                return null;
            }

            set
            {
                string curValue;
                if (passportData.TryGetValue("byr", out curValue))
                {
                    passportData["byr"] = value;
                }
                else
                {
                    passportData.Add("byr", value);
                }
                isValid();
            }
        }
        public string IssueYear
        {
            get
            {
                string output;
                if (passportData.TryGetValue("iyr", out output))
                {
                    return output;
                }
                return null;
            }

            set
            {
                string curValue;
                if (passportData.TryGetValue("iyr", out curValue))
                {
                    passportData["iyr"] = value;
                }
                else
                {
                    passportData.Add("iyr", value);
                }
                isValid();
            }
        }
        public string ExpirationYear
        {
            get
            {
                string output;
                if (passportData.TryGetValue("eyr", out output))
                {
                    return output;
                }
                return null;
            }

            set
            {
                string curValue;
                if (passportData.TryGetValue("eyr", out curValue))
                {
                    passportData["eyr"] = value;
                }
                else
                {
                    passportData.Add("eyr", value);
                }
                isValid();
            }
        }
        public string Height
        {
            get
            {
                string output;
                if (passportData.TryGetValue("hgt", out output))
                {
                    return output;
                }
                return null;
            }

            set
            {
                string curValue;
                if (passportData.TryGetValue("hgt", out curValue))
                {
                    passportData["hgt"] = value;
                }
                else
                {
                    passportData.Add("hgt", value);
                }
                isValid();
            }
        }
        public string HairColor
        {
            get
            {
                string output;
                if (passportData.TryGetValue("hcl", out output))
                {
                    return output;
                }
                return null;
            }

            set
            {
                string curValue;
                if (passportData.TryGetValue("hcl", out curValue))
                {
                    passportData["hcl"] = value;
                }
                else
                {
                    passportData.Add("hcl", value);
                }
                isValid();
            }
        }
        public string EyeColor
        {
            get
            {
                string output;
                if (passportData.TryGetValue("ecl", out output))
                {
                    return output;
                }
                return null;
            }

            set
            {
                string curValue;
                if (passportData.TryGetValue("ecl", out curValue))
                {
                    passportData["ecl"] = value;
                }
                else
                {
                    passportData.Add("ecl", value);
                }
                isValid();
            }
        }
        public string PassportID
        {
            get
            {
                string output;
                if (passportData.TryGetValue("pid", out output))
                {
                    return output;
                }
                return null;
            }

            set
            {
                string curValue;
                if (passportData.TryGetValue("pid", out curValue))
                {
                    passportData["pid"] = value;
                }
                else
                {
                    passportData.Add("pid", value);
                }
                isValid();
            }
        }
        public string CountryID
        {
            get
            {
                string output;
                if (passportData.TryGetValue("cid", out output))
                {
                    return output;
                }
                return null;
            }

            set
            {
                string curValue;
                if (passportData.TryGetValue("cid", out curValue))
                {
                    passportData["cid"] = value;
                }
                else
                {
                    passportData.Add("cid", value);
                }
                isValid();
            }
        }

        private bool isValidBirthYear()
        {
            try
            {
                int tmp = Convert.ToInt32(BirthYear);
                if (tmp > 1919 && tmp < 2003)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool isValidIssueYear()
        {
            try
            {
                int tmp = Convert.ToInt32(IssueYear);
                if (tmp > 2009 && tmp < 2021)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool isValidExpirationYear()
        {
            try
            {
                int tmp = Convert.ToInt32(ExpirationYear);
                if (tmp > 2019 && tmp < 2031)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool isValidHeight()
        {
            try
            {
                if (Height.Length == 4 && Height[2] == 'i' && Height[3] == 'n')
                {
                    int inch = (Convert.ToInt32(Height[0].ToString()) * 10 + Convert.ToInt32(Height[1].ToString()));
                    if (inch > 58 && inch < 77)
                        return true;
                    else
                        return false;
                }
                else if (Height.Length == 5 && Height[3] == 'c' && Height[4] == 'm')
                {
                    int cm = (Convert.ToInt32(Height[0].ToString()) * 100 + Convert.ToInt32(Height[1].ToString()) * 10 + Convert.ToInt32(Height[2].ToString()));
                    if (cm > 149 && cm < 194)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool isValidHairColor()
        {
            if (HairColor.Length == 7)
            {
                if (HairColor[0] != '#')
                {
                    return false;
                }
                else
                {
                    for (int i = 1; i < HairColor.Length - 1; i++)
                    {
                        if ((HairColor[i] > 0x60 && HairColor[i] < 0x67) || (HairColor[i] > 0x2f && HairColor[i] < 0x3a))
                            continue;
                        else
                            return false;
                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool isValidEyeColor()
        {
            switch (EyeColor)
            {
                case "amb":                    
                case "blu":                    
                case "brn":                    
                case "gry":
                case "grn":
                case "hzl":
                case "oth":
                    return true;
                default:
                    return false;
            }
        }

        private bool isValidPID()
        {
            try
            {
                int pid = Convert.ToInt32(PassportID);

                if (PassportID.Length == 9)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
