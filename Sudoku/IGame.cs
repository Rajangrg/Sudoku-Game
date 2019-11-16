using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    interface IGame
    {
        void SetMaxValue(int maximum); // For the map size
        int GetMaxValue(); 
        int[] ToArray(); // convert to 1d array
        void Set(int[] cellValues); // randomly inserting number into the array
        void SetSquareWidth(int squareWidth); // set width of square 3 in 2x3
        void SetSquareHeight(int squareHeight); // set height of square 2 in 2x3
        void Restart(); // reload to earliest version of the map

    }
}
