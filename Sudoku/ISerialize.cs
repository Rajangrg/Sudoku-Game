using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    interface ISerialize
    {
        void FromCSV(string csv); // read from csv
        string ToCSV(); // write to csv
        void SetCell(int value, int gridIndex);  // insert value to mainArray
        int GetCell(int gridIndex);  // get value from mainArray
        string ToPrettyString();
    }
}
