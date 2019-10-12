using System;
using System.Collections.Generic;
using System.Text;

namespace homework4
{
    interface countwordInterface
    {
        int CountChar(string content);
        int CountLine(string content);
        string[] CountWord(string content);
        Dictionary<string, int> CountFrequency(string[] word, int outNum);
        public Dictionary<string, int> countPhrases(string[] oldWord, int num1);
        public void outputNum(string[] Word, int num2);
    }
}
