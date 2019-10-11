using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace homework4
{
    class BasisFunction: BasisInterface
    {

        /*
         * 整形变量charNum保存字符数
         * 整形变量fileNum保存文档行数
         * 整形变量wordNum保存符合要求的单词数
         * 字符串变量path用于接受输入的文档路径
         * 字符串变量content保存从文档读取的内容
         * 字符串数组word保存从content分解的单词
         * Dictionary型变量wordAndFrequency保存word中的单词及出现频率
         */
       
        int charNum;
        int fileLine;
        int wordNum;
        string path;
        string content;
        public static string[] allWord;
        public static Dictionary<string, int> wordAndFrequency = new Dictionary<string, int>();

        /*
         * CountChar方法用于获取文档内容的字符数
         * 方法无需参数，由ReadFile方法调用
         */
        public void CountChar()
        {

            //throw new NotImplementedException();

            charNum = content.Length;
            Console.WriteLine("字符数：" + charNum);
        }

        /*
         * CountLine方法用于获取文档内容的行数
         * 方法无需参数，由ReadFile方法调用
         */
        public void CountLine()
        {

            //throw new NotImplementedException();

            using (StreamReader read = new StreamReader(path, Encoding.Default))
            {
                fileLine = read.ReadToEnd().Split('\n').Length;
            }
            Console.WriteLine("文本行数：" + fileLine);
        }

        /*
         * CountWord方法用于获取文档内容中符合要求的单词数
         * 方法无需参数，由ReadFile方法调用
         */
        public void CountWord(string pathIn)
        {

            //throw new NotImplementedException();

            string lowContent;
            lowContent = pathIn.ToLower();

            allWord = Regex.Split(lowContent, @"\W+");
            wordNum = allWord.Length;
            for (int i = 0; i < allWord.Length; i++)
            {
                if (allWord[i].Length < 4)
                {
                    allWord[i] = "//0";
                    wordNum--;
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((allWord[i][j] < 97) || (allWord[i][j] > 122))
                        {
                            allWord[i] = "//0";
                            wordNum--;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("单词数：" + wordNum);
        }

        /*
         * CountFrequency方法用于从word中计算每个单词出现的频率并排序
         * 方法无需参数，由ReadFile方法调用
         */
        public void CountFrequency()
        {

            //throw new NotImplementedException();
            
            for (int i = 0; i < allWord.Length; i++)
            {
                if (wordAndFrequency.ContainsKey(allWord[i]))
                {
                    wordAndFrequency[allWord[i]]++;
                }
                else
                {
                    wordAndFrequency[allWord[i]] = 1;
                }
            }

            var result = wordAndFrequency.OrderByDescending(o => o.Value).ThenBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            int count = 0;
            foreach (KeyValuePair<string, int> kvp in result)
            {
                if (kvp.Key != "//0")
                {
                    Console.WriteLine(kvp.Key + ":" + kvp.Value);
                    count++;
                }
                if (count == 10)
                {
                    break;
                }
            }
            
        }

        /*
         * ReadFile方法用于读取指定文档中的内容
         * 方法无需参数，由主函数调用
         */
        public void ReadFile()
        {

            Console.WriteLine("请输入需要读取的文件的路径：");
            path = Console.ReadLine();
            Console.WriteLine();

            content = File.ReadAllText(path);
            Console.WriteLine("文件内容如下：");
            Console.WriteLine(content);
            Console.WriteLine();

            Console.WriteLine("文件内容统计结果如下：");
            CountChar();
            CountLine();
            CountWord(content);
            CountFrequency();
            Console.ReadKey();
        }
    }
}
