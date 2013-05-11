using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RotatingWalkInMatrix.Tests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void GameEngineMatrixSizeSix()
        {
            int matrixSize = 6;
            GameEngine gameEngine = new GameEngine(matrixSize);
            string actual = gameEngine.Run();
            string expected = "  1| 16| 17| 18| 19| 20|\n" +
                              "------------------------\n" +
                              " 15|  2| 27| 28| 29| 21|\n" +
                              "------------------------\n" +
                              " 14| 31|  3| 26| 30| 22|\n" +
                              "------------------------\n" +
                              " 13| 36| 32|  4| 25| 23|\n" +
                              "------------------------\n" +
                              " 12| 35| 34| 33|  5| 24|\n" +
                              "------------------------\n" +
                              " 11| 10|  9|  8|  7|  6|\n" +
                              "------------------------\n";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GameEngineMatrixSizeOne()
        {
            int matrixSize = 1;
            GameEngine gameEngine = new GameEngine(matrixSize);
            string actual = gameEngine.Run();
            string expected = "  1|\n" +
                              "----\n";
            Assert.AreEqual(expected, actual);
        }
    }
}