using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace HeBianGu.Product.CommonService.ThreadTester
{
    [TestClass]
    public class UnitTest_Task
    {
        [TestMethod]
        /// <summary> 延续任务执行 </summary>

        public void TestMethod1()
        {

            Task task1 = new Task("第一个任务执行中..".CommandLogWithAction());

            Task task2 = task1.ContinueWith(l =>
            {
                "任务执行完成！".TaskLog(l);
                "第二个任务执行中！".TaskLog();
            });

            Task task3 = task1.ContinueWith(l =>
            {
                "任务执行完成！".TaskLog(l);
                "第三个任务执行中！".TaskLog();
            });

            Task task4 = task3.ContinueWith(l =>
             {
                 "任务执行完成！".TaskLog(l);
                 "第四个任务执行中！".TaskLog();
             });

            task1.Start();

        }

        [TestMethod]
        /// <summary> 延续任务执行 - 带条件 </summary>

        public void TestMethod2()
        {

            Task task1 = new Task("第一个任务执行中..".CommandLogWithAction());

            Task task2 = task1.ContinueWith(l =>
            {
                "第一个任务发生了错误！".TaskLog(l);
                "第二个任务执行中！".TaskLog();
            }, TaskContinuationOptions.OnlyOnFaulted);//  TooDo ：当上一个任务错误时执行

            task1.Start();

            Task task3 = new Task(() =>
            {
                int z = 0;
                double v = 20 / z;
            });

            Task task5 = task1.ContinueWith(l =>
            {
                "任务发生了错误！".TaskLog(l);

                "第二个任务执行中！".TaskLog();

                foreach (var item in l.Exception.InnerExceptions)
                {
                    item.Message.TaskLog();
                }
            }, TaskContinuationOptions.OnlyOnFaulted);//  TooDo ：当上一个任务错误时执行

            try
            {
                task3.Start();
            }
            catch (Exception ex)
            {
                ex.Message.TaskLog();
            }


        }


        [TestMethod]
        /// <summary> 延续任务执行 </summary>

        public void TestMethod3()
        {

            Task task1 = Task.Run(() => Debug.WriteLine("任务执行！"));

            Task task2 = Task.Run(() =>
            {
                Task.WaitAll(task1);

                Debug.WriteLine("任务执行完了");
            });

        }

        [TestMethod]
        /// <summary> 延续任务执行 </summary>

        public void TestMethod4()
        {

            Queue<HeBianGu> collection = new Queue<HeBianGu>();



            Task task = Task.Run(() =>
            {
                while (true)
                {
                    HeBianGu he = new HeBianGu();
                    collection.Enqueue(he);

                    Thread.Sleep(1000);

                    Debug.WriteLine("时间:" + DateTime.Now + "入栈:" + he.Value);

                }
            });

            List<Task> taskCollection = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                taskCollection.Add(new Task(() =>
            {
                var value = collection.Dequeue();



            }));
            }

            Task task1 = Task.Run(() => Debug.WriteLine("任务执行！"));

            Task task2 = Task.Run(() =>
            {
                Task.WaitAll(task1);

                Debug.WriteLine("任务执行完了");
            });

        }

    }
}
