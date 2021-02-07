using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _78_子集
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            var a = Subsets(nums);
        }

        /// <summary>
        /// 回溯法
        /// N 个元素的子集个数有 2^N 个
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>(1 << nums.Length);
            //先添加一个空的集合
            res.Add(new List<int>());
            foreach (int num in nums)
            {
                //每遍历一个元素就在之前子集中的每个集合追加这个元素，让他变成新的子集
                for (int i = 0, j = res.Count(); i < j; i++)
                {
                    //遍历之前的子集，重新封装成一个新的子集
                    List<int> list = new List<int>(res.ElementAt(i));
                    //然后在新的子集后面追加这个元素
                    list.Add(num);
                    //把这个新的子集添加到集合中
                    res.Add(list);
                }
            }
            return res;
        }
    }
}
