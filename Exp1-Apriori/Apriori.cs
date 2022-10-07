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

        /** 构造函数
         * support - 初始化支持度
         * confidence - 初始化置信度
         * data - 数据，注意每条数据项要用英文逗号隔开
         */
        public Apriori (int support, int confidence, List<string> data)
        {
            this.support = support;
            this.confidence = confidence;
            this.originDataTable = new List<List<string>>();
            List<string> originDataList = new List<string>(data);
            for (int i = 0; i < originDataList.Count; i++)
            {
                List<string> temp = new List<string>(originDataList[i].Split(','));
                temp.Sort();
                this.originDataTable.Add(temp);
            }
        }

        /** 展示原数据
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
    }
}
