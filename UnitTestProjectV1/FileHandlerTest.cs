using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System.Collections;

namespace UnitTestProject_SudokuFileHandler
{
    [TestClass]
    public class FileHandlerTest
    {
        [TestMethod]
        public void SudokuFilehandle_readFile()
        {
            //Arrange
            SudokuFileHandler fileHandler = new SudokuFileHandler();
            string input = "1,2,3,4,4,3,1,2,2,1,4,3,3,4,2,1";

            string result = fileHandler.readFile(input);
            string expected = "1234431221433421";

            //Assert
            Assert.AreEqual(expected, result, "The load file output is wrong");
        }

        [TestMethod]
        public void Sudokufilehandle_convertToArray()
        {
            //Arrange
            SudokuFileHandler fileHandler = new SudokuFileHandler();
            string input = "1234431221433421";

            int[] map = fileHandler.convertToArray(input);
            int[] expected = { 1, 2, 3, 4, 4, 3, 1, 2, 2, 1, 4, 3, 3, 4, 2, 1 };

            //Assert
            CollectionAssert.AreEqual(expected, map, "The file in not an array of integers");
        }

        [TestMethod]
        public void Sudokufilehandle_calculateRowStarts()
        {
            //Arrange
            SudokuFileHandler fileHandler = new SudokuFileHandler();
            int userInput = 4;

            ArrayList map = fileHandler.calculateRowStarts(userInput);
            ArrayList expected = new ArrayList { 0, 4, 8, 12 };

            //Assert
            //checking only the rows from the square
            Assert.AreEqual(expected[0], map[0], "The index doesnt match");
            Assert.AreEqual(expected[1], map[1], "The index doesnt match");
            Assert.AreEqual(expected[2], map[2], "The index doesnt match");
            Assert.AreEqual(expected[3], map[3], "The index doesnt match");
        }

        [TestMethod]
        public void Sudokufilehandle_saveFile()
        {
            //Arrange
            SudokuFileHandler fileHandler = new SudokuFileHandler();

            int[] userInput = { 1, 2, 3, 4, 4, 3, 1, 2, 2, 1, 4, 3, 3, 4, 2, 1 };

            string output = fileHandler.saveFile(userInput);
            string expected = "1,2,3,4,4,3,1,2,2,1,4,3,3,4,2,1,";

            //Assert
            // checking is it the right format
            Assert.AreEqual(expected, output, "save not succesfull");
        }
    }
}
