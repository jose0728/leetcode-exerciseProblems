using System;

namespace _108_将有序数组转换为二叉搜索树
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode res = SortedArrayToBST(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        public static TreeNode SortedArrayToBST(int[] nums)
        {
            return Dfs(nums, 0, nums.Length - 1);
        }

        public static TreeNode Dfs(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            //以升序数组的中间元素作为根节点 root
            int middle = left + (right - left) / 2;

            TreeNode root = new TreeNode(nums[middle]);
            root.left = Dfs(nums, left, middle - 1);
            root.right = Dfs(nums, middle + 1, right);
            return root;
        }
    }
}
