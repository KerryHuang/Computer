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
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.Write("請輸入數字：");
                string strNumberA = Console.ReadLine();
                Console.Write("請輸入(+ - * / )：");
                string strOperate = Console.ReadLine();
                Console.Write("請輸入數字：");
                string strNumberB = Console.ReadLine();

                Operation oper;
                oper = OperationFactory.createOperate(strOperate);
                oper.NumberA = Convert.ToDouble(strNumberA);
                oper.NumberB = Convert.ToDouble(strNumberB);
                double result = oper.GetResult();

                string strResult = Convert.ToString(result);                
                Console.WriteLine("結果：" + strResult);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("結果：" + ex.Message);
            }            
        }
    }
}
