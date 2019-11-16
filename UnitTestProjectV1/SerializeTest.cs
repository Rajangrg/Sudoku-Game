using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System.Collections;

namespace UnitTestProject_SudokuFileHandler
{
    [TestClass]
    public class SeralizeTest
    {
        [TestMethod]
        public void SudokuSerialize_loadFromCSV()
        {
            //Arrange

            SudokuSerialize serialize = new SudokuSerialize();
            string userInput = "1,2,3,4,4,3,1,2,2,1,4,3,3,4,2,1";

            serialize.FromCSV(userInput);
            int[] expected = { 1, 2, 3, 4, 4, 3, 1, 2, 2, 1, 4, 3, 3, 4, 2, 1 };

            //Assert
            CollectionAssert.AreEqual(expected, serialize.getMap(), "CSV file cannot be loaded");
        }

        [TestMethod]
        public void SudokuSerialize_setAndGetCell()
        {
            //Aranage 
            SudokuSerialize serialize = new SudokuSerialize();
            string userInput = "1,2,3,4,4,3,1,2,2,1,4,3,3,4,2,1";
            serialize.FromCSV(userInput);

            serialize.SetCell(99999, 5); //changing the number from 4 to 99999 of posiiton 5 
            int expected = 99999;
            int result = serialize.GetCell(5); //looking for index nmber 5
            
            //Assert
            Assert.AreEqual(expected, result, "the get and set value is not same");
        }
        [TestMethod]
        public void SudokuSerialize_saveToCSV()
        {
            SudokuSerialize serialize = new SudokuSerialize();

            serialize.FromCSV("1,2,3,4,4,3,1,2,2,1,4,3,3,4,2,1"); //this is taking userinput

            string result = serialize.ToCSV();
            string expected = "1,2,3,4,4,3,1,2,2,1,4,3,3,4,2,1,";

           Assert.AreEqual(expected, result, "CSV file cannot be saved");
        }
    }
}
