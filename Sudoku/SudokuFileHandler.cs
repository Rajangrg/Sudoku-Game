using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sudoku
{
    //load and save the file
    class SudokuFileHandler
    {
        public string readFile(string path)
        {
            //load the csv file
            /*string result = File.ReadAllText(path);*/  //we will load from file 
            string result = path.Replace(",", "");
            return result;
        }

        public int[] convertToArray(string aString)
        {
            // convert the string into array
            int[] map = new int[aString.Length];
            int counter = 0;

            char[] charArr = aString.ToCharArray();
            foreach (char ch in charArr)
            {
                map[counter] = (int)Char.GetNumericValue(ch); // Use typecast to convert char into int
                counter++;
            }
            return map;
        }

        // For saveFile
        public ArrayList calculateRowStarts(int size)
        {
            // calculate the start of every rows.

            // this is giving index not values.
            ArrayList allMyStarts = new ArrayList();
            allMyStarts.Add(0);
            for (int i = 1; i < size; i++)
            {
                allMyStarts.Add(size * i);
            }
            return allMyStarts;
        }

        public string saveFile(int[] map)
        {
            // save the file and change to string when saved from int[].
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < map.Length; i++)
            {
                strBuilder.Append(map[i].ToString()); // Adding the value of map[index] as a string
                strBuilder.Append(",");
            }
            return strBuilder.ToString();
        }

        
    }
}
