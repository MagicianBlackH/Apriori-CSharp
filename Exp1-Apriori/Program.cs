using System;
using System.Collections.Generic;

namespace Exp1_Apriori
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main函数主要写使用逻辑，Apriori算法实现及置信度检验等写于Apriori.cs文件
            List<string> test = new List<string>();
            test.Add("牛奶,面包");
            test.Add("面包,尿布,啤酒,鸡蛋");
            test.Add("牛奶,尿布,啤酒,可乐");
            test.Add("面包,牛奶,尿布,啤酒");
            test.Add("面包,牛奶,尿布,可乐");
            Apriori apriori_test = new Apriori(3, 1, test);
            apriori_test.ShowOriginData();
            Console.WriteLine();
            apriori_test.ShowIteration();
        }
    }
}
