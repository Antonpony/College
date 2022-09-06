using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//using MyLib;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1

    {

        [TestMethod]

        public void TestMethod1()

        {

            Arr Expected = new Arr(new int[] { 10, -5, 4, 19 });

            Expected++;

            Arr Actual = new Arr(new int[] { 11, -4, 5, 20 });

            Assert.AreEqual<Arr>(Expected, Actual, "Результат не соответствует ожиданию!");

        }

        [TestMethod]

        public void TestMethod2()

        {

            Arr A = new Arr(new int[] { 10, -5, 4, 19 });

            Arr B = new Arr(new int[] { -8, 11 });

            Arr Expected;

            Expected = A + B;

            Arr Actual = new Arr(new int[] { 2, 6, 4, 19 });

            Assert.AreEqual<Arr>(Expected, Actual, "Результат не соответствует ожиданию!");

        }

        [TestMethod]

        public void TestMethod3()

        {

            Arr X = new Arr(new int[] { 10, -5, 4, 19 });

            int Expected = X.Summ(5);

            int Actual = 5;

            Assert.AreEqual(Expected, Actual, "Результат не соответствует ожиданию!");

        }

        [TestMethod]

        public void TestMethod4()

        {

            Arr A = new Arr(new int[] { 10, -5, 4, 19 });

            Arr B = new Arr(new int[] { -8, 11 });

            Arr Expected;

            Expected = A - B;

            Arr Actual = new Arr(new int[] { 18, -16, 4, 19 });

            Assert.AreEqual<Arr>(Expected, Actual, "Результат не соответствует ожиданию!");

        }

        [TestMethod]

        public void TestMethod5()

        {
            string ans = "973";

            Arr X = new Arr(new int[] { 4, 0, 5, 0, 45, 987, 0, 45, 77, 0 });

            Arr Expected = ans;

            Expected.X.Print_Variant_to_String();

            Arr Actual = new Arr(new int[] { 0, 4, 5, 4, 45, 987, 4, 45, 77, 4 });

            Assert.AreEqual<Arr>(Expected, Actual, "Результат не соответствует ожиданию!");

        }

    }
}
