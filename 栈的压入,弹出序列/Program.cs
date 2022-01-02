using System;
using System.Collections.Generic;

namespace 栈的压入_弹出序列
{
    class Program
    {
        /// <summary>
        /// 输入两个整数序列，第一个序列表示栈的压入顺序，请判断第二个序列是否为该栈的弹出顺序。
        /// 假设压入栈的所有数字均不相等。
        /// 例如序列1,2,3,4,5是某栈的压入顺序，序列4，5,3,2,1是该压栈序列对应的一个弹出序列，但4,3,5,1,2就不可能是该压栈序列的弹出序列。
        /// （注意：这两个序列的长度是相等的）
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var a = IsPopOrder(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5, 3, 2, 1 });
        }

        public static bool IsPopOrder(int[] pushA, int[] popA)
        {
            if (pushA.Length == 0 || popA.Length == 0)
                return false;

            Stack<int> s = new Stack<int>();
            //用于标识弹出序列的位置
            int popIndex = 0;
            for (int i = 0; i < pushA.Length; i++)
            {
                s.Push(pushA[i]);
                //如果栈不为空，且栈顶元素等于弹出序列
                while (s.Count > 0 && s.Peek() == popA[popIndex])
                {
                    //出栈
                    s.Pop();
                    //弹出序列向后一位
                    popIndex++;
                }
            }
            return s.Count == 0;
        }
    }
}
