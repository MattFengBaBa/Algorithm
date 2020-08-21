using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain
{   
    /// <summary>
    /// 新威面试题
    /// </summary>
    public class DrinkMinMoney
    {
        //汽水2元一瓶。喝完后两个空瓶可换一瓶汽水或一个空瓶可换五毛钱，另每消费满3元返1元，想要喝10瓶汽水，最少支出多少钱？请编写代码实现。
        //思路：两个空瓶换一瓶可乐收益>一个空瓶换五毛钱。所以尽量去换汽水。最后瓶子换钱。


        /// <summary>
        /// 自己用钱买的汽水数量
        /// </summary>
        private int PayCount { get; set; } 

        /// <summary>
        /// 用瓶子换的汽水总数量
        /// </summary>
        private int ExChangeCount { get; set; }

        /// <summary>
        /// 剩的空瓶子数
        /// </summary>
        private int RemainCount { get; set; } 

        /// <summary>
        /// 返的钱
        /// </summary>
        private double DisCount { get; set; } 


        /// <summary>
        /// 获取想要买的瓶数需要的钱
        /// </summary>
        /// <param name="drinkCount">想要买的瓶数</param>
        /// <returns></returns>
        public double GetMinMoney( int drinkCount)
        {
            while (true)
            {
                if (PayCount + ExChangeCount>= drinkCount)
                {
                    break;
                }
                PayCount++;
                RemainCount++;
                if (RemainCount / 2 > 0)
                {
                    RemainCount = RemainCount - 2;
                    ExChangeCount++;
                    RemainCount++;
                }
                
            }
            DisCount = PayCount * 2 / 3;
            return (double)(PayCount * 2 - RemainCount * 0.5 - DisCount);
        }

    }
}
