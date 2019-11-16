using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace UnitTestProject_SudokuFileHandler
{
    [TestClass]
    public class ValidatorTest
    {
        SudokuValidator validator = new SudokuValidator();

        [TestMethod]
        public void SudokuValidator_MapInValidRange_Test()
        {
            int invalidSize = 3;
            int validSize = 6;

            Assert.IsTrue(validator.mapInValidRange(validSize));
            Assert.IsFalse(validator.mapInValidRange(invalidSize));
        }

        [TestMethod]
        public void SudokuValidator_MapSizeNotPrime_Test()
        {
            int invalidSize = 5;
            int validSize = 4;

            Assert.IsTrue(validator.mapSizeIsNotPrime(validSize));
            Assert.IsFalse(validator.mapSizeIsNotPrime(invalidSize));
        }

        [TestMethod]
        public void SudokuValidator_FileIsNotEmpty_Test()
        {
            string file = "..\\..\\..\\..\\Sudoku\\example.csv";
            string emptyFile = "..\\..\\..\\..\\Sudoku\\blank.csv";

            Assert.IsTrue(validator.fileIsNotEmpty(file));
            Assert.IsFalse(validator.fileIsNotEmpty(emptyFile));
        }

        [TestMethod]
        public void SudokuValidator_IsCSVFile_Test()
        {
            string file = "..\\..\\..\\..\\Sudoku\\example.csv";
            string notCSV = "..\\..\\..\\..\\Sudoku\\notCSV.txt";

            Assert.IsTrue(validator.isCSVFile(file));
            Assert.IsFalse(validator.isCSVFile(notCSV));
        }

        [TestMethod]
        public void SudokuValidator_IsValidSquareSize_Test()
        {
            int size = 6; //6x6 map
            int[] validSize = { 2, 3 }; //2x3 square
            int[] invalidSize = { 2, 2 }; //2x2 square

            Assert.IsTrue(validator.isValidSquareSize(size, validSize[0], validSize[1]));
            Assert.IsFalse(validator.isValidSquareSize(size, invalidSize[0], invalidSize[1]));
        }

        [TestMethod]
        public void SudokuValidator_IsValidUserInput_Test()
        {
            int size = 6; //6x6 map
            int input = 5;
            int invalidInput = 8;

            Assert.IsTrue(validator.validUserInput(input, size));
            Assert.IsFalse(validator.validUserInput(invalidInput, size));
        }

        [TestMethod]
        public void SudokuValidator_AllNumbersAreUnique_Test()
        {
            int size = 9;
            int[] allUniqueNums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] nonUniqueNums = { 1, 1, 2, 3, 4, 5, 6, 7, 8 };

            Assert.IsTrue(validator.allNumsAreUnique(allUniqueNums, size));
            Assert.IsFalse(validator.allNumsAreUnique(nonUniqueNums, size));
        }
    }
}
