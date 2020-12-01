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

            foreach(int cur in entries)
            {
                int dif = 2020 - cur;
                if (entries.Contains(dif))
                {
                    Console.WriteLine("First value: {0}", cur);
                    Console.WriteLine("Second value: {0}", dif);
                    Console.WriteLine("Multiplied: {0}", cur * dif);
                    break;
                }
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
