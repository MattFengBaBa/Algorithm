using System;
namespace MattFengTestMain.Algorithm
{
    /// <summary>
    /// 数值的整数次方
    /// </summary>
    public class Power
    {
        //给定一个double类型的浮点数base和int类型的整数exponent。求base的exponent次方。

        //保证base和exponent不同时为0

        public double power(double thebase, int exponent)
        {
            return Math.Pow(thebase, exponent);
        }
    }
}
