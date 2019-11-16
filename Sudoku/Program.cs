using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {

            /*        int size = 4;
                    int sqrHeight = 2;
                    int sqrWidth = 2;
                    string path = "D:\\Assignment1_final\\Sudoku\\example.csv";

                    SudokuSerialize serialize = new SudokuSerialize();
                    serialize.FromCSV(path);
                    int[] map = serialize.getMap();*/

            /*foreach (var item in map)
            {
                Console.Write(item + ", ");

            }

            Console.WriteLine();*/

            /*  SudokuGame game = new SudokuGame();
              game.SetMaxValue(size);
              game.SetSquareHeight(sqrHeight);
              game.SetSquareWidth(sqrWidth);
              game.Set(map);
              game.InnitialiseSudokuMap();*/

            /*game.SetByColumn(2, 1, 0);
            //game.SetByColumn(4, 2, 2);
            game.SetByRow(4, 0, 2);
            game.SetBySquare(4, 0, 2);*/

            //Testing getmethods
            /*Console.WriteLine( game.GetByColumn(1, 0));
            Console.WriteLine( game.GetByRow(0, 2));
            Console.WriteLine(game.GetBySquare(0, 2));*/

            //Testing setmethods
            /*int[] retrievedMap = game.ToArray();

            foreach (var item in retrievedMap)
            {
                Console.Write(item + ", ");

            }
            Console.WriteLine();*/
            /*foreach (var item in game.map)
            {
                Console.Write(item + ", ");

            }*/

            /*int[] valuesC = game.findSameColumnValues(6);
            foreach (var item in valuesC)
            {
                Console.Write(item + ", ");

            }
            Console.WriteLine();
            int[] valuesR = game.findSameRowValues(6);
            foreach (var item in valuesR)
            {
                Console.Write(item + ", ");

            }
            Console.WriteLine();
            int[] valuesS = game.findSameSquareValues(6);
            foreach (var item in valuesR)
            {
                Console.Write(item + ", ");

            }*/

            /*   if(game.allNumbersAreUnique())
               {
                   Console.WriteLine("Pass");
               }
               else
               {
                   Console.WriteLine("Fail");
               }
   */



            /*SudokuGet get = new SudokuGet(4, 2, 2, map);
            int index = 5;
            int[] values = get.findSameSquareValues(index);

            foreach (var item in values)
            {
                Console.Write(item + ", ");

            }*/

            // string result = File.ReadAllText(path);

            // foreach (var item in map) { Console.Write(item);} 
            /*string path = "D:\\assigmnet1\\Sudoku\\Sudoku\\example.csv";
            SudokuFileHandler a = new SudokuFileHandler();
            a.setCsvPath(path);
            a.saveFile(map, 4);*/
            string path = "D:\\assigmnet1\\Sudoku\\Sudoku\\example.csv";
            SudokuFileHandler a = new SudokuFileHandler();
           
            string result = a.readFile(path);
            int[] map = a.convertToArray(result);

            foreach (var item in map)
            {
                Console.Write(item);

            }
            /*int mapSize = 6;
            int width = 2;
            int height = 2;
            SudokuValidator b = new SudokuValidator();
            if (b.isValidSquareSize(mapSize, width, height))
            {
                Console.WriteLine("Yes");
            } else
            {
                Console.WriteLine("NO");
            }*/

            /*SudokuValidator b = new SudokuValidator();
            SudokuFileHandler a = new SudokuFileHandler();
            int size = 4;
            string result = a.readFile(path);
            int[] map = a.convertToArray(result);

            int[] columnIndexes = b.findSameRowIndexes(10, size);
            int[] values = new int[size];

            for (int i = 0; i < columnIndexes.Length; i++)
            {
                values[i] = map[columnIndexes[i]];
            }

            if (b.allNumsAreUnique(values, size))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("NO");
            }


            foreach (var item in values)
            {
                Console.Write(item + ", ");
                
            }*/



        }
    }
}
