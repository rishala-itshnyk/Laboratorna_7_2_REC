using NUnit.Framework;
using System;
using System.IO;

namespace Laboratorna_7_2_ITER.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCreate()
        {
            int k = 3, n = 4;
            int Low = 7, High = 65;
            int[][] a = new int[k][];
            for (int i = 0; i < k; i++)
                a[i] = new int[n];

            Program.Create(a, k, n, Low, High, 0, 0);

            for (int i = 0; i < k; i++)
                for (int j = 0; j < n; j++)
                    Assert.IsTrue(a[i][j] >= Low && a[i][j] <= High);

            for (int i = 0; i < k; i++)
                Array.Clear(a[i], 0, a[i].Length);
            Array.Clear(a, 0, a.Length);
        }

        [Test]
        public void TestSearchMinOfMax()
        {
            int k = 4, n = 5;
            int[][] a = new int[k][];
            for (int i = 0; i < k; i++)
                a[i] = new int[n];
            a[0][0] = 10; a[0][1] = 20; a[0][2] = 30; a[0][3] = 40; a[0][4] = 50;
            a[1][0] = 15; a[1][1] = 25; a[1][2] = 35; a[1][3] = 45; a[1][4] = 55;
            a[2][0] = 11; a[2][1] = 21; a[2][2] = 31; a[2][3] = 41; a[2][4] = 51;
            a[3][0] = 12; a[3][1] = 22; a[3][2] = 32; a[3][3] = 42; a[3][4] = 52;

            bool result = Program.SearchMinOfMaxRecursive(a, k, n, 0, int.MaxValue, out int minOfMax);

            Assert.IsTrue(result);
            Assert.AreEqual(52, minOfMax);

            for (int i = 0; i < k; i++)
                Array.Clear(a[i], 0, a[i].Length);
            Array.Clear(a, 0, a.Length);
        }

        [Test]
        public void TestPrint()
        {
            int k = 2, n = 3;
            int[][] a = new int[k][];
            for (int i = 0; i < k; i++)
                a[i] = new int[n];
            a[0][0] = 1; a[0][1] = 2; a[0][2] = 3;
            a[1][0] = 4; a[1][1] = 5; a[1][2] = 6;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Print(a, 0, 0, k, n);
                string printedOutput = sw.ToString();

                string expectedOutput = "   1   2   3\n   4   5   6\n";
                Assert.AreEqual(expectedOutput, printedOutput);
            }

            for (int i = 0; i < k; i++)
                Array.Clear(a[i], 0, a[i].Length);
            Array.Clear(a, 0, a.Length);
        }
    }
}
