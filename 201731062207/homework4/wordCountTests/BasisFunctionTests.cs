using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework4;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace homework4.Tests
{
    [TestClass()]
    public class BasisFunctionTests
    {
        [TestMethod()]
        public void CountWordTest()
        {
            BasisFunction basisFunction = new BasisFunction();
            string[] word = { "aaaa", "bbbb", "cccc", "dddd" };

            //测试1 测试CountWord方法得到的结果单词字符长度是否超过4
            string content1 = File.ReadAllText(@"C:\Users\charm\Desktop\charm\1.txt");
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(word[i], basisFunction.CountWord(content1)[i]);
            }

            //测试2 测试CountWord方法得到的结果单词前四位是否都为字母
            string content2 = File.ReadAllText(@"C:\Users\charm\Desktop\charm\2.txt");
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(word[i], basisFunction.CountWord(content2)[i]);
            }
        }

        [TestMethod()]
        public void CountCharTest()
        {
            BasisFunction basisFunction = new BasisFunction();
            int charNum = 12;

            //测试3 测试CountChar方法得到的结果字符数是否正确（不含特殊字符）
            string content3 = File.ReadAllText(@"C:\Users\charm\Desktop\charm\3.txt");
            Assert.AreEqual(charNum, basisFunction.CountChar(content3));

            //测试4 测试CountChar方法得到的结果字符数是否正确（含特殊字符）
            string content4 = File.ReadAllText(@"C:\Users\charm\Desktop\charm\4.txt");
            Assert.AreEqual(charNum, basisFunction.CountChar(content4));
        }

        [TestMethod()]
        public void CountLineTest()
        {
            BasisFunction basisFunction = new BasisFunction();
            int lineNum = 4;

            //测试5 测试CountLine方法得到的结果行数是否正确（不含空行）
            string content5 = File.ReadAllText(@"C:\Users\charm\Desktop\charm\5.txt");
            Assert.AreEqual(lineNum, basisFunction.CountLine(content5));

            //测试6 测试CountLine方法得到的结果行数是否正确（含空行）
            string content6 = File.ReadAllText(@"C:\Users\charm\Desktop\charm\6.txt");
            Assert.AreEqual(lineNum, basisFunction.CountLine(content6));
        }

        [TestMethod()]
        public void CountFrequencyTest()
        {
            BasisFunction basisFunction = new BasisFunction();
            string[] test = { "aaaa", "aaaa", "aaaa", "aaaa", "bbbb", "bbbb", "bbbb", "cccc", "cccc", "dddd" };
            string[] word = { "aaaa", "bbbb", "cccc", "dddd" };
            int[] frequency = { 4, 3, 2, 1 };
            var result = basisFunction.CountFrequency(test, 4);

            //测试7 测试CountFrequency方法得到的结果单词排序是否正确
            int count = 0;
            foreach (KeyValuePair<string, int> kvp in result)
            {
                Assert.AreEqual(word[count], kvp.Key);
                count++;
            }

            //测试8 测试CountFrequency方法得到的结果单词频率排序是否正确
            count = 0;
            foreach (KeyValuePair<string, int> kvp in result)
            {
                Assert.AreEqual(frequency[count], kvp.Value);
                count++;
            }
        }

        [TestMethod()]
        public void writeToFileTest()
        {
            BasisFunction basisFunction = new BasisFunction();
            Assert.IsTrue(basisFunction.writeToFile("Not Null", "C:\test.txt"));
            Assert.IsFalse(basisFunction.writeToFile(null, "C:\test.txt"));
        }

        [TestMethod()]
        public void ReadFileTest()
        {
            BasisFunction basisFunction = new BasisFunction();
            Assert.IsFalse(basisFunction.ReadFile(null));
        }
    }
}