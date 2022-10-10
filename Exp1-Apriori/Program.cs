using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Exp1_Apriori
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main函数主要写使用逻辑，Apriori算法实现及置信度检验等写于Apriori.cs文件
            string[] dataList = File.ReadAllLines(@"..\..\..\TagsOfPapers.txt", Encoding.UTF8);
            //List<string> dataList = new List<string>(File.ReadAllLines(@"..\..\..\TagsOfPapers.txt", Encoding.UTF8));
            List<string> data_computerScience = new List<string>();
            List<string> data_physics = new List<string>();
            List<string> data_mathematics = new List<string>();
            List<string> data_statistics = new List<string>();
            for (int i = 0; i < dataList.Length; i++)
            {
                dataList[i] = dataList[i].Replace("\"", "");
                List<string> classAndTags = new List<string>(dataList[i].Split(','));
                bool isComputerScience = false, isPhysics = false, isMathematics = false, isStatistics = false;
                List<string> dataToRemove = new List<string>();
                if (classAndTags.Contains("Computer Science"))
                {
                    isComputerScience = true;
                    dataToRemove.Add("Computer Science");
                }
                if (classAndTags.Contains("Physics"))
                {
                    isPhysics = true;
                    dataToRemove.Add("Physics");
                }
                if (classAndTags.Contains("Mathematics"))
                {
                    isMathematics = true;
                    dataToRemove.Add("Mathematics");
                }
                if (classAndTags.Contains("Statistics"))
                {
                    isStatistics = true;
                    dataToRemove.Add("Statistics");
                }
                dataToRemove.ForEach(item => classAndTags.Remove(item));
                string tagsData = string.Join(',', classAndTags);
                if (isComputerScience) data_computerScience.Add(tagsData);
                if (isPhysics) data_physics.Add(tagsData);
                if (isMathematics) data_mathematics.Add(tagsData);
                if (isStatistics) data_statistics.Add(tagsData);          
            }
            double support = 0.1, confidence = 1;
            Apriori a_computerScience = new Apriori(support, confidence, data_computerScience);
            Apriori a_physics = new Apriori(support, confidence, data_physics);
            Apriori a_mathematics = new Apriori(support, confidence, data_mathematics);
            Apriori a_statistics = new Apriori(support, confidence, data_mathematics);

            Console.WriteLine("\nComputer Science:\n");
            a_computerScience.ShowIteration();
            Console.WriteLine("================================= Dividing Line =================================");

            Console.WriteLine("\nPhysics:\n");
            a_physics.ShowIteration();
            Console.WriteLine("================================= Dividing Line =================================");

            Console.WriteLine("\nMathematics:\n");
            a_mathematics.ShowIteration();
            Console.WriteLine("================================= Dividing Line =================================");

            Console.WriteLine("\nStatistics:\n");
            a_statistics.ShowIteration();
            Console.WriteLine("================================= Dividing Line =================================");

            //Apriori apriori_test = new Apriori(0.2, 1, dataList);
            //apriori_test.ShowOriginData();
            //Console.WriteLine();
            //apriori_test.ShowIteration();
        }
    }
}
