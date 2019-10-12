using System;
using System.Collections.Generic;
using System.Text;

namespace homework4
{
    interface BasisInterface
    {
        void CountChar(string content);
        void CountLine(string content);
        string[] CountWord(string content);
        Dictionary<string, int> CountFrequency(string[] word, int outNum);
    }
}
