using Microsoft.VisualStudio.TestTools.UnitTesting;
using DinamicalLibrary12;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {          
            // Тестирование метода определения количества слов
            Class1 Expected = new Class1("Сегодня хорошая погода, буду кушать суп.");
            int n = Expected.CountWrods();
            int Actual = 6;
            Assert.AreEqual(n, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod2()
        {            
            // Тестирование метода по варианту 3
            Class1 A = new Class1("Сегодня хорошая погода, буду кушать суп.");
            string Expected = A.Variant("с", true);
            string Actual = "Сегодня суп. ";
            Assert.AreEqual(Expected, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Тестирование операции ==
            Class1 A = new Class1("Сегодня хорошая погода, буду кушать суп.");
            Class1 B = new Class1("Анекдот дня");

            bool Actual = false;
            Assert.AreEqual(A == B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Тестирование операции !=
            Class1 A = new Class1("Сегодня хорошая погода, буду кушать суп.");
            Class1 B = new Class1("Анекдот дня");

            bool Actual = true;
            Assert.AreEqual(A != B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod5()
        {
            // Тестирование операции >
            Class1 A = new Class1("Сегодня хорошая погода, буду кушать суп.");
            Class1 B = new Class1("Анекдот дня");

            bool Actual = true;
            Assert.AreEqual(A > B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod6()
        {
            // Тестирование операции <
            Class1 A = new Class1("Сегодня хорошая погода, буду кушать суп.");
            Class1 B = new Class1("Анекдот дня");

            bool Actual = false;
            Assert.AreEqual(A < B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod7()
        {
            // Тестирование операции >=
            Class1 A = new Class1("Сегодня хорошая погода, буду кушать суп.");
            Class1 B = new Class1("Анекдот дня");

            bool Actual = true;
            Assert.AreEqual(A >= B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod8()
        {
            // Тестирование операции <=
            Class1 A = new Class1("Сегодня хорошая погода, буду кушать суп.");
            Class1 B = new Class1("Анекдот дня");

            bool Actual = false;
            Assert.AreEqual(A <= B, Actual, "Результат не соответствует ожиданию!");
        }
    }
}
