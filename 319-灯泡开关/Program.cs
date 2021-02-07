using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _319_灯泡开关
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 约数，又称因数。整数a除以整数b(b≠0) 除得的商正好是整数而没有余数，我们就说a能被b整除，或b能整除a。
        /// a称为b的倍数，b称为a的约数。
        /// 从我们观察可以发现，如果一个灯泡有奇数个约数，那么最后这个灯泡一定会亮着。
        /// 什么，你问我奇数是什么？奇数（odd）指不能被2整除的整数 ，数学表达形式为：2k+1， 奇数可以分为正奇数和负奇数。
        /// 所以其实我们是求，从1-n有多少个数的约数有奇数个。而有奇数个约数的数一定是完全平方数。 
        /// 这是因为，对于数n，如果m是它的约数，则n/m也是它的约数，若m≠n/m，则它的约数是以m、n/m的形式成对出现的。
        /// 而m＝n/m成立且n/m是正整数时，n是完全平方数,而它有奇数个约数。
        /// 我们再次转化问题，求1-n有多少个数是完全平方数。
        /// 什么，你又不知道什么是完全平方数了？完全平方指用一个整数乘以自己例如11，22，3*3等，依此类推。
        /// 若一个数能表示成某个整数的平方的形式，则称这个数为完全平方数。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int BulbSwitch(int n)
        {
            return (int)Math.Sqrt(n);
        }
    }
}
