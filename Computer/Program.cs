using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    class Program
    {
        /// <summary>
        /// 1. 完成簡易版計算機
        /// 2. 重新命名變數，改用switch判斷strOperate，增加判斷除數不能為0
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("請輸入數字：");
            string strNumberA = Console.ReadLine();
            Console.Write("請輸入(+ - * / )：");
            string strOperate = Console.ReadLine();
            Console.Write("請輸入數字：");
            string strNumberB = Console.ReadLine();
            string strResult = string.Empty;

            switch (strOperate)
            {
                case "+":
                    strResult = Convert.ToString(Convert.ToInt16(strNumberA) + Convert.ToInt16(strNumberB));
                    break;
                case "-":
                    strResult = Convert.ToString(Convert.ToInt16(strNumberA) - Convert.ToInt16(strNumberB));
                    break;
                case "*":
                    strResult = Convert.ToString(Convert.ToInt16(strNumberA) * Convert.ToInt16(strNumberB));
                    break;
                case "/":
                    if (!strNumberB.Equals("0"))
                    {
                        strResult = Convert.ToString(Convert.ToInt16(strNumberA) / Convert.ToInt16(strNumberB));
                    }
                    else
                    {
                        strResult = "除數不能為0";
                    }
                    break;
            }            
            Console.WriteLine("結果：" + strResult);
            Console.ReadKey();
        }
    }
}
