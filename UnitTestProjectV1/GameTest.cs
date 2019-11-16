using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace UnitTestProject_SudokuFileHandler
{
    [TestClass]
    public class GameTest
    {
        SudokuGame game;

        [TestInitialize]
        public void testInit()
        {
            int size = 9;
            int sqrHeight = 3;
            int sqrWidth = 3;
            int[] array = { 7,3,5,6,1,4,8,9,2,
                            8,4,2,9,7,3,5,6,1,
                            9,6,1,2,8,5,3,7,4,
                            2,8,6,3,4,9,1,5,7,
                            4,1,3,8,5,7,9,2,6,
                            5,7,9,1,2,6,4,3,8,
                            1,5,7,4,9,2,6,8,3,
                            6,9,4,7,3,8,2,1,5,
                            3,2,8,5,6,1,7,4,9};

            game = new SudokuGame();
            game.SetMaxValue(size);
            game.SetSquareHeight(sqrHeight);
            game.SetSquareWidth(sqrWidth);
            game.Set(array);
            game.InnitialiseSudokuMap();
        }

        [TestCleanup]
        public void testClean()
        {
            game = null;
        }

        [TestMethod]
        public void SudokuMap_SetArray_Test()
        {
            int[] array = { 7,3,5,6,1,4,8,9,2,
                            8,4,2,9,7,3,5,6,1,
                            9,6,1,2,8,5,3,7,4,
                            2,8,6,3,4,9,1,5,7,
                            4,1,3,8,5,7,9,2,6,
                            5,7,9,1,2,6,4,3,8,
                            1,5,7,4,9,2,6,8,3,
                            6,9,4,7,3,8,2,1,5,
                            3,2,8,5,6,1,7,4,99999};
            game.Set(array);
            game.InnitialiseSudokuMap();
            int[] retrieved = game.ToArray();

            CollectionAssert.AreEqual(array, retrieved, "Retrieved array is incorrect");
        }

        [TestMethod]
        public void SudokuMap_SendAndGetDataToMapViaColumn_Test()
        {
            game.SetByColumn(333, 5, 4);
            int value = game.GetByColumn(5, 4);
            int expected = 333;

            Assert.AreEqual(expected, value, "Number is not set correctly");
        }

        [TestMethod]
        public void SudokuMap_SendAndGetDataToMapViaRow_Test()
        {
            game.SetByRow(444, 6, 2);
            int value = game.GetByRow(6, 2);
            int expected = 444;

            Assert.AreEqual(expected, value, "Number is not set correctly");
        }

        [TestMethod]
        public void SudokuMap_SendAndGetDataToMapViaSquare_Test()
        {
            game.SetBySquare(666, 2, 8);
            int value = game.GetBySquare(2, 8);
            int expected = 666;

            Assert.AreEqual(expected, value, "Number is not set correctly");
        }

        [TestMethod]
        public void SudokuMap_Restart_Test()
        {
            int[] array = { 7,3,5,6,1,4,8,9,2,
                            8,4,2,9,7,3,5,6,1,
                            9,6,1,2,8,5,3,7,4,
                            2,8,6,3,4,9,1,5,7,
                            4,1,3,8,5,7,9,2,6,
                            5,7,9,1,2,6,4,3,8,
                            1,5,7,4,9,2,6,8,3,
                            6,9,4,7,3,8,2,1,5,
                            3,2,8,5,6,1,7,4,888};
            game.Set(array);
            game.Restart();

            int[] expected = game.ToArray();

            CollectionAssert.AreEqual(expected, array, "Retrieved array is incorrect");
        }

        [TestMethod]
        public void SudokuMap_CheckAllColumnsAreValid_Test()
        {
            bool isValid = game.checkAllColumnsAreValids();

            Assert.IsTrue(isValid, "Not all columns are valid");

            //Input wrong array to check if false is returned
            int[] array = { 7,3,5,6,1,4,8,9,2,
                            8,4,2,9,7,3,5,6,1,
                            9,6,1,2,8,5,3,7,4,
                            2,8,6,3,4,9,1,5,7,
                            4,1,3,8,5,7,9,2,6,
                            5,7,9,1,2,6,4,3,8,
                            1,5,7,4,9,2,6,8,3,
                            6,9,4,7,3,8,2,1,5,
                            3,2,8,5,6,1,7,4,5}; // <- two 5 in same column
            game.Set(array);
            game.Restart();

            Assert.IsFalse(game.checkAllColumnsAreValids(), "All columns are valid");
        }

        [TestMethod]
        public void SudokMap_SetSquareWidth_Test()
        {
            int squareWidth = 5;
            game.SetSquareWidth(squareWidth);
            int result = game.GetSqrWidth();

            Assert.AreEqual(squareWidth, result);
        }
        [TestMethod]
        public void SudokMap_SetSquareHeight_Test()
        {
            int squareHeight = 10;
            game.SetSquareHeight(squareHeight);
            int result = game.GetSqrHeight();

            Assert.AreEqual(squareHeight, result);
        }
        [TestMethod]
        public void SudokMap_MAX_Test()
        {
            int maxSize = 5;
            game.SetMaxValue(maxSize);
            int result = game.GetMaxValue();

            Assert.AreEqual(maxSize, result);
        }

        [TestMethod]
        public void SudokuMap_CheckAllRowsAreValid_Test()
        {
            Assert.IsTrue(game.checkAllRowsAreValids(), "Not all rows are valid");

            //Input wrong array to check if false is returned
            int[] array = { 7,3,5,6,1,4,8,9,2,
                            8,4,2,9,7,3,5,6,1,
                            9,6,1,2,8,5,3,7,4,
                            2,8,6,3,4,9,1,5,7,
                            4,1,3,8,5,7,9,2,6,
                            5,7,9,1,2,6,4,4,8, // <- two 4 in same row
                            1,5,7,4,9,2,6,8,3,
                            6,9,4,7,3,8,2,1,5,
                            3,2,8,5,6,1,7,4,9};
            game.Set(array);
            game.Restart();

            Assert.IsFalse(game.checkAllRowsAreValids(), "All rows are valid");
        }

        [TestMethod]
        public void SudokuMap_CheckAllSquaresAreValid_Test()
        {
            Assert.IsTrue(game.checkAllSquaresAreValids(), "Not all rows are valid");

            //Input wrong array to check if false is returned
            int[] array = { 7,3,5,6,1,4,8,9,2,
                            8,4,2,9,7,3,5,6,1,
                            9,6,1,2,8,5,3,7,4,
                            2,8,6,3,4,9,1,5,7,
                            4,1,3,8,5,7,9,2,6,
                            5,7,9,1,2,6,4,3,8,
                            1,5,7,4,9,2, 6,8,3,
                            6,9,4,7,3,8, 2,5,5, // <- two 5 in same square
                            3,2,8,5,6,1, 7,4,9};
            game.Set(array);
            game.Restart();

            Assert.IsFalse(game.checkAllSquaresAreValids(), "All rows are valid");
        }

        [TestMethod]
        public void SudokuMap_CheckAllNumbersAreValid_Test()
        {
            Assert.IsTrue(game.allNumbersAreUnique(), "Not all numbers are valid");

            //Input wrong array to check if false is returned
            int[] array = { 7,3,5,6,1,4,8,9,2,
                            8,4,2,9,7,3,5,6,1,
                            9,6,1,2,8,5,3,7,4,
                            2,8,6,3,4,9,1,5,7,
                            4,1,3,8,5,7, 2,2, 6, // <- two 2 in same row
                            5,7,9,1,2,6,4,3,8,
                            1,5,7,4,9,2, 6,8,3,
                            6,9,4,7,3,8, 2,5,5, // <- two 5 in same square
                            3,2,8,5,6,1, 7,4,9};
            game.Set(array);
            game.Restart();

            Assert.IsFalse(game.allNumbersAreUnique(), "All rows are valid");
        }



        [TestMethod]
        public void SudokuMap_FindSameColumnValues_Test()
        {

            /* 7,3,5,6,1,4,8, 9, 2,
               8,4,2,9,7,3,5, 6, 1,
               9,6,1,2,8,5,3, 7, 4, //index 25 is 7
               2,8,6,3,4,9,1, 5, 7,
               4,1,3,8,5,7,9, 2, 6,
               5,7,9,1,2,6,4, 3, 8,
               1,5,7,4,9,2,6, 8, 3,
               6,9,4,7,3,8,2, 1, 5,
               3,2,8,5,6,1,7, 4, 9 */

            int[] retrieved = game.findSameColumnValues(25);
            int[] expected = { 6, 9, 7, 5, 2, 3, 8, 1, 4 };

            CollectionAssert.AreEqual(expected, retrieved);
        }

        [TestMethod]
        public void SudokuMap_FindSameRowValues_Test()
        {

            /* 7,3,5,6,1,4,8,9,2,
               8,4,2,9,7,3,5,6,1,

               9,6,1,2,8,5,3,7,4, //index 25 is 7

               2,8,6,3,4,9,1,5,7,
               4,1,3,8,5,7,9,2,6,
               5,7,9,1,2,6,4,3,8,
               1,5,7,4,9,2,6,8,3,
               6,9,4,7,3,8,2,1,5,
               3,2,8,5,6,1,7,4,9 */

            int[] retrieved = game.findSameRowValues(25);
            int[] expected = { 3, 5, 8, 2, 1, 6, 9, 7, 4 };

            CollectionAssert.AreEqual(expected, retrieved);
        }

        [TestMethod]
        public void SudokuMap_FindSameSquareValues_Test()
        {

            /* 7,3,5,6,1,4,8,9,2,
               8,4,2,9,7,3,5,6,1,
               9,6,1,2,8,5,3,7,4,
               2,8,6,3,4,9,1,5,7,
               4,1,3,8,5,7,9,2,6,
               5,7,9,1,2,6,4,3,8,
               1,5,7,4,9,2, 6,8,3,
               6,9,4,7,3,8, 2,1,5, // <- The square index 80 belongs
               3,2,8,5,6,1, 7,4,9 */

            int[] retrieved = game.findSameSquareValues(80);
            int[] expected = { 6, 8, 3, 2, 1, 5, 7, 4, 9 };

            CollectionAssert.AreEqual(expected, retrieved);
        }
    }
}
