using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain.Algorithm
{
    public class JumpFloor
    {
        ///一只青蛙一次可以跳上1级台阶，也可以跳上2级。求该青蛙跳上一个n级的台阶总共有多少种跳法（先后次序不同算不同的结果）。
        public int jumpFloor(int number)
        {
            //if (number <= 0)
            //    return 0;
            //else if (number == 1)
            //    return 1;
            //else if (number == 2)
            //    return 2;
            //return jumpFloor(number-1)+jumpFloor(number-2);
            int first = 1;
            int second = 2;
            if (number <= 0)
                return 0;
            else if (number == 1)
                return first;
            else if (number == 2)
                return second;
            for (int i = 3; i <=number; i++)
            {
                int third = second + first;
                first = second;
                second = third;
            }
            return second;
        }

        //一只青蛙一次可以跳上1级台阶，也可以跳上2级……它也可以跳上n级。求该青蛙跳上一个n级的台阶总共有多少种跳法。

        //public int jumpFloorII(int number)
        //{ 
            
        
        //}
    }
}
