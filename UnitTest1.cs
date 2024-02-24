using Library_10;

namespace UnitTeats
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorEmtyInstrument()
        {
            Instrument tool1 = new Instrument();
            Instrument tool2 = new Instrument("Нет инструмента", 1);
            Assert.AreEqual(tool1, tool2);
        }

        [TestMethod]
        public void ConstructorEmtyHandTool()
        {
            HandTool tool1 = new HandTool();
            HandTool tool2 = new HandTool(1, "Нет инструмента", "Нет материала");
            Assert.AreEqual(tool1, tool2);
        }

        [TestMethod]
        public void ConstructorEmtyMeaTool()
        {
            MeasuringTool tool1 = new MeasuringTool();
            MeasuringTool tool2 = new MeasuringTool(1, "Нет инструмента", "Нет единиц измерения", 0);
            Assert.AreEqual(tool1, tool2);
        }

        [TestMethod]
        public void ConstructorEmtyElTool()
        {
            ElectricTool tool1 = new ElectricTool();
            ElectricTool tool2 = new ElectricTool(1, "Нет инструмента", "Нет источника питания", 0);
            Assert.AreEqual(tool1, tool2);
        }

        [TestMethod]
        public void CheckExceptionElectric()
        {
            Assert.ThrowsException<Exception>(() => { new ElectricTool(9, "Лобзик", "Аккумулятор", -20); });
        }

        [TestMethod]
        public void CheckExceptionMeas()
        {
            Assert.ThrowsException<Exception>(() => { new MeasuringTool(9, "Линейка", "Сантиметры", -20); });
        }

        [TestMethod]
        public void CheckExceptionMeasAcc()
        {
            Assert.ThrowsException<Exception>(() => { new MeasuringTool(9, "Линейка", "Сантиметры", 10); });
        }

        [TestMethod]
        public void CheckRandomInstrument()
        {
            Instrument inst = new Instrument();
            inst.RandomInit();
            Assert.IsNotNull(inst);
        }

        [TestMethod]
        public void CheckClone()
        {
            Instrument inst = new Instrument();
            Instrument clone = (Instrument)inst.Clone();
            Assert.AreEqual(inst, clone);
        }

        [TestMethod]
        public void CheckCopy()
        {
            Instrument inst = new Instrument();
            Instrument copy = (Instrument)inst.ShallowCopy();
            Assert.AreEqual(inst, copy);
        }

        [TestMethod]
        public void CheckRandomHandTool()
        {
           HandTool tool = new HandTool();
            tool.RandomInit();
            Assert.IsNotNull(tool);
        }

        [TestMethod]
        public void CheckRandomElectricTool()
        {
            ElectricTool tool = new ElectricTool();
            tool.RandomInit();
            Assert.IsNotNull(tool);
        }

        [TestMethod]
        public void CheckRandomMeasTool()
        {
            MeasuringTool tool = new MeasuringTool();
            tool.RandomInit();
            Assert.IsNotNull(tool);
        }

        [TestMethod]
        public void CheckSort()
        {
            Instrument[] arr = new Instrument[2];
            arr[1] = new Instrument("Линейка", 2);
            arr[0] = new Instrument("Лобзик", 34);
            Array.Sort(arr);
            Assert.AreNotEqual(arr[0], new Instrument("Лобзик", 34));
        }

        [TestMethod]
        public void CheckSortByWorkingTime()
        {
            ElectricTool[] arr = new ElectricTool[2];
            arr[1] = new ElectricTool(2, "Болгарка", "Аккумулятор", 120);
            arr[0] = new ElectricTool(2, "Дрель", "Аккумулятор", 50);
            Array.Sort(arr, new SortByWorkingTime());
            Assert.AreEqual(arr[0], new ElectricTool(2, "Дрель", "Аккумулятор", 50));
        }

        [TestMethod]
        public void CheckID()
        {
            Assert.ThrowsException<Exception>(() => { new IdNumber(-23); });
        }

        [TestMethod]
        public void CheckIdString()
        {
            IdNumber number = new IdNumber(23);
            Assert.AreEqual("23", number.ToString());
        }

        [TestMethod]
        public void CheckIdEqual()
        {
            IdNumber number = new IdNumber(23);
            IdNumber number2 = new IdNumber(45);
            Assert.IsFalse(number.Equals(number2));
        }
    }
}