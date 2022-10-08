﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        private List<Dictionary<string, int>> iterationResult;
        // 保存置信度
        private Dictionary<string, double> confidenceResult;

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
            this.iterationResult = new List<Dictionary<string, int>>();
            this.confidenceResult = new Dictionary<string, double>();
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
            Console.WriteLine("OriginData:");
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
                // 按 Key 排序一下再输出，好看
                List<KeyValuePair<string, int>> dicList = this.iterationResult[i].ToList();
                dicList.Sort((p1, p2) => p1.Key.CompareTo(p2.Key));
                for (int j = 0; j < dicList.Count; j++)
                {
                    Console.WriteLine("\t" + dicList[j].Key + "\t" + dicList[j].Value);
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
            // 按 Key 排序一下再输出，好看
            List<KeyValuePair<string, double>> dicList = this.confidenceResult.ToList();
            dicList.Sort((p1, p2) => p1.Key.CompareTo(p2.Key));
            for (int i = 0; i < dicList.Count; i++)
            {
                Console.WriteLine("\t" + dicList[i].Key + " : " + dicList[i].Value);
            }
            Console.WriteLine();
        }

        /** 
         * 迭代求频繁项集，将每次迭代的结果存入 iterationResult 中
         */
        private void Iterate()
        {
            // TODO: 迭代算法实现，HPC负责
            int oriCount = this.originDataTable.Count;
            if (oriCount <= 0)
            {
                return;
            }
            // 从 originDataTable 得到一次项集
            Dictionary<string, int> one = new Dictionary<string, int>();
            for (int i = 0; i < oriCount; i++)
            {
                for (int j = 0; j < this.originDataTable[i].Count; j++)
                {
                    if (one.ContainsKey(this.originDataTable[i][j]))
                    {
                        one[this.originDataTable[i][j]] += 1;
                    }
                    else
                    {
                        one.Add(this.originDataTable[i][j], 1);
                    }
                }
            }
            // 剔除操作，得到一次频繁项集
            foreach (KeyValuePair<string, int> item in one)
            {
                if (item.Value < this.support)
                {
                    one.Remove(item.Key);
                }
            }
            // 结果加入 iterationResult
            this.iterationResult.Add(one);
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
