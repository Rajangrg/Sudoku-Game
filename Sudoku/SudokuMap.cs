using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    //a physical map to enter number for user
    class SudokuMap: IGet, ISet
    {
        public int mainArrayIndex;
        public int[] mainArray;
        public int size;
        public int sqrHeight;
        public int sqrWidth;

        // all the data are passed from sodokuGame
        public void InnitialiseMap(int newSize, int newSqrHeight, int newSqrWidth, int[] newMainArray)
        {
            size = newSize;
            sqrHeight = newSqrHeight;
            sqrWidth = newSqrWidth;
            mainArray = newMainArray;
        }

        public int GetByColumn(int columnIndex, int rowIndex)
        {
            //give value from the tile  when coloum and row index is given
            mainArrayIndex = columnIndex + rowIndex * size;
            return mainArray[mainArrayIndex];
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            //give value from the tile  when coloum and row index is given
            mainArrayIndex = columnIndex + rowIndex * size;
            return mainArray[mainArrayIndex];
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            //give value from the tile  when squareIndex and positionIndex  is given
            int sqrColIndex = (squareIndex % (size / sqrWidth)) * sqrWidth + (positionIndex % sqrWidth);
            int sqrRowIndex = (squareIndex / (size / sqrWidth)) * sqrHeight + (positionIndex / sqrWidth);

            mainArrayIndex = sqrColIndex + sqrRowIndex * size;
            return mainArray[mainArrayIndex];
        }

        public int truncate(int intDividend, int intDivisor)
        {
            //remove the deciaml toward zero
            double dividend = Convert.ToDouble(intDividend);
            double divisor = Convert.ToDouble(intDivisor);
            return (int)(Math.Truncate(dividend / divisor));
        }

        public int findSquareIndex(int index)
        {
            //finding a sqare with the big square
            int numOfBigCols = size / sqrWidth;
            int bigRowIndex = this.truncate(this.truncate(index, size), sqrHeight) + 1;
            int bigColIndex = this.truncate(index % size, sqrWidth) + 1;

            return (numOfBigCols * (bigRowIndex - 1) + bigColIndex) - 1;
        }

        public int[] findSameSquareValues(int originalIndex)
        {
            //its gives all the values from the square (small sqaure)
            int sqrIndex = this.findSquareIndex(originalIndex);
            int[] sameSquareValues = new int[size];

            for (int i = 0; i < size; i++)
            {
                sameSquareValues[i] = this.GetBySquare(sqrIndex, i);
            }

            return sameSquareValues;
        }

        public int[] findSameColumnValues(int originalIndex, int size)
        {
            // its gives the values of the whole column from the map.
            int[] columnIndexes = new int[size];
            int counter = 0;
            int lastIndex = size * size - 1;
            int currentIndex = originalIndex;

            while (currentIndex - size >= 0)
            {
                currentIndex -= size;
                columnIndexes[counter] = currentIndex;
                counter++;
            }

            columnIndexes[counter] = originalIndex;
            counter++;
            currentIndex = originalIndex;

            while (currentIndex + size <= lastIndex)
            {
                currentIndex += size;
                columnIndexes[counter] = currentIndex;
                counter++;
            }

            int[] values = new int[size];
            for (int i = 0; i < size; i++)
            {
                values[i] = mainArray[columnIndexes[i]];
            }
            return values;
        }

        public int[] findSameRowValues(int originalIndex, int size)
        {
            //// its gives the values of the whole row from the map.
            int[] rowIndexes = new int[size];
            int counter = 0;
            int currentIndex = originalIndex;

            while (currentIndex % size > 0) // add all indexes to the left of originalIndex
            {
                currentIndex--;
                rowIndexes[counter] = currentIndex;
                counter++;
            }

            rowIndexes[counter] = originalIndex;
            counter++;
            currentIndex = originalIndex;

            while (currentIndex % size < size - 1) // add all indexes to the right of originalIndex
            {
                currentIndex++;
                rowIndexes[counter] = currentIndex;
                counter++;
            }

            int[] values = new int[size];
            for (int i = 0; i < size; i++)
            {
                values[i] = mainArray[rowIndexes[i]];
            }
            return values;
        }

        public int[] getMainArray()
        {
            // return all the array
            return this.mainArray;
        }

        public void updateMainArray(int[] newMainArray)
        {
            // once user enter a different number update the array.
            this.mainArray = newMainArray;
        }

        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            // set the number in the tile if the column and row index is given including the value.
            mainArrayIndex = columnIndex + rowIndex * size;
            mainArray[mainArrayIndex] = value;
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            // set the number in the tile if the column and row index is given including the value.
            mainArrayIndex = columnIndex + rowIndex * size;
            mainArray[mainArrayIndex] = value;
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            // set the number in the tile if the squareIndex and positionIndex is given including the value.
            int sqrColIndex = (squareIndex % (size / sqrWidth)) * sqrWidth + (positionIndex % sqrWidth);
            int sqrRowIndex = (squareIndex / (size / sqrWidth)) * sqrHeight + (positionIndex / sqrWidth);

            mainArrayIndex = sqrColIndex + sqrRowIndex * size;
            mainArray[mainArrayIndex] = value;
        }
    }
}
