using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace homework4
{
    class Program
    {
        static int num1,num2 = 0;
        static string pathInput, pathOutput;
        static void Main(string[] args)
        {
            //有命令行参数
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-i")
                        pathInput = args[++i];//-i 参数
                    else if (args[i] == "-m")
                        num1 = Convert.ToInt32(args[++i]);//-m 参数
                    else if (args[i] == "-o")
                        pathOutput = args[++i];//-o 参数
                    else if (args[i] == "-n") 
                        num2 = Convert.ToInt32(args[++i]);// -n 参数
                }
                if (pathInput == null /*|| pathOutput == null*/)//路径为空则不存在
                {
                    Console.WriteLine("路径不正确，文件不存在");
                }
                
                AdditionalFunction addFunction = new AdditionalFunction();
                //读取参数-i的路径文件中的内容
                string content = File.ReadAllText(pathInput);

                if(num1>0&&num2==0)
                {
                      
                }
                else if(num2>0&&num1==0)
                {
                    addFunction.CountWord(content);
                    addFunction.outputNum(num2);
                }
                else if(num1>0&&num2>0)
                {

                }
            }


            //无命令行参数
            else
            {
                 BasisFunction basisFunction = new BasisFunction();
                 basisFunction.ReadFile();
            }
          
        }
    }
}
