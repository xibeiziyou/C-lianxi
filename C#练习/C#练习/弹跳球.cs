using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_练习
{
    /// <summary>
    /// 一个孩子在一栋高楼的 n 楼上玩球。 该楼层离地面的高度 h 是已知的。
    /// 他将球扔出窗外。球会反弹（例如），达到其高度的三分之二（反弹 0.66）。
    /// 他的母亲从离地面 1.5 米的窗户向外望去。
    /// 妈妈会看到球从她的窗前经过多少次（包括球下落和弹跳的时候）？
    /// 要进行有效的实验，必须满足三个条件：
    /// 浮点型参数 “h” （以米为单位） 必须大于 0
    /// 浮点型参数 “bounce” 必须大于 0 且小于 1
    /// 浮点参数 “window” 必须小于 h。
    /// 如果满足上述三个条件，则返回一个正整数，否则返回 -1。
    /// 注意：
    /// 只有当篮板球的高度严格大于 window 参数时，才能看到球。
    /// </summary>
    internal class 弹跳球
    {
        public static int bouncingBall(double h, double bounce, double window)
        {
            if (h > 0 && bounce > 0 && bounce < 1 && window < h)
            {
                int n = 0;
                double hb;
                do
                {
                    hb = HB(h, bounce, n);
                    n++;
                }
                while ( hb > window);
                return 2 * (n - 1) + 1;
            }
            // your code
            return -1;
        }

        public static double HB(double h, double bounce, int n)
        {
            double hb = h * bounce;
            for (int i = 0; i < n; i++) 
            {
                hb *= bounce;
            }
            return hb;
        }

        public static int bouncingBall优化(double h, double bounce, double window)
        {
            // 检查输入是否有效
            if (h <= 0 || bounce <= 0 || bounce >= 1 || window >= h)
            {
                return -1;
            }

            int count = 0;

            // 计算反弹过程
            while (h > window)
            {
                count++;          // 下落被看到
                h *= bounce;      // 反弹高度
                if (h > window)
                {
                    count++;      // 上升被看到
                }
            }

            return count;
        }
    }

}
