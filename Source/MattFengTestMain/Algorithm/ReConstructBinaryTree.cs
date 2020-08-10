using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XY;

namespace MattFengTestMain
{
    //输入某二叉树的前序遍历和中序遍历的结果，请重建出该二叉树。假设输入的前序遍历和中序遍历的结果中都不含重复的数字。例如输入前序遍历序列{1,2,4,7,3,5,6,8}和中序遍历序列{4,7,2,1,5,3,8,6}，则重建二叉树并返回。

    /// <summary>
    /// 重建二叉树
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }
    public class ReConstructBinaryTree
    {

        public  TreeNode reConstructBinaryTree(int[] pre, int[] tin)
        {
            var result = this.reConstructBinaryTree(pre, 0, pre.Length - 1, tin, 0, tin.Length - 1);

            return result;
        }

        private TreeNode reConstructBinaryTree(int[] pre,int startPre,int endPre,int[] tin,int startTin,int endTin)
        {
            if (startPre > endPre || startTin > endTin)
                return null;
            TreeNode root =new TreeNode( pre[startPre]);

            for (int i = startTin; i <= endTin; i++)
            {
                if (pre[startPre] == tin[i])
                {
                    root.left = reConstructBinaryTree(pre, startPre + 1, startPre + i - startTin, tin, startTin, i- 1);
                    root.right = reConstructBinaryTree(pre, startPre + i - startTin + 1, endPre, tin, i+1, endTin);
                }
            }
            return root;
        }
    }
}
