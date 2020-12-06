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
            
            int validCnt = 0;

            StreamReader streamReader = new StreamReader(@"..\..\..\input\05.txt");

            getArrayFromTxt(streamReader, out inputArray);

            int[] ids = getIdList(inputArray, 127, 7);

            int[,] fullIds = getFullIdList(127, 7);

            int maxID = 0;

            for(int i = 0; i < ids.Length-1; i++)
            {
                if(maxID < Math.Max(ids[i], ids[i + 1]))
                    maxID = Math.Max(ids[i], ids[i + 1]);            
            }

            Console.WriteLine("The highest ID is {0}", maxID);

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

        public static int[] getIdList(string[] inputArray, int maxRow, int maxCol)
        {
            int[] idList = new int[inputArray.Length];
            for(int i = 0; i < idList.Length; i++)
            {
                int row = getRow(inputArray[i], maxRow);
                int col = getCol(inputArray[i], maxCol);
                idList[i] = getId(row, col);
            }

            return idList;
        }

        public static int[,] getFullIdList(int rows, int cols)
        {
            int[,] result = new int[rows,cols];

            for(int i = 0; i < rows; i++)
            {
                for(int k = 0; k < cols; k++)
                {
                    result[i,k] = getId(i, k);
                }
            }

            return result;
        }

        public static int getRow(string input, int maxRow)
        {
            int minRow = 0;            
            double halves = Math.Log2(maxRow + 1);

            for(int i = 0; i < halves; i++)
            {
                switch (input[i])
                {
                    case 'B':
                        if (i == halves - 1)
                            return maxRow;
                        
                        minRow += ((maxRow - minRow) / 2) + 1;
                        break;
                        
                    case 'F':
                        if (i == halves - 1)
                            return minRow;                            
                                            
                        maxRow -= ((maxRow - minRow) / 2) + 1;
                        break;
                        
                }                
            }
            return -1;
        }

        public static int getCol(string input, int maxCol)
        {
            int minCol = 0;
            double halves = Math.Log2(maxCol + 1);

            for (int i = input.Length - (int) halves; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'R':
                        if(i == input.Length - 1)
                        {
                            return maxCol;
                        }
                        minCol += ((maxCol - minCol) / 2) + 1;
                        break;
                    case 'L':
                        if(i == input.Length - 1)
                        {
                            return minCol;
                        }
                        maxCol -= ((maxCol - minCol) / 2) + 1;
                        break;
                }
            }

            return -1;
        }

        public static int getId(int row, int col)
        {
            return row * 8 + col;
        }
        
    }
}
