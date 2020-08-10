using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MattFengTestMain.Algorithm
{
    /// <summary>
    /// 二进制中1的个数
    /// </summary>
    public class NumberOf1
    {
        //输入一个整数，输出该数32位二进制表示中1的个数。其中负数用补码表示。

       
        public int numberOf1(int n)
        {
            if (n == 0)
                return 0;
            else if (n > 0)
            {
                var str= Convert.ToString(n, 2);
                return Regex.Matches(str, "1").Count;
            }
            else
            {
                var str = Convert.ToString(ConvertComplementCode(n), 2);
                return Regex.Matches(str, "1").Count;
            }
        }

        /// <summary>
        /// 求一个16位数数的补码
        /// </summary>
        /// <param name="OriginalCode">传入一个Int16整型</param>
        /// <returns></returns>
        private static int ConvertComplementCode(int OriginalCode)
        {
            int a = short.MaxValue;
            int b = short.MinValue;
            int c = a - b;
            int d = 0;
            if (OriginalCode > 0)
            {
                d = -(c - OriginalCode + 1);
            }
            else
            {
                d = c + OriginalCode + 1;
            }
            return d;
        }

        /// <summary>
        /// 求一个32位数的补码
        /// </summary>
        /// <param name="OriginalCode">传入一个Int32整型</param>
        /// <returns></returns>
        private static long ConvertComplementCode(long OriginalCode)
        {
            long a = int.MaxValue;
            long b = int.MinValue;
            long c = a - b;
            long d = 0;
            if (OriginalCode > 0)
            {
                d = -(c - OriginalCode + 1);
            }
            else
            {
                d = c + OriginalCode + 1;
            }
            return d;
        }
    }
}
