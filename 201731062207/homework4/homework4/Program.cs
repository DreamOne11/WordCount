using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace homework4
{
    public class Program
    {
        static int num1,num2 = 0;
        static string pathInput, pathOutput;

        public static string PathOutput { get => pathOutput; set => pathOutput = value; }

        public static void Main(string[] args)
        {
            //有命令行参数
            if (args.Length > 0)
            {
                //对命令行参数进行判断（-m、-n、-i、-o）并保存参数
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-i")
                        pathInput = args[++i];
                    else if (args[i] == "-m")
                        num1 = Convert.ToInt32(args[++i]);
                    else if (args[i] == "-o")
                        PathOutput = args[++i];
                    else if (args[i] == "-n") 
                        num2 = Convert.ToInt32(args[++i]);
                }


               
                    if (pathInput != null && PathOutput != null)
               {
                    
                     //定义字符串，用于保存从文件中读取的内容
                     string content = null;
                    
                    //读取参数-i的路径文件中的内容
                     content= File.ReadAllText(pathInput);

                     
                     //实例化附加功能类，父类功能可以直接调用
                     AdditionalFunction addFunction = new AdditionalFunction();
                     addFunction.CountChar(content);
                     string[] Word = addFunction.CountWord(content);
                     addFunction.CountLine(content);

                     //三种情况：有-m没-n  有-n没-m  -n，-m都有
                     if (num1>0&&num2==0)
                   {
                     addFunction.countPhrases(Word, num1);
                   }
                     else if(num2>0&&num1==0)
                   {
                     addFunction.outputNum(Word,num2);
                   }
                     else if(num1>0&&num2>0)
                   {
                     addFunction.outputNum(Word, num2);
                     addFunction.countPhrases(Word, num1);
                   }
                     else if(num1==0&&num2==0)
                    {
                        addFunction.CountFrequency(Word,10);
                    }
               }

                    else                      
                     Console.WriteLine("路径不正确，读取文档失败！");
        
            }

            //无命令行参数
            else
            {
                BasisFunction basisFunction = new BasisFunction();
                Console.WriteLine("请输入需要读取的文档的路径：");
                string path = Console.ReadLine();
                basisFunction.ReadFile(path);

            }

        }
    }
}
