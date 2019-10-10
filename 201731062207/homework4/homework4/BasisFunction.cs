using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace homework4
{
    class BasisFunction: BasisInterface    {

        /*
         * 整形变量charNum保存字符数
         * 整形变量fileNum保存文档行数
         * 整形变量wordNum保存符合要求的单词数
         * 字符串变量path用于接受输入的文档路径
         * 字符串变量content保存从文档读取的内容
         * 字符串数组word保存从content分解且符合要求的单词
         */
        int charNum;
        int fileLine;
        int wordNum;
        string path;
        string content;
        string[] word;

        /*
         * CountChar方法用于获取文档内容的字符数
         * 通过计算content的长度直接获取字符数
         */
        public void CountChar()
        {
            //throw new NotImplementedException();

            charNum = content.Length;
        }

        /*
         * CountLine方法用于获取文档内容的行数
         * 通过System.IO中的方法直接获取行数
         */
        public void CountLine()
        {
            //throw new NotImplementedException();

            using (StreamReader read = new StreamReader(path, Encoding.Default))
            {
                fileLine = read.ReadToEnd().Split('\n').Length;
            }
        }

        /*
         * CountWord方法用于获取文档内容中符合要求的单词数
         * 使用ToLower方法将content的内容中字符全部转换成小写并存入lowContent
         * 通过System.Text.RegularExpressions中的方法分离所有单词并存入word
         * 将word中的单词遍历一遍剔除不符合要求的单词并获取符合要求的单词数
         */
        public void CountWord()
        {
            //throw new NotImplementedException();
            string lowContent;
            lowContent = content.ToLower();

            word = Regex.Split(lowContent, @"\W+");
            wordNum = word.Length;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Length < 4)
                {
                    word[i] = "//0";
                    wordNum--;
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((word[i][j] < 97) || (word[i][j] > 122))
                        {
                            word[i] = "//0";
                            wordNum--;
                            break;
                        }
                    }
                }
            }
        }

        /*
         * CountFrequency方法用于从word中计算每个单词出现的频率并排序
         * 通过System.Collections.Generic中的方法来将每个单词逐一统计
         */
        public void CountFrequency()
        {
            //throw new NotImplementedException();

            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (frequencies.ContainsKey(word[i]))
                {
                    frequencies[word[i]]++;
                }
                else
                {
                    frequencies[word[i]] = 1;
                }
            }
            foreach (KeyValuePair<string, int> entry in frequencies)
            {
                string word = entry.Key;
                int frequency = entry.Value;
                if (word != "//0")
                {
                    Console.WriteLine("{0}: {1}", word, frequency);
                }

            }
        }

        /*
         * Output方法用于将之前四个方法的结果逐一输出
         */
        public void Output()
        {
            //throw new NotImplementedException();

            Console.WriteLine("字符数：" + charNum);
            Console.WriteLine("文本行数：" + fileLine);
            Console.WriteLine("单词数：" + wordNum);
        }

        /*
         * ReadFile方法用于读取指定文档中的内容
         * 先让使用者输入文档路径并存入path中
         * 通过System.IO中的方法读取文档的内容并存入content
         */
        public void ReadFile()
        {
            Console.WriteLine("请输入需要读取的文件的路径：");
            path = Console.ReadLine();

            content = File.ReadAllText(path);
            Console.WriteLine(content);

            CountChar();
            CountLine();
            CountWord();
            CountFrequency();
            Output();

            Console.ReadKey();
        }
    }
}
