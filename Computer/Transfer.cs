using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    public class Transfer
    {
        private static string[] Operands = { "+", "-", "*", "/", "(", ")" };
        private static string[] Operand = { "+", "-", "*", "/" };
        
        /// <summary>
        /// 計算機
        /// 由堆疊裡的資料開始計算
        /// A B C / - D E * + F - 程式實際載跑的話是
        /// A ---->存入堆疊
        /// B ---->存入堆疊
        /// C ---->存入堆疊
        /// / ----->遇到運算子了 從前面取出兩個 (Stack.pop() 兩次) 即 B C
        /// 再將 B / C 的結果 ---->存入堆疊
        /// 繼續....
        /// - ----->遇到運算子 從前面取出兩個 即 A 還有 B/C的結果
        /// 再將 A-(B/C) 存入堆疊
        /// .
        /// .
        /// .
        /// 一直計算到最後
        ///
        /// 範例
        /// 1 - 3 / 3 + (2 * 2) - 4
        /// -> 1 3 3 / - 2 2 * + 4 -
        /// -> 1 1 - 2 2 * + 4 -
        /// -> 0 2 2 * + 4 -
        /// -> 0 4 + 4 -
        /// -> 4 4 -
        /// -> 0        
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double Excute(string str)
        {
            ArrayStack<string> stack = new ArrayStack<string>(str.Length);
            string[] list = ConvertSplit(str);
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == null) break;
                if (Operands.Contains(list[i]))
                {
                    // 提出前面兩個儲存的值計算
                    double douNumberA = Convert.ToDouble(stack.Pop());
                    double douNumberB = Convert.ToDouble(stack.Pop());
                    Operation oper;
                    oper = OperationFactory.createOperate(list[i]);
                    oper.NumberA = douNumberA;
                    oper.NumberB = douNumberB;
                    // 計算完的結果放在堆疊裡
                    stack.Push(Convert.ToString(oper.GetResult()));
                }
                else
                {
                    stack.Push(list[i]);
                }
            }
            return Convert.ToDouble(stack.Pop());
        }

        /// <summary>
        /// 轉成後置式後可以方便使用堆疊來計算結果規則為 :
        /// 1.遇到運算子(+ - * / ...)就從堆疊提兩個運算元出來計算
        /// 2.遇到運算元 就存入堆疊裡
        /// A - B / C + (D * E ) - F
        /// -> A - (B / C) + (D * E) - F
        /// -> A ( B C / ) - ( D E * ) + F -
        /// -> A B C / - D E * + F -
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] ConvertSplit(string str)
        {
            ArrayStack<string> stack = new ArrayStack<string>(str.Length);
            int index = 0;
            string[] result = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                string val = GetVal(str, i);
                i += val.Length - 1;
                if (Operand.Contains(val))
                {                                        
                    while (stack.Count != 0 && Priority(val) <= Priority(stack.Peek()))
                    {
                        result[index++] = stack.Pop();
                    }
                    stack.Push(val);
                }
                else if (val.Equals("("))
                {
                    stack.Push(val);
                }
                else if (val.Equals(")"))
                {
                    string tempS = string.Empty;
                    while (stack.Count != 0 && !(tempS = stack.Pop()).Equals("("))
                    {
                        result[index++] = tempS;
                    }
                }
                else
                {
                    result[index++] = val;
                }
            }
            // 把最後的值放回
            while (stack.Count != 0) result[index++] = stack.Pop();
            return result;
        }

        /// <summary>
        /// 取得數字或運算值
        /// </summary>
        /// <param name="val">字串</param>
        /// <param name="startindex">起始位置</param>
        /// <returns></returns>
        private static string GetVal(string val, int startindex)
        {
            StringBuilder result = new StringBuilder();
            if (val.Length - 1 < startindex) return result.ToString();
            string str = val.Substring(startindex, 1);
            if (Operands.Contains(str)) return str;
            while (!Operands.Contains(str))
            {
                result.Append(str);
                if (val.Length - 1 == startindex) break;
                startindex++;
                str = val.Substring(startindex, 1);
            }
            return result.ToString();
        }

        /// <summary>
        /// 運算子的優先順序
        /// </summary>
        /// <param name="opr"></param>
        /// <returns></returns>
        public static int Priority(string opr)
        {
            if (opr.Equals("^")) return 3;
            else if (opr.Equals("*") || opr.Equals("/")) return 2;
            else if (opr.Equals("+") || opr.Equals("-")) return 1;
            else return 0;
        }
    }
}
