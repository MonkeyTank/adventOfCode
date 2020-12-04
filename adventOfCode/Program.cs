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
            //List<String> inputList;
            string[] inputArray;
            int right;
            int down;
            
            StreamReader streamReader = new StreamReader(@"..\..\03\03.txt");

            getArrayFromTxt(streamReader, out inputArray);

            right = 1;
            down = 1;
            long treesA = calcSlopes(right, down, inputArray);
            Console.WriteLine("{0} trees will be encountered with right {1}, down {2}", treesA, right, down);

            right = 3;
            down = 1;
            long treesB = calcSlopes(right, down, inputArray);
            Console.WriteLine("{0} trees will be encountered with right {1}, down {2}", treesB, right, down);

            right = 5;
            down = 1;
            long treesC = calcSlopes(right, down, inputArray);
            Console.WriteLine("{0} trees will be encountered with right {1}, down {2}", treesC, right, down);

            right = 7;
            down = 1;
            long treesD = calcSlopes(right, down, inputArray);
            Console.WriteLine("{0} trees will be encountered with right {1}, down {2}", treesD, right, down);

            right = 1;
            down = 2;
            long treesE = calcSlopes(right, down, inputArray);
            Console.WriteLine("{0} trees will be encountered with right {1}, down {2}", treesE, right, down);

            long mult = treesA * treesB * treesC * treesD * treesE;

            Console.WriteLine("The multiplicated answer is: "+ mult);

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
