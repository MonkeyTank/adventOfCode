using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> inputList;
            List<Password> passwords;
            int cnt = 0;

            StreamReader streamReader = new StreamReader(@"..\..\02\02.txt");

            getListFromTxt(streamReader, out inputList);

            passwords = getPasswordsFromInput(inputList);
            
            foreach(Password cur in passwords)
            {
                if (cur.valid)
                    cnt++;
            }

            Console.WriteLine("{0} out of {1} passwords are valid", cnt, passwords.Count());

            Console.ReadLine();
        }

        public static void getListFromTxt(StreamReader sr, out List<String> result)
        {
            result = new List<String>();
            while (!sr.EndOfStream)
            {
                result.Add(sr.ReadLine());
            }
        }

        public static List<int> getIntsFromStringList(List<String> strings)
        {
            List<int> result = new List<int>();

            foreach(string cur in strings)
            {
                result.Add(Convert.ToInt32(cur));
            }

            return result;
        } 

        public static List<Password> getPasswordsFromInput(List<string> inputs)
        {
            List<Password> passwords = new List<Password>();

            foreach(string cur in inputs)
            {
                string[] conditions = cur.Split(' ');
                string[] minMax = conditions[0].Split('-');

                Password temp = new Password(Convert.ToInt32(minMax[0]), Convert.ToInt32(minMax[1]), conditions[1][0], conditions[2]);
                passwords.Add(temp);
            }

            return passwords;
        }
    }
}
