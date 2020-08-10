using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain.Algorithm
{ 
    /// <summary>
    /// 旋转数组中的最小数字
    /// </summary>
    public  class MinNumberInRotateArray
    {
        //把一个数组最开始的若干个元素搬到数组的末尾，我们称之为数组的旋转。输入一个（非递减有序、非递减有序、非递减有序）的数组的一个旋转，输出旋转数组的最小元素。例如数组{3,4,5,1,2}为{1,2,3,4,5}的一个旋转，该数组的最小值为1。
        public int minNumberInRotateArray(int[] rotateArray)
        {
            if (rotateArray == null || rotateArray.Length == 0)
                return 0;
            int low = 0;
            int high = rotateArray.Length - 1;
            int mid = 0;
            while (rotateArray[low] >= rotateArray[high])
            {
                if (high - low == 1)
                {
                    mid = high;
                    break;
                }
                mid = (low + high) / 2;

                if ((rotateArray[low] == rotateArray[mid]) &&(rotateArray[low]) == rotateArray[high])
                {
                    return GetMinByOrder(rotateArray);
                }

                if (rotateArray[low] <= rotateArray[mid])
                {
                    //左边有序
                    low = mid;
                }
                else
                {
                    //右边有序
                    high = mid;

                }

            }
            return rotateArray[mid];
        }

        private int GetMinByOrder(int[] array)
        {
            int min = array[0];
            foreach (int item in array)
            {
                if (item < min)
                    min = item;
            }
            return min;
        }
    }
}
