using System;
using System.Collections.Generic;
using System.Text;

namespace MattFengTestMain
{
    /// <summary>
    /// 从尾到头打印链表
    /// </summary>
   public class PrintListFromTailToHead
    {
        // 输入一个链表，按链表从尾到头的顺序返回一个ArrayList。
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
            }
        }
        public List<int> printListFromTailToHead(ListNode listNode)
        {
            List<int> first = new List<int>();
            List<int> last = new List<int>();
            while (listNode!= null)
            {
                first.Add(listNode.val);
                listNode = listNode.next;
            }
            for (int i = first.Count-1; i >=0; i--)
            {
                last.Add(first[i]);
            }
            return last;
        }
    }
}
