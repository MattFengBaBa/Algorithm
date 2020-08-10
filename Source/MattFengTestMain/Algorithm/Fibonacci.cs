using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain.Algorithm
{
    /// <summary>
    /// 斐波那契数列
    /// </summary>
    public  class Fibonacci
    {
        //大家都知道斐波那契数列，现在要求输入一个整数n，请你输出斐波那契数列的第n项（从0开始，第0项为0，第1项是1）。
        //n<=39
        public int fibonacci(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else if (n == 2)
                return 1;
            else
            {
                return fibonacci(n - 1) + fibonacci(n - 2);
            }
            // write code here
        }
    }
}
