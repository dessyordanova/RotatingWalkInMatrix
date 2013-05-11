using System;
using System.Collections.Generic;

namespace RotatingWalkInMatrix
{
    public class RotatingWalkInMatrix
    {
        static void Main(string[] args)
        {
            int matrixSize = ReadUserInput();
            GameEngine gameEngine = new GameEngine(matrixSize);
            Console.WriteLine(gameEngine.Run());          
        }

        public static int ReadUserInput()
        {
            string input = string.Empty;
            int matrixSize = 0;

            do
            {
                Console.WriteLine("Enter a positive matrix size between 1 and 100: ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out matrixSize) || matrixSize < 1 || matrixSize > 100);

            return matrixSize;
        }
    }
}