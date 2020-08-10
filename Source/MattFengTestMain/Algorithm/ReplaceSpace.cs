using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain
{
   /// <summary>
   /// 替换空格
   /// </summary>
   public class ReplaceSpace
    {
        //请实现一个函数，将一个字符串中的每个空格替换成“%20”。例如，当字符串为We Are Happy.则经过替换之后的字符串为We%20Are%20Happy。
        public  string replaceSpace(string str)
        {
            return str.Replace(" ", "%20");
     }
    }
}
