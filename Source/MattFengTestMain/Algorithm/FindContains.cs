using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain
{
    /// <summary>
    /// 二维数组中的查找
    /// </summary>
    public class FindContains
    {
        //在一个二维数组中（每个一维数组的长度相同），每一行都按照从左到右递增的顺序排序，每一列都按照从上到下递增的顺序排序。请完成一个函数，输入这样的一个二维数组和一个整数，判断数组中是否含有该整数。
        public static bool Find(int target, int[][] array)
        {
            int col = array[0].Length - 1;
            int row = 0;
            while (row<= array.Length-1&& col>=0) 
            { 
                if (target == array[row][col])
                    return true;
                else if (target < array[row][col])
                    col--;
                else
                    row++;
            }
            return false;
        }
        /// <summary>
        /// 少数代码添加60个通道
        /// </summary>
        public static Dictionary<string, string> signalDic = new Dictionary<string, string>();

        public static void AddSingal()
        {
            int t = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 16; i++)
                {
                    t++;
                    string str = string.Empty;
                    if (t > 60)
                        break;
                     signalDic.Add($"通道{t}", $"R40{j}{Convert.ToString(i, 16).ToUpper()}");
                }
            }
        }
    }
}
