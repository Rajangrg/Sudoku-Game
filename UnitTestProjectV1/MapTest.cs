using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace SudoUnitTestProject_SudokuFileHandlerkuTest
{
    [TestClass]
    public class MapTest
    {
        SudokuMap map;

        [TestInitialize]
        public void testInit()
        {
            int size = 4;
            int sqrHeight = 2;
            int sqrWidth = 2;
            int[] array = { 1, 2, 3, 4,
                            4, 3, 1, 2,
                            2, 1, 4, 3,
                            3, 4, 2, 1 };

            map = new SudokuMap();
            map.InnitialiseMap(size, sqrHeight, sqrWidth, array);
        }

        [TestCleanup]
        public void testClean()
        {
            map = null;
        }

        [TestMethod]
        public void SudokuMap_GetByColumns_Test()
        {
            int result = map.GetByColumn(2, 0);
            int expected = 3;
            Assert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_GetByRows_Test()
        {
            int result = map.GetByRow(3, 1);
            int expected = 4;
            Assert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_GetBySquare_Test()
        {
            int result = map.GetBySquare(1, 3);
            int expected = 2;
            Assert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_Truncate_Test()
        {
            int result = map.truncate(5, 3);
            int expected = 1;
            Assert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_FindSquareIndex_Test()
        {
            int result = map.findSquareIndex(12);
            int expected = 2;
            Assert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_FindSameSquareValues_Test()
        {
            int[] result = map.findSameSquareValues(9);
            int[] expected = {2, 1, 3, 4};
            CollectionAssert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_FindSameColumnValues_Test()
        {
            int[] result = map.findSameColumnValues(8, 4);
            int[] expected = { 4, 1, 2, 3 };
            CollectionAssert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_FindSameRowValues_Test()
        {
            int[] result = map.findSameRowValues(8, 4);
            int[] expected = { 2, 1, 4, 3 };
            CollectionAssert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_SetByColumn_Test()
        {
            map.SetByColumn(8, 3, 0);
            int result = map.GetByColumn(3, 0);
            int expected = 8;
            
            Assert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_SetByRow_Test()
        {
            map.SetByRow(6, 2, 3);
            int result = map.GetByRow(2, 3);
            int expected = 6;

            Assert.AreEqual(expected, result, "Wrong number");
        }

        [TestMethod]
        public void SudokuMap_SetBySquare_Test()
        {
            map.SetBySquare(7, 0, 2);
            int result = map.GetBySquare(0, 2);
            int expected = 7;

            Assert.AreEqual(expected, result, "Wrong number");
        }
        [TestMethod]
        public void SudokuMap_UpdateMainArray_Test()
        {
            int[] array = { 1, 2, 3, 4,
                            4, 3, 1, 2,
                            2, 1, 4, 3,
                            3, 4, 2, 222 };

            map.updateMainArray(array);
            int[] result = map.getMainArray();

            Assert.AreEqual(array, result, "Wrong number");
        }


    }
}
