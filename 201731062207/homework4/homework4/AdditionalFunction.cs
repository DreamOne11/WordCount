using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace homework4
{
    class AdditionalFunction:BasisFunction
    {
       
        //countPhrases()按照参数组合词组，并输出每个词组
        //方法接受一个保存旧单词表的字符串数组和一个命令行参数
        public new Dictionary<string,int> countPhrases(string[] oldWord,int num1)   
        {

            string[] newWord = new string[oldWord.Length]; 
            int countNum = 0;

            //嵌套循环生成新的单词
            for(int i=0;i<oldWord.Length-num1+1;i++)
            {
                for(int j=0;j<num1;j++)
                {
                    newWord[i] +=  ' '+oldWord[i+j];
                }
                countNum++;
            }

            string[] finallWord = new string[countNum];
            for (int i = 0; i < countNum; i++)
            {
                finallWord[i] = newWord[i];
            }

            Console.WriteLine("词组个数：{0}",countNum);
            string phrasesNum = "词组个数:" + countNum;
            writeToFile(phrasesNum, Program.PathOutput);


            return CountFrequency(finallWord,countNum);
        }

        //outputNum()用于按照参数输出n个高频词
        //方法接受一个保存单词表的字符串和一个参数命令行
        public new void outputNum(string[] Word,int num2)
        {
            CountFrequency(Word,num2);
        }

    }
    
}
