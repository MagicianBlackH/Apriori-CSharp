using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exp1_Apriori
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main函数主要写使用逻辑，Apriori算法实现及置信度检验等写于Apriori.cs文件
            string[] data = File.ReadAllLines(@"..\..\..\leetcode_tags.txt", Encoding.UTF8);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = data[i].Replace("\"", "");
            }
            List<string> dataList = new List<string>(data);
            Apriori apriori_test = new Apriori(0.2, 0.65, dataList);
            apriori_test.ShowOriginData();
            Console.WriteLine();
            apriori_test.ShowIteration();
            Console.WriteLine();
            apriori_test.ShowConfidence();
        }
    }
}
