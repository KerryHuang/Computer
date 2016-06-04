using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入數字：");
            string A = Console.ReadLine();
            Console.Write("請輸入(+ - * / )：");
            string B = Console.ReadLine();
            Console.Write("請輸入數字：");
            string C = Console.ReadLine();
            string D = string.Empty;

            if (B.Equals("+"))
            {
                D = Convert.ToString(Convert.ToInt16(A) + Convert.ToInt16(C));
            }
            if (B.Equals("-"))
            {
                D = Convert.ToString(Convert.ToInt16(A) - Convert.ToInt16(C));
            }
            if (B.Equals("*"))
            {
                D = Convert.ToString(Convert.ToInt16(A) * Convert.ToInt16(C));
            }
            if (B.Equals("/"))
            {
                D = Convert.ToString(Convert.ToInt16(A) / Convert.ToInt16(C));
            }
            Console.WriteLine("結果：" + D);
            Console.ReadKey();
        }
    }
}
