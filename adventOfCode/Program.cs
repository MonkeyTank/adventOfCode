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
            //string[] inputArray;
            List<Dictionary<string, string>> inputDicts;
            int validCnt = 0;

            StreamReader streamReader = new StreamReader(@"..\..\input\04.txt");

            getListFromTxt(streamReader, out inputList);

            inputDicts = getDictionaryListFromStringList(inputList);

            List<Passport> passports = new List<Passport>();

            foreach(Dictionary<string, string> cur in inputDicts)
            {
                passports.Add(new Passport(cur));
            }

            foreach(Passport cur in passports)
            {
                if (cur.Validity)
                    validCnt++;
            }

            Console.WriteLine("{0} passports are valid", validCnt);

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

        public static void getArrayFromTxt(StreamReader sr, out string[] result)
        {
            int cnt = 0;
            List<string> temp = new List<string>();
            while (!sr.EndOfStream)
            {
                temp.Add(sr.ReadLine());                
            }

            result = new string[temp.Count];            

            foreach(string cur in temp)
            {
                result[cnt] = cur;
                cnt++;
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

        public static List<Dictionary<string, string>> getDictionaryListFromStringList(List<string> strings)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            Dictionary<string, string> tmp = new Dictionary<string, string>();

            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i] == "")
                    continue;
                
                string[] pairs = strings[i].Split(' ');
                
                foreach(string pair in pairs)
                {
                    string[] keyValue = pair.Split(':');
                    tmp.Add(keyValue[0], keyValue[1]);
                }

                if (i + 1 < strings.Count && strings[i + 1] == "")
                {
                    result.Add(tmp);
                    tmp = new Dictionary<string, string>();
                }
            }

            return result;
        }

        public static List<PasswordTwo> getPasswordsFromInput(List<string> inputs)
        {
            List<PasswordTwo> passwords = new List<PasswordTwo>();

            foreach(string cur in inputs)
            {
                string[] conditions = cur.Split(' ');
                string[] minMax = conditions[0].Split('-');

                PasswordTwo temp = new PasswordTwo(Convert.ToInt32(minMax[0]), Convert.ToInt32(minMax[1]), conditions[1][0], conditions[2]);
                passwords.Add(temp);
            }

            return passwords;
        }

        public static long calcSlopes(int right, int down, string[] inputArray)
        {
            long trees = 0;
            int row = down;
            int column = right;

            while (row < inputArray.Length)
            {
                if (inputArray[row][column] == '#')
                    trees++;
                row += down;
                column += right;
                if (column >= inputArray[0].Length)
                    column -= inputArray[0].Length;
            }
            return trees;
        }
    }
}
