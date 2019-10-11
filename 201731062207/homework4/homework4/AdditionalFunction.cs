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
        public void countPhrases()
        {
           

        }

        //按照参数输出n个高频词
        public void outputNum(int num2)
        {
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
                if (count == num2)
                {
                    break;
                }
            }

        }
    }
    
}
