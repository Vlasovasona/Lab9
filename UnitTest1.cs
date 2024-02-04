using ConsoleApp2;
namespace Тесты
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            ChessboardCell cell = new ChessboardCell(1,1);
            //Act
            ChessboardCell actual = new ChessboardCell();
            //Assert
            Assert.AreEqual(cell, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            ChessboardCell cell = new ChessboardCell(2, 2);
            //Act
            ChessboardCell actual = new ChessboardCell(2, 2);
            //Assert
            Assert.AreEqual(cell, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.ThrowsException<Exception>(() => { new ChessboardCell(9, 10); });
        }

        [TestMethod]
        public void TestMethod4()
        {
            ChessboardCell cell1 = new ChessboardCell(3,3);
            ChessboardCell cell2 = new ChessboardCell(cell1);
            Assert.AreEqual(cell1, cell2);

        }

        [TestMethod]
        public void TestMethod5()
        {
            ChessboardCell cell1 = new ChessboardCell(3, 3);
            ChessboardCell cell2 = new ChessboardCell(5, 5);
            bool result = cell1.BlackOrWhite(cell1, cell2);
            Assert.AreEqual(result, ChessboardCell.Same(cell1, cell2));

        }

        [TestMethod]
        public void TestMethod6()
        {
            ChessboardCell cell1 = new ChessboardCell(3, 3);
            ChessboardCell cell2 = new ChessboardCell(4, 4);
            ChessboardCell cellFalse = new ChessboardCell(8, 4);
            Assert.AreEqual(cell2, ++cell1);
            Assert.AreEqual(cellFalse, ++cellFalse);
        }

        [TestMethod]
        public void TestMethod7()
        {
            ChessboardCell cell1 = new ChessboardCell(5, 3);
            ChessboardCell cell2 = new ChessboardCell(3, 5);
            Assert.AreEqual(cell2, !cell1);
        }

        [TestMethod]
        public void TestMethod8()
        {
            ChessboardCell cell1 = new ChessboardCell(5, 3);
            int a = 8;
            Assert.AreEqual(a, (int)cell1);
        }

        [TestMethod]
        public void TestMethod9() 
        {
            ChessboardCell cell1 = new ChessboardCell(5, 3);
            string a = "Черная клетка";
            Assert.AreEqual(a, cell1);
            ChessboardCell cell2 = new ChessboardCell(6, 3);
            string b = "Белая клетка";
            Assert.AreEqual(b, cell2);
        }

        [TestMethod]
        public void TestMethod10()
        {
            ChessboardCell cell1 = new ChessboardCell(1, 1);
            ChessboardCell cell2 = new ChessboardCell(2, 3);
            ChessboardCell cell3 = new ChessboardCell(2, 2);
            bool b = true;
            bool a = false;
            Assert.AreEqual(b, cell2==cell1);
            Assert.AreEqual(b, cell2 != cell1);
            Assert.AreEqual(a, cell2 == cell3);
            Assert.AreEqual(a, cell2 != cell3);
        }

        [TestMethod]
        public void TestMethod11()
        {
            ChessboardCellArray arr = new ChessboardCellArray(4,1);
            Assert.ThrowsException<Exception>(() => { new ChessboardCell(arr[6]); });
        }

        [TestMethod]
        public void TestMethod12()
        {
            ChessboardCellArray arr = new ChessboardCellArray();
            ChessboardCellArray arr1 = new ChessboardCellArray(arr);
            Assert.AreEqual(arr[0].x, 1);
            Assert.AreEqual(arr[0].y, 1);
            Assert.AreEqual(arr1[0].x, 1);
            Assert.AreEqual(arr1[0].y, 1);
        }

        [TestMethod]
        public void TestMethod13()
        {
            ChessboardCellArray arr = new ChessboardCellArray(5,1);
            Assert.ThrowsException<Exception>(() => { Console.WriteLine(arr[10]); ; });
        }

        [TestMethod]
        public void TestMethod14()
        {
            ChessboardCellArray arr = new ChessboardCellArray(5, 1);
            arr[0] = new ChessboardCell(2, 4);
            Assert.AreEqual(arr[0], new ChessboardCell(2,4));
        }

    }
}