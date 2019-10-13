using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace homework4
{
    public class BasisFunction: countwordInterface
    {

        //CountChar用于计算文档内容中的字符数
        //方法接收一个保存文档内容的字符串参数content
        public int CountChar(string content)
        {
            int charNum;
            charNum = content.Length;

            Console.WriteLine("字符数：" + charNum);
            writeToFile("字符数：" + charNum, Program.PathOutput);

            return charNum;
        }


        //CountLine用于计算文档内容的行数
        //方法接收一个保存文档内容的字符串参数content
        public int CountLine(string content)
        {
            string temp = Regex.Replace(content, @"\n\s*\n", "\r\n");

            int lineNum = temp.Split('\n').Length;

            Console.WriteLine("行数：" + lineNum);
            writeToFile("行数：" + lineNum, Program.PathOutput);

            return lineNum;
        }

        //CountWord用于计算文档内容中符合条件的单词数
        //方法接收一个保存文档内容的字符串参数content
        //方法返回一个保存所有符合条件单词的string[]变量rightWord
       public string[] CountWord(string content)
        {
            string lowContent;
            lowContent = content.ToLower();

            string[] allWord = Regex.Split(lowContent, @"\W+");
            string[] rightWord = new string[allWord.Length];
            int num = 0;
            for (int i = 0; i < allWord.Length; i++)
            {
                if (Regex.IsMatch(allWord[i], @"^[a-z][a-z][a-z][a-z]"))
                {
                    rightWord[num] = allWord[i];
                    num++;
                }
            }

            string[] word = new string[num];
            for (int i = 0; i < num; i++)
            {
                word[i] = rightWord[i];
            }

           Console.WriteLine("单词数：" + num);
           writeToFile("单词数：" + num, Program.PathOutput);

            return word;
        }
        //CountWord用于计算文档内容中符合条件的单词的频率并排序
        //方法接收一个保存所有符合条件单词的字符串数组rightWord和一个int变量outNum输入指定至多前outNum多的单词和对应的频率
        //方法返回一个保存有经过排序的单词和对应频率的Dictionary<string, int>变量result
        public Dictionary<string, int> CountFrequency(string[] word, int outNum)
        {
            Dictionary<string, int> wordAndFrequency = new Dictionary<string, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (wordAndFrequency.ContainsKey(word[i]))
                {
                    wordAndFrequency[word[i]]++;
                }
                else
                {
                    wordAndFrequency[word[i]] = 1;
                }
            }

            var result = wordAndFrequency.OrderByDescending(o => o.Value).ThenBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            int count = 0;
            foreach (KeyValuePair<string, int> kvp in result)
            {
                Console.WriteLine(kvp.Key + ":" + kvp.Value);
                writeToFile(kvp.Key + ":" + kvp.Value, Program.PathOutput);
                count++;
                if (count == outNum)
                {
                    break;
                }
            }

            return result;
        }

        //ProcessDoc用于调用CountChar、CountLine、CountWord、CountFrequency方法对文档内容进行处理
        //方法接收一个保存文档内容的字符串参数content
        public void ProcessDoc(string content)
        {
            string[] word;

            CountChar(content);
            CountLine(content);
            word = CountWord(content);
            CountFrequency(word, 10);
        }

        //Read File用于获取用户输入的文档路径并读取文档内容
        public bool ReadFile(string path)
        {
            bool test1=false;
            try
            { 
                if (File.Exists(path))
                 {
                     test1 = true;
                     string content;
                     content = File.ReadAllText(path);
                     Console.WriteLine("文档处理完成！");
                     ProcessDoc(content);
                 }
            }

            catch
            {
                  Console.WriteLine("文档不存在！");
            }
            return test1;
        }


        public bool writeToFile(string content, string pathOutput)
        {
            bool test = false;
            try
            {
                if (content != null)
                {
                    test = true;
                    using (StreamWriter sw = new StreamWriter(pathOutput, true))
                    {
                        sw.WriteLine(content);
                    }
                }
            }
            catch
            {
                Console.WriteLine("写入文档失败！");
            }
            return test;
        }

        public Dictionary<string, int> countPhrases(string[] oldWord, int num1)
        {
            throw new NotImplementedException();
        }

        public void outputNum(string[] Word, int num2)
        {
            throw new NotImplementedException();
        }
    }
}
