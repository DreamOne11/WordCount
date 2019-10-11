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
        //按照参数组合词组，并输出每个词组
       
        public void countPhrases(string content,int num1)   
        {
            string[] oldWord = CountWord(content);
            string[] newWord = new string[oldWord.Length];
            
            int countNum = 0;
            Console.WriteLine(oldWord.Length);

            for(int i=0;i<oldWord.Length-num1+1;i++)
            {
                for(int j=0;j<num1;j++)
                {
                    newWord[i] +=  ' '+oldWord[i+j];
                }

                Console.WriteLine(newWord[i]);
                countNum++;
            }
            string[] finallWord = new string[countNum];
            for(int i=0;i<countNum;i++)
            {
                finallWord[i] = newWord[i];
            }
            Console.WriteLine(countNum);
            CountFrequency(finallWord,countNum);

        }

        //按照参数输出n个高频词
        public void outputNum(string content,int num2)
        {
            string[] word=CountWord(content);
            CountFrequency(word,num2);
        }
    }
    
}
