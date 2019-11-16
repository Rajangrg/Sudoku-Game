using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    //initialize the data for the game.
    class SudokuGame : IGame
    {
        private int maxValue;
        private int sqrHeight;
        private int sqrWidth;
        public int[] map;
        private SudokuValidator validator;
        private SudokuMap sudokuMap;

        public SudokuGame()
        {
            this.validator = new SudokuValidator();
            this.sudokuMap = new SudokuMap();
        }

        public int GetMaxValue()
        {
            return this.maxValue;
        }

        public void InnitialiseSudokuMap()
        {
            //helps to send data to  the sodokuMap.
            this.sudokuMap.InnitialiseMap(this.maxValue, this.sqrHeight, this.sqrWidth, this.map);
        }

        public void Restart()
        {
            // bring back the orginial map
            this.sudokuMap.updateMainArray(this.map);
        }

        public void Set(int[] cellValues)
        {
            // receiving the map from the sudokoserialize.
            int[] map = new int[cellValues.Length];
            for (int i = 0; i < cellValues.Length; i++)
            {
                map[i] = cellValues[i];
            }

            this.map = map;
        }

        public void SetMaxValue(int maximum)
        {
            //4*4
            this.maxValue = maximum;
        }

        public void SetSquareHeight(int squareHeight)
        {
            // if 4 set to 2*2
            this.sqrHeight = squareHeight;
        }

        public void SetSquareWidth(int squareWidth)
        {
            // if 4 set to 2*2
            this.sqrWidth = squareWidth;
        }

        public int[] ToArray()
        {
            // reterive the map
            return this.sudokuMap.getMainArray();
        }

        public int GetSqrHeight()
        {
            return this.sqrHeight;
        }

        public int GetSqrWidth()
        {
            return this.sqrWidth;
        }
        
        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            //all the features of SodokuMap
            this.sudokuMap.SetByColumn(value, columnIndex, rowIndex);
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            this.sudokuMap.SetByRow(value, rowIndex, columnIndex);
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            this.sudokuMap.SetBySquare(value, squareIndex, positionIndex);
        }

        public int GetByColumn(int columnIndex, int rowIndex)
        {
            return this.sudokuMap.GetByColumn(columnIndex, rowIndex);
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            return this.sudokuMap.GetByRow(rowIndex, columnIndex);
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            return this.sudokuMap.GetBySquare(squareIndex, positionIndex);
        }

        public int[] findSameSquareValues(int originalIndex)
        {
            return this.sudokuMap.findSameSquareValues(originalIndex);
        }

        public int[] findSameColumnValues(int originalIndex)
        {
            return this.sudokuMap.findSameColumnValues(originalIndex, this.maxValue);
        }

        public int[] findSameRowValues(int originalIndex)
        {
            return this.sudokuMap.findSameRowValues(originalIndex, this.maxValue);
        }

        public bool checkAllColumnsAreValids()
        {
            //check all the column inisde the map is valid.  
            bool result = true;
            for (int i = 0; i < this.maxValue; i++)
            {

                if (!this.validator.allNumsAreUnique(this.findSameColumnValues(i), this.maxValue))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public bool checkAllRowsAreValids()
        {
           //check all the row inisde the map is valid.  
            bool result = true;
            for (int i = 0; i < this.maxValue; i++)
            {

                if (!this.validator.allNumsAreUnique(this.findSameRowValues(this.maxValue * i), this.maxValue))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public bool checkAllSquaresAreValids()
        {
            //check all the number inside the sqaure is valid from the big the map is valid.  
            bool result = true;
            for (int sqrIndex = 0; sqrIndex < this.maxValue; sqrIndex++)
            {
                int[] values = new int[this.maxValue];
                for (int posIndex = 0; posIndex < this.maxValue; posIndex++)
                {
                    values[posIndex] = sudokuMap.GetBySquare(sqrIndex, posIndex);
                }

                if (!this.validator.allNumsAreUnique(values, this.maxValue))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public bool allNumbersAreUnique()
        {
            //if all true user win the puzzle
            if (this.checkAllColumnsAreValids() && this.checkAllRowsAreValids() && this.checkAllSquaresAreValids())
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
