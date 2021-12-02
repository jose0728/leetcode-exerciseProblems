using System;

namespace _155_最小栈
{
    class Program
    {
        static void Main(string[] args)
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            var a = minStack.GetMin();
            minStack.Pop();
            var b = minStack.Top();
            var c = minStack.GetMin();
        }
    }
}
