using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskManagerConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = { 100,55,58,39,18,90,160,150,38,184};
            while (true)
            {
                int[] orderList = new int[targets.Length];
                Console.WriteLine("起始位置为100");
                Console.WriteLine("模拟移动位置是55，58，39，18，90，160，150，38，184。");
                Console.WriteLine("1:FCFS 2:SSTF 3:SCAN 4:CSCAN else number:quit");
                var count = Console.ReadLine();
                var num = 0;
                try
                {
                    num = int.Parse(count);
                    if (num > 4 || num < 1)
                    {
                        goto END;
                    }
                    switch (num)
                    {
                        case 1:
                            orderList = targets;
                            break;
                        case 2:
                            #region
                            var minPos = 0;
                            var current = targets[0];
                            var isOrder = 0;
                            var minRec = 0;
                            
                            orderList[isOrder] = targets[0];
                            isOrder++;

                            var tempList=new List<int>(targets);
                            tempList.RemoveAt(0);

                            while (isOrder != targets.Length)
                            {
                                minPos = 0;
                                minRec = Math.Abs(current- tempList[minPos]);
                                for (var i = 0; i < tempList.Count; i++)
                                {
                                    var minTemp = Math.Abs(current- tempList[i]);
                                    if (minTemp < minRec)
                                    {
                                        minPos = i;
                                        minRec = minTemp;
                                    }
                                }
                                orderList[isOrder] = tempList[minPos];
                                current = tempList[minPos];
                                isOrder++;
                                tempList.RemoveAt(minPos);
                                if (isOrder == targets.Length - 1)
                                {
                                    orderList[isOrder] = tempList[0]; ;
                                    isOrder++;
                                }
                            }
                            #endregion
                            break;
                        case 3:
                            #region
                            var c3Order = 0;
                            var tempListOrder = new List<int>(targets);
                            tempListOrder.Sort();
                            var index = tempListOrder.IndexOf(targets[0]);
                            orderList[c3Order] = tempListOrder[index];
                            c3Order++;
                            for (int c = index+1; c < tempListOrder.Count; c++)
                            {
                                orderList[c3Order] = tempListOrder[c];
                                c3Order++;
                            }
                            for (int v = 0; v < index; v++)
                            {
                                orderList[targets.Length-v-1] = tempListOrder[v];
                                c3Order++;
                            }
                            #endregion
                            break;
                        case 4:
                            #region
                            var c4Order = 0;
                            var tempListOrder2 = new List<int>(targets);
                            tempListOrder2.Sort();
                            var index2 = tempListOrder2.IndexOf(targets[0]);
                            orderList[c4Order] = tempListOrder2[index2];
                            c4Order++;
                            for (int c = index2 + 1; c < tempListOrder2.Count; c++)
                            {
                                orderList[c4Order] = tempListOrder2[c];
                                c4Order++;
                            }
                            for (int v = 0; v < index2; v++)
                            {
                                orderList[c4Order] = tempListOrder2[v];
                                c4Order++;
                            }
                            #endregion
                            break;
                    }
                    Console.Clear();
                    outOrder(orderList);
                    outDistances(orderList);
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("ERROR:{0}！",ex.Message);
                }
            }
            END: Console.Write("");
        }

        /// <summary>
        /// 输出访问顺序
        /// </summary>
        /// <param name="dis"></param>
        static void outOrder(int [] dis)
        {
            Console.WriteLine("访问顺序是");
            for (var i=0;i<dis.Length;i++)
            {
                Console.Write("第{0}个是:{1}, ",(i+1),dis[i]);
            }
            Console.Write("\n");
        }
        /// <summary>
        /// 输出每次访问距离
        /// </summary>
        /// <param name="dis"></param>
        static void outDistances(int[] dis)
        {
            double total = 0;
            Console.WriteLine("每次移动距离是");
            for (var i = 0; i < dis.Length-1; i++)
            {
                var tempDistance = Math.Abs((dis[(i + 1)] - dis[i]));
                total += tempDistance;
                Console.Write("第{0}个是:{1}, ", (i + 1), tempDistance);
            }
            Console.Write("\n");
            Console.WriteLine("平均寻道距离是：{0}",(total/(dis.Length-1)));
            Console.Write("\n");
        }
    }
}
