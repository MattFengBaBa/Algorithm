using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain.Algorithm
{
    /// <summary>
    /// 用两个栈实现队列
    /// </summary>
    public  class StackRealizeQueue
    {
        //用两个栈来实现一个队列，完成队列的Push和Pop操作。 队列中的元素为int类型。

        private static Stack<int> firstStack = new Stack<int> ();
        private static Stack<int> secondStack = new Stack<int>();

        private static bool isLastPop= false;
        public void Push(int node)
        {
            if (firstStack.Count == 0)
            {
                if (isLastPop)
                {
                    while (secondStack.Count > 0)
                    {
                        firstStack.Push(secondStack.Pop());
                    }
                    firstStack.Push(node);
                }
                else
                secondStack.Push(node);
            }
            else
            {
                if (isLastPop)
                {
                    while (firstStack.Count > 0)
                    {
                        secondStack.Push(firstStack.Pop());
                    }
                    secondStack.Push(node);
                }
                else
                    firstStack.Push(node);

            }
            isLastPop = false;
        }
        public int Pop()
        {
           
            if (firstStack.Count == 0)
            {   
                int result = 0;
                if (!isLastPop)
                {
                    while (secondStack.Count > 0)
                    {
                        firstStack.Push(secondStack.Pop());
                    }
                    result = firstStack.Pop();
                }
                else
                    result = secondStack.Pop();
                isLastPop = true;
                return result;
            }
            else
            {
                var result = 0;
                if (!isLastPop)
                {
                    while (firstStack.Count > 0)
                    {
                        secondStack.Push(firstStack.Pop());
                    }
                    result = secondStack.Pop();
                }
                else
                    result = firstStack.Pop();
                isLastPop = true;
                return result;
            }
            
        }
    }
}
