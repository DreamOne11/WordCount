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
       //输出
       

        //按照参数组合词组，并输出每个词组
        public new Dictionary<string,int> countPhrases(string[] oldWord,int num1)   
        {

            string[] newWord = new string[oldWord.Length]; 
            int countNum = 0;

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

        //按照参数输出n个高频词
        public new void outputNum(string[] Word,int num2)
        {
            CountFrequency(Word,num2);
        }

    }
    
}
