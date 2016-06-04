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
        /// 3. [封裝]增加Operation運算類別
        /// 4. 緊耦合和鬆耦合及工廠模式
        /// 5. 數字檢查及運算式檢查
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                string strResult = string.Empty;
                Console.Write("請輸入數字：");
                double douNumberA = isNumber(Console.ReadLine());
                Console.Write("請輸入(+ - * / )：");
                string strOperate = isOperate(Console.ReadLine());
                Console.Write("請輸入數字：");
                double strNumberB = isNumber(Console.ReadLine());

                Operation oper;
                oper = OperationFactory.createOperate(strOperate);
                oper.NumberA = douNumberA;
                oper.NumberB = Convert.ToDouble(strNumberB);
                double result = oper.GetResult();

                strResult = Convert.ToString(result);
                Console.WriteLine("結果：" + strResult);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("結果：" + ex.Message);
            }
        }

        /// <summary>
        /// 數字檢查
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        static double isNumber(string strNumber)
        {
            double douNumber = 0d;
            if (double.TryParse(strNumber, out douNumber))
                return douNumber;
            else
            {
                Console.Write("請輸入數字：");                
                return isNumber(Console.ReadLine());
            }
        }

        /// <summary>
        /// 運算式檢查
        /// </summary>
        /// <param name="strOperate"></param>
        /// <returns></returns>
        static string isOperate(string strOperate)
        {
            string[] oper = { "+", "-", "*", "/" };
            if (oper.Contains(strOperate))
                return strOperate;
            else
            {
                Console.Write("請輸入(+ - * / )：");
                return isOperate(Console.ReadLine());
            }
        }
    }
}
