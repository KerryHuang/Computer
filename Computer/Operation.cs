using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    /// <summary>
    /// 運算類別
    /// </summary>
    public class Operation
    {
        private double _numberA = 0d;
        private double _numberB = 0d;

        public double NumberA
        {
            get
            {
                return _numberA;
            }
            set
            {
                _numberA = value;
            }
        }

        public double NumberB
        {
            get
            {
                return _numberB;
            }
            set
            {
                _numberB = value;
            }
        }

        public virtual double GetResult()
        {
            double result = 0d;
            return result;
        }
    }

    /// <summary>
    /// 加法類別，繼承運算類別
    /// </summary>
    public class OperationAdd : Operation
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }

    /// <summary>
    /// 減法類別，繼承運算類別
    /// </summary>
    public class OperationSub : Operation
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }

    /// <summary>
    /// 乘法類別，繼承運算類別
    /// </summary>
    public class OperationMul : Operation
    {
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }

    /// <summary>
    ///  除法類別，繼承運算類別
    /// </summary>
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            if (NumberB == 0)
                throw new Exception("除數不能為0");
            return NumberA / NumberB;
        }
    }
}
