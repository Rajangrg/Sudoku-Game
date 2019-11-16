using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sudoku
{
    ////check the validation for the game
    class SudokuValidator 
    {
        // we wrote this code to make sure that that size is not bigger than 9 and smaller than 4
        public bool mapInValidRange(int size)
        {
            if (size < 4 || size > 9)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool mapSizeIsNotPrime(int size)
        {
            // its must not be prime number because it cant make a grid for eg: 7*7
            bool result = false;
            for (int i = 2; i <= size / 2; i++)
            {
                if (size % i == 0) // If size is a not a prime number <- valid
                {
                    result = true;
                }
            }
            return result;
        }

        public bool fileIsNotEmpty(string path)
        {
            //CSV file should not be empty while loading
            if ( new FileInfo(path).Length == 0 )
            {
                return false;
            } else
            {
                return true;
            }
        }

        public bool isCSVFile(string path)
        {
            //file foramt must alwasy be CSV file.
            string extenstion = Path.GetExtension(path);
            if (extenstion == ".csv")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isValidSquareSize(int size, int width, int height)
        {
            //once the max size is generated the small sqare must be valid. for example for size 4 2*2 
            if (width * height == size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validUserInput(int number, int size)
        {
            // input must be between 1 and map size if maximum size is 5 then below than 5
            if (number < 1 || number > size) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool allNumsAreUnique(int[] numbers, int size)
        {
            // check all the number insiide the array is unique.
            bool result = true;
            for (int i = 1; i <= size; i++)
            {
                if (!numbers.Contains(i))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
        
    }
}
