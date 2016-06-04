using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    /// <summary>
    /// 抽象類別
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class Stack<T>
    {
        /// <summary>
        /// 取得堆疊中目前的項目數量
        /// </summary>
        public int Count { get; protected set; }
        /// <summary>
        /// 從堆疊最頂端加入一個項目
        /// </summary>
        /// <param name="value"></param>
        abstract public void Push(T value);
        /// <summary>
        /// 從堆疊最頂端取出一個項目，同時將其移除
        /// </summary>
        /// <returns></returns>
        abstract public T Pop();
        /// <summary>
        /// 從堆疊最頂端取出一個項目，但不移除
        /// </summary>
        /// <returns></returns>
        abstract public T Peek();
    }

    /// <summary>
    /// 陣列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ArrayStack<T> : Stack<T>
    {
        private int capacity;
        private T[] array;

        public ArrayStack()
            : this(10240)
        {
        }

        public ArrayStack(int capacity)
        {
            this.capacity = capacity;
            array = new T[capacity];
        }

        public override void Push(T value)
        {
            if (Count == array.Length)
            {
                T[] newArray = new T[array.Length + capacity];
                Array.Copy(array, newArray, array.Length);
                array = newArray;
            }
            array[Count++] = value;
        }

        public override T Pop()
        {
            T value = array[--Count];
            array[Count] = default(T);
            return value;
        }

        public override T Peek()
        {
            return array[Count - 1];
        }
    }
}
