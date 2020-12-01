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
            List<int> entries;

            StreamReader streamReader = new StreamReader(@"..\..\01\01.txt");

            getListFromTxt(streamReader, out inputList);
            entries = getIntsFromStringList(inputList);
            int third = 0;

            foreach(int first in entries)
            {
                foreach(int second in entries)
                {
                    if((first + second) < 2020)
                    {
                        third = 2020 - first - second;
                        if (entries.Contains(third)){                            
                            Console.WriteLine("First value: {0}", first);
                            Console.WriteLine("Second value: {0}", second);
                            Console.WriteLine("Third value: {0}", third);
                            Console.WriteLine("Multiplied: {0}", first * second * third);
                            break;
                        }
                        third = 0;
                    }
                }
                if(third != 0)
                    break;
            }

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
    }
}
