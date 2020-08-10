using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain.Algorithm
{
    public class RectCover
    {
        //我们可以用2*1的小矩形横着或者竖着去覆盖更大的矩形。请问用n个2*1的小矩形无重叠地覆盖一个2*n的大矩形，总共有多少种方法？
        //比如n=3时，2*3的矩形块有3种覆盖方法：
        //经分析;f(n)=f(n-1)+f(n-2);
        public int rectCover(int number)
        {
            if (number <= 3)
                return number;
            return rectCover(number - 1) + rectCover(number - 2);
        }
    }
}
