using System;
using System.Collections.Generic;
using System.Text;

namespace homework4
{
    interface BasisInterface
    {
        string CountChar(string content);
        string CountLine(string content);
        string[] CountWord(string content);
        Dictionary<string, int> CountFrequency(string[] word, int outNum);
    }
}
