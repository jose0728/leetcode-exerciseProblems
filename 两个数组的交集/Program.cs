using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 2, 1 };
            int[] b = { 2, 2 };
            int[] c = Method2(a, b);
        }

        /// <summary>
        /// 双指针法
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Method1(int[] nums1, int[] nums2)
        {
            int i, j, k;
            i = j = k = 0;
            Array.Sort(nums1);
            Array.Sort(nums2);

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    j++;
                }
                else
                {
                    nums1[k] = nums1[i];
                    i++;
                    j++;
                    k++;
                }
            }
            int[] nums = new int[k];
            Array.Copy(nums1, nums, k);
            return nums;
        }

        /// <summary>
        /// hashset法
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Method2(int[] nums1, int[] nums2)
        {
            List<KeyValueModel> models = new List<KeyValueModel>();
            List<int> list = new List<int>();
            foreach (var item in nums1)
            {
                var tmp = models.FirstOrDefault(o => o.Key == item);
                if (tmp == null)
                    models.Add(new KeyValueModel { Key = item, Value = 1 });
                else
                {
                    tmp.Value += 1;
                }
            }
            foreach (var item in nums2)
            {
                var tmp = models.FirstOrDefault(o => o.Key == item);
                if (tmp != null)
                {
                    tmp.Value -= 1;
                    if (tmp.Value == 0)
                        models.Remove(tmp);
                    list.Add(item);
                }
            }
            int[] nums = list.ToArray();
            return nums;
        }
    }

    public class KeyValueModel
    {
        public int Key { get; set; }
        public int Value { get; set; }
    }
}
