using System;
using System.Collections.Generic;
using System.Text;

namespace Exp1_Apriori
{
    class Apriori
    {
        // 支持度
        private int support;
        // 置信度
        private int confidence;
        // 原数据数据项二维表
        private List<List<string>> originDataTable;
        // 保存每次迭代的频繁项集
        private List<List<KeyValuePair<string, int>>> iterationResult;
        // 保存置信度
        private List<KeyValuePair<string, double>> confidenceResult;

        /** 
         * 构造函数
         * support - 初始化支持度
         * confidence - 初始化置信度
         * data - 数据，注意每条数据项要用英文逗号隔开
         */
        public Apriori (int support, int confidence, List<string> data)
        {
            // 初始化变量
            this.support = support;
            this.confidence = confidence;
            this.originDataTable = new List<List<string>>();
            this.iterationResult = new List<List<KeyValuePair<string, int>>>();
            this.confidenceResult = new List<KeyValuePair<string, double>>();
            List<string> originDataList = new List<string>(data);
            for (int i = 0; i < originDataList.Count; i++)
            {
                List<string> temp = new List<string>(originDataList[i].Split(','));
                temp.Sort();
                this.originDataTable.Add(temp);
            }
            // 运行算法
            this.Run();
        }

        /** 
         * 展示原数据
         */
        public void ShowOriginData()
        {
            for (int i = 0; i < this.originDataTable.Count; i++)
            {
                Console.Write(i + "\t");
                for (int j = 0; j < this.originDataTable[i].Count; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(this.originDataTable[i][j]);
                    } 
                    else
                    {
                        Console.Write(", " + this.originDataTable[i][j]);
                    }
                }
                Console.WriteLine();
            }
        }

        /**
         * 展示迭代过程
         */
        public void ShowIteration()
        {
            for (int i = 0; i < this.iterationResult.Count; i++)
            {
                Console.WriteLine("Iteration_" + (i + 1) + ":");
                for (int j = 0; j < this.iterationResult[i].Count; j++)
                {
                    Console.WriteLine("\t" + this.iterationResult[i][j].Key + "\t" + this.iterationResult[i][j].Value);
                }
                Console.WriteLine();
            }
        }

        /**
         * 展示置信度
         */
        public void ShowConfidence()
        {
            Console.WriteLine("Confidence：");
            for (int i = 0; i < this.confidenceResult.Count; i++)
            {
                Console.WriteLine("\t" + this.confidenceResult[i].Key + " : " + this.confidenceResult[i].Value);
            }
            Console.WriteLine();
        }

        /** 
         * 迭代求频繁项集，将每次迭代的结果存入 iterationResult 中
         */
        private void Iterate()
        {
            // TODO: 迭代算法实现，HPC负责
        }

        /**
         * 置信度计算，将结果存入 confidenceResult 中
         */
        private void ConfidenceCal()
        {
            // TODO: 置信度检验，FDX负责
        }

        /**
         * 跑算法，此函数在构造函数中调用，即构造 Apriori 对象后立即进行计算并将结果存储在相应的变量中
         */
        private void Run()
        {
            this.Iterate();
            this.ConfidenceCal();
        }
    }
}
