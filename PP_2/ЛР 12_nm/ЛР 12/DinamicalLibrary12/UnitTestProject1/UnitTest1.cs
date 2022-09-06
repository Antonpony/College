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
            Class1 Expected = new Class1("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday");
            int n = Expected.CountWrods();
            int Actual = 6;
            Assert.AreEqual(n, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod2()
        {            
            // Тестирование метода по варианту 13
            Class1 A = new Class1("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday");
            string Expected = A.Variant("T", true);
            string Actual = "Tuesday Thursday";
            Assert.AreEqual(Expected, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Тестирование операции ==
            Class1 A = new Class1("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday");
            Class1 B = new Class1("bebra");

            bool Actual = false;
            Assert.AreEqual(A == B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Тестирование операции !=
            Class1 A = new Class1("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday");
            Class1 B = new Class1("bebra");

            bool Actual = true;
            Assert.AreEqual(A != B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod5()
        {
            // Тестирование операции >
            Class1 A = new Class1("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday");
            Class1 B = new Class1("bebra");

            bool Actual = true;
            Assert.AreEqual(A > B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod6()
        {
            // Тестирование операции <
            Class1 A = new Class1("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday");
            Class1 B = new Class1("bebra");

            bool Actual = false;
            Assert.AreEqual(A < B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod7()
        {
            // Тестирование операции >=
            Class1 A = new Class1("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday");
            Class1 B = new Class1("bebra");

            bool Actual = true;
            Assert.AreEqual(A >= B, Actual, "Результат не соответствует ожиданию!");
        }

        [TestMethod]
        public void TestMethod8()
        {
            // Тестирование операции <=
            Class1 A = new Class1("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday");
            Class1 B = new Class1("bebra");

            bool Actual = false;
            Assert.AreEqual(A <= B, Actual, "Результат не соответствует ожиданию!");
        }
    }
}
