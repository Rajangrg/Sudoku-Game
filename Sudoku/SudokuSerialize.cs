using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    //read from and save to CSV file
    class SudokuSerialize : ISerialize
    {
        private SudokuFileHandler fileHandler;
        private int[] map;
        

        public SudokuSerialize()
        {
            this.fileHandler = new SudokuFileHandler();
        }

        public void FromCSV(string csv)
        {
            //loading the CSV
            string result = fileHandler.readFile(csv);
            this.map = fileHandler.convertToArray(result);
        }

        public int GetCell(int gridIndex)
        {
            // if retrive the number set by the user
            return this.map[gridIndex];
        }

        public void SetCell(int value, int gridIndex)
        {
            //it help the user to set the value
            this.map[gridIndex] = value;
        }

        public string ToCSV() // This will save to file in the future. For now it only returns a string.
        {
            // helps to save the CSV.
            return fileHandler.saveFile(this.map);
        }

        public string ToPrettyString() // This will output what will be written in the file.
        {
            // saving in to the string
            return this.ToCSV();
        }

        public int[] getMap()
        {
            // its helps to generate the array.
            return this.map;
        }
    }
}
