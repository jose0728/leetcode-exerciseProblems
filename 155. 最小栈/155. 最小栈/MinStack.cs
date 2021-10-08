using System;
using System.Collections.Generic;
using System.Text;

namespace _155._最小栈
{
    public class MinStack
    {
        Stack<int> stack;
        Stack<int> minStack;
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
            minStack.Push(int.MaxValue);
        }

        public void Push(int val)
        {
            stack.Push(val);
            minStack.Push(Math.Min(minStack.Peek(), val));
        }

        public void Pop()
        {
            if (stack.Count == 0)
            {
                return;
            }
            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            if (stack.Count == 0)
            {
                return 0;
            }
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}
