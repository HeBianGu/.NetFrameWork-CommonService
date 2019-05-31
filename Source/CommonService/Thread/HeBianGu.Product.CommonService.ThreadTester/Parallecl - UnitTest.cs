using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace HeBianGu.Product.CommonService.ThreadTester
{
    [TestClass]
    public class UnitTest2
    {

        /// <summary> 并行 </summary>

        [TestMethod]
        public void TestMethod1()
        {
            var result = Parallel.For(1, 100, l =>
                   {
                       Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,当前索引:" + l + " 时间:" + DateTime.Now);

                       Thread.Sleep(1000);

                       Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "完成执行..,当前索引:" + l + " 时间:" + DateTime.Now);
                   });


            //结果：
            //线程: 8正在执行..,当前索引: 25 时间: 2018 / 7 / 11 14:24:54
            //线程: 10正在执行..,当前索引: 1 时间: 2018 / 7 / 11 14:24:54
            //线程: 13正在执行..,当前索引: 73 时间: 2018 / 7 / 11 14:24:54
            //线程: 9正在执行..,当前索引: 49 时间: 2018 / 7 / 11 14:24:54
            //线程: 14正在执行..,当前索引: 97 时间: 2018 / 7 / 11 14:24:54
            //线程: 15正在执行..,当前索引: 2 时间: 2018 / 7 / 11 14:24:55
            //线程: 8完成执行..,当前索引: 25 时间: 2018 / 7 / 11 14:24:55
            //线程: 10完成执行..,当前索引: 1 时间: 2018 / 7 / 11 14:24:55
            //线程: 10正在执行..,当前索引: 3 时间: 2018 / 7 / 11 14:24:55
            //线程: 14完成执行..,当前索引: 97 时间: 2018 / 7 / 11 14:24:55
            //线程: 8正在执行..,当前索引: 26 时间: 2018 / 7 / 11 14:24:55
            //线程: 9完成执行..,当前索引: 49 时间: 2018 / 7 / 11 14:24:55
            //线程: 9正在执行..,当前索引: 50 时间: 2018 / 7 / 11 14:24:55
            //线程: 14正在执行..,当前索引: 98 时间: 2018 / 7 / 11 14:24:55
            //线程: 13完成执行..,当前索引: 73 时间: 2018 / 7 / 11 14:24:55
            //线程: 13正在执行..,当前索引: 74 时间: 2018 / 7 / 11 14:24:55
            //线程: 16正在执行..,当前索引: 28 时间: 2018 / 7 / 11 14:24:56
            //线程: 15完成执行..,当前索引: 2 时间: 2018 / 7 / 11 14:24:56
            //线程: 15正在执行..,当前索引: 5 时间: 2018 / 7 / 11 14:24:56
            //线程: 10完成执行..,当前索引: 3 时间: 2018 / 7 / 11 14:24:56

            //分析:1、一共开启了六个并行线程，当线程结束后后面任务才继续执行
            //     2、执行的循序跟索引无关
        }


        [TestMethod]
        public void TestMethod2()
        {
            ParallelOptions option = new ParallelOptions();
            option.MaxDegreeOfParallelism = 2;
            var result = Parallel.For(1, 10, option, l =>
             {
                 Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,当前索引:" + l + " 时间:" + DateTime.Now);

                 Thread.Sleep(1000);

             });


            //结果：
            //线程: 8正在执行..,当前索引: 5 时间: 2018 / 7 / 11 14:33:47
            //线程: 10正在执行..,当前索引: 1 时间: 2018 / 7 / 11 14:33:47
            //线程: 10正在执行..,当前索引: 2 时间: 2018 / 7 / 11 14:33:48
            //线程: 9正在执行..,当前索引: 6 时间: 2018 / 7 / 11 14:33:48
            //线程: 9正在执行..,当前索引: 7 时间: 2018 / 7 / 11 14:33:49
            //线程: 10正在执行..,当前索引: 3 时间: 2018 / 7 / 11 14:33:49
            //线程: 13正在执行..,当前索引: 8 时间: 2018 / 7 / 11 14:33:50
            //线程: 10正在执行..,当前索引: 4 时间: 2018 / 7 / 11 14:33:50
            //线程: 8正在执行..,当前索引: 9 时间: 2018 / 7 / 11 14:33:51

            //分析:1、一共开启了两个线程
        }


        [TestMethod]
        public void TestMethod3()
        {
            ParallelOptions option = new ParallelOptions();
            option.MaxDegreeOfParallelism = 8;
            var result = Parallel.For(1, 10, option, l =>
            {
                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,当前索引:" + l + " 时间:" + DateTime.Now);

                Thread.Sleep(1000);

            });


            //结果：
            //线程: 8正在执行..,当前索引: 2 时间: 2018 / 7 / 11 14:45:23
            //线程: 10正在执行..,当前索引: 1 时间: 2018 / 7 / 11 14:45:23
            //线程: 9正在执行..,当前索引: 3 时间: 2018 / 7 / 11 14:45:23
            //线程: 13正在执行..,当前索引: 4 时间: 2018 / 7 / 11 14:45:23
            //线程: 14正在执行..,当前索引: 5 时间: 2018 / 7 / 11 14:45:23
            //线程: 15正在执行..,当前索引: 6 时间: 2018 / 7 / 11 14:45:23
            //线程: 8正在执行..,当前索引: 7 时间: 2018 / 7 / 11 14:45:24
            //线程: 10正在执行..,当前索引: 8 时间: 2018 / 7 / 11 14:45:24
            //线程: 13正在执行..,当前索引: 9 时间: 2018 / 7 / 11 14:45:24

            //分析:1、虽然设置最大8个但是不起作用，最大限制6个
        }
        [TestMethod]
        public void TestMethod4()
        {
            ParallelOptions option = new ParallelOptions();
            option.MaxDegreeOfParallelism = 2;
            var result = Parallel.For(1, 5, option, l =>
            {
                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,当前索引:" + l + " 时间:" + DateTime.Now);

                Thread.Sleep(1000);

            });

            Debug.WriteLine("第一个Parallel完成执行！");

            var result1 = Parallel.For(6, 10, option, l =>
            {
                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,当前索引:" + l + " 时间:" + DateTime.Now);

                Thread.Sleep(1000);

            });

            Debug.WriteLine("第二个Parallel完成执行！");

            //结果：
            //线程: 8正在执行..,当前索引: 3 时间: 2018 / 7 / 11 14:43:32
            //线程: 10正在执行..,当前索引: 1 时间: 2018 / 7 / 11 14:43:32
            //线程: 10正在执行..,当前索引: 2 时间: 2018 / 7 / 11 14:43:33
            //线程: 8正在执行..,当前索引: 4 时间: 2018 / 7 / 11 14:43:33
            //第一个Parallel完成执行！
            //线程: 10正在执行..,当前索引: 6 时间: 2018 / 7 / 11 14:43:34
            //线程: 8正在执行..,当前索引: 8 时间: 2018 / 7 / 11 14:43:34
            //线程: 10正在执行..,当前索引: 7 时间: 2018 / 7 / 11 14:43:35
            //线程: 9正在执行..,当前索引: 9 时间: 2018 / 7 / 11 14:43:35
            //第二个Parallel完成执行！

            //分析:1、两个Parallel跟不是同时执行，Parallel是阻塞的执行完第一个再执行到下一个
        }


        [TestMethod]
        public void TestMethod5()
        {

            List<HeBianGu> collection = new List<HeBianGu>();
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());


            var result = Parallel.ForEach<HeBianGu>(collection, l =>
              {
                  Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,当前索引:" + l.Value + " 时间:" + DateTime.Now);

                  Thread.Sleep(1000);

              });

            //结果：
            //线程: 9正在执行..,当前索引: 2 时间: 2018 / 7 / 11 15:15:33
            //线程: 8正在执行..,当前索引: 1 时间: 2018 / 7 / 11 15:15:33
            //线程: 10正在执行..,当前索引: 0 时间: 2018 / 7 / 11 15:15:33
            //线程: 14正在执行..,当前索引: 3 时间: 2018 / 7 / 11 15:15:33
            //线程: 13正在执行..,当前索引: 4 时间: 2018 / 7 / 11 15:15:33
            //线程: 15正在执行..,当前索引: 5 时间: 2018 / 7 / 11 15:15:34
            //线程: 9正在执行..,当前索引: 6 时间: 2018 / 7 / 11 15:15:34

            //分析:随机执行集合
        }

        [TestMethod]
        public void TestMethod6()
        {

            List<HeBianGu> collection = new List<HeBianGu>();
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());
            collection.Add(new HeBianGu());


            var result = Parallel.ForEach<HeBianGu>(collection, (l, k) =>
            {
                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,当前索引:" + l.Value + " 时间:" + DateTime.Now);

                if (l.Value == 3)
                {
                    Debug.WriteLine("开始执行退出！");
                    k.Break();
                    Debug.WriteLine("执行退出完成！");
                }

                Thread.Sleep(1000);

            });

            Debug.WriteLine("执行完成！");

            //结果：
            //线程: 10正在执行..,当前索引: 0 时间: 2018 / 7 / 11 15:20:53
            //线程: 8正在执行..,当前索引: 1 时间: 2018 / 7 / 11 15:20:53
            //线程: 9正在执行..,当前索引: 2 时间: 2018 / 7 / 11 15:20:53
            //线程: 14正在执行..,当前索引: 4 时间: 2018 / 7 / 11 15:20:53
            //线程: 13正在执行..,当前索引: 3 时间: 2018 / 7 / 11 15:20:53
            //开始执行退出！
            //执行退出完成！
            //执行完成！

            //分析:满足条件自动退出


        }

        [TestMethod]
        public void TestMethod7()
        {

            Action action = () =>
              {
                  Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "时间:" + DateTime.Now);

                  Thread.Sleep(1000);

              };

            Parallel.Invoke(action, action, action, action, action, action, action, action);


            //结果：
            //线程: 10时间: 2018 / 7 / 11 15:28:02
            //线程: 8时间: 2018 / 7 / 11 15:28:02
            //线程: 9时间: 2018 / 7 / 11 15:28:02
            //线程: 14时间: 2018 / 7 / 11 15:28:02
            //线程: 13时间: 2018 / 7 / 11 15:28:02
            //线程: 15时间: 2018 / 7 / 11 15:28:03
            //线程: 9时间: 2018 / 7 / 11 15:28:03
            //线程: 8时间: 2018 / 7 / 11 15:28:03

            //分析：异步开启6个线程执行action操作
        }

        [TestMethod]
        public void TestMethod8()
        {

            Stopwatch watch = new Stopwatch();

            Action<int> action = l =>
            {
                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "时间:" + DateTime.Now);

                Thread.Sleep(1000);

            };

            watch.Start();
            Parallel.For(0, 8, action);
            watch.Stop();

            Debug.WriteLine("异步用时：" + watch.Elapsed.TotalSeconds);

            watch.Restart();

            for (int i = 0; i < 8; i++)
            {
                action(i);
            }

            watch.Stop();
            Debug.WriteLine("同步用时：" + watch.Elapsed.TotalSeconds);

            //结果：
            //线程: 8时间: 2018 / 7 / 11 15:29:39
            //线程: 9时间: 2018 / 7 / 11 15:29:39
            //线程: 10时间: 2018 / 7 / 11 15:29:39
            //线程: 14时间: 2018 / 7 / 11 15:29:39
            //线程: 13时间: 2018 / 7 / 11 15:29:39
            //线程: 15时间: 2018 / 7 / 11 15:29:40
            //线程: 8时间: 2018 / 7 / 11 15:29:40
            //线程: 9时间: 2018 / 7 / 11 15:29:40
            //异步用时：2.0403419
            //线程: 10时间: 2018 / 7 / 11 15:29:41
            //线程: 10时间: 2018 / 7 / 11 15:29:42
            //线程: 10时间: 2018 / 7 / 11 15:29:43
            //线程: 10时间: 2018 / 7 / 11 15:29:44
            //线程: 10时间: 2018 / 7 / 11 15:29:45
            //线程: 10时间: 2018 / 7 / 11 15:29:46
            //线程: 10时间: 2018 / 7 / 11 15:29:47
            //线程: 10时间: 2018 / 7 / 11 15:29:48
            //同步用时：8.0110889

            //分析：执行8个任务异步执行要比同步执行快很多
        }

        [TestMethod]
        public void TestMethod9()
        {

            Stopwatch watch = new Stopwatch();

            Action<int> action = l =>
            {
                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "时间:" + DateTime.Now);

                Thread.Sleep(1000);

            };

            watch.Start();
            Parallel.For(0, 20, action);
            watch.Stop();

            Debug.WriteLine("异步用时：" + watch.Elapsed.TotalSeconds);

            watch.Restart();

            for (int i = 0; i < 20; i++)
            {
                action(i);
            }

            watch.Stop();
            Debug.WriteLine("同步用时：" + watch.Elapsed.TotalSeconds);

            //结果：
            //线程: 8时间: 2018 / 7 / 11 15:33:43
            //线程: 9时间: 2018 / 7 / 11 15:33:43
            //线程: 10时间: 2018 / 7 / 11 15:33:43
            //线程: 14时间: 2018 / 7 / 11 15:33:43
            //线程: 13时间: 2018 / 7 / 11 15:33:43
            //线程: 15时间: 2018 / 7 / 11 15:33:44
            //线程: 8时间: 2018 / 7 / 11 15:33:44
            //线程: 9时间: 2018 / 7 / 11 15:33:44
            //线程: 14时间: 2018 / 7 / 11 15:33:44
            //线程: 13时间: 2018 / 7 / 11 15:33:44
            //线程: 10时间: 2018 / 7 / 11 15:33:44
            //线程: 15时间: 2018 / 7 / 11 15:33:45
            //线程: 8时间: 2018 / 7 / 11 15:33:45
            //线程: 16时间: 2018 / 7 / 11 15:33:45
            //线程: 13时间: 2018 / 7 / 11 15:33:45
            //线程: 9时间: 2018 / 7 / 11 15:33:45
            //线程: 10时间: 2018 / 7 / 11 15:33:45
            //线程: 14时间: 2018 / 7 / 11 15:33:45
            //线程: 17时间: 2018 / 7 / 11 15:33:46
            //线程: 15时间: 2018 / 7 / 11 15:33:46
            //异步用时：4.0626995
            //线程: 10时间: 2018 / 7 / 11 15:33:47
            //线程: 10时间: 2018 / 7 / 11 15:33:48
            //线程: 10时间: 2018 / 7 / 11 15:33:49
            //线程: 10时间: 2018 / 7 / 11 15:33:50
            //线程: 10时间: 2018 / 7 / 11 15:33:51
            //线程: 10时间: 2018 / 7 / 11 15:33:52
            //线程: 10时间: 2018 / 7 / 11 15:33:53
            //线程: 10时间: 2018 / 7 / 11 15:33:54
            //线程: 10时间: 2018 / 7 / 11 15:33:55
            //线程: 10时间: 2018 / 7 / 11 15:33:56
            //线程: 10时间: 2018 / 7 / 11 15:33:57
            //线程: 10时间: 2018 / 7 / 11 15:33:58
            //线程: 10时间: 2018 / 7 / 11 15:33:59
            //线程: 10时间: 2018 / 7 / 11 15:34:00
            //线程: 10时间: 2018 / 7 / 11 15:34:01
            //线程: 10时间: 2018 / 7 / 11 15:34:02
            //线程: 10时间: 2018 / 7 / 11 15:34:03
            //线程: 10时间: 2018 / 7 / 11 15:34:04
            //线程: 10时间: 2018 / 7 / 11 15:34:05
            //线程: 10时间: 2018 / 7 / 11 15:34:06
            //同步用时：20.0320291

            //分析：异步执行要比同步执行快很多
        }

        [TestMethod]
        public void TestMethod10()
        {
            int v = 0;

            object obj = new object();

            Stopwatch watch = new Stopwatch();

            Action<int> action = l =>
            {
                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "时间:" + DateTime.Now + "当前值：" + v++ + "索引值：" + l);

                Thread.Sleep(1000);

            };
            watch.Start();
            Parallel.For(0, 8, action);
            watch.Stop();
            Debug.WriteLine("不加锁用时：" + watch.Elapsed.TotalSeconds);

            v = 0;
            Action<int> action1 = l =>
             {
                 lock (obj)
                 {
                     Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "时间:" + DateTime.Now + "当前值：" + v++ + "索引值：" + l);
                 }

                 Thread.Sleep(1000);

             };
            watch.Restart();
            Parallel.For(0, 8, action1);
            watch.Stop();
            Debug.WriteLine("加锁用时1：" + watch.Elapsed.TotalSeconds);

            v = 0;
            Action<int> action2 = l =>
            {
                lock (obj)
                {
                    Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "时间:" + DateTime.Now + "当前值：" + v++ + "索引值：" + l);

                    Thread.Sleep(1000);
                }

            };
            watch.Restart();
            Parallel.For(0, 8, action2);
            watch.Stop();
            Debug.WriteLine("加锁用时2：" + watch.Elapsed.TotalSeconds);

            //结果：
            //线程: 10时间: 2018 / 7 / 11 16:05:11当前值：0索引值：0
            //线程: 9时间: 2018 / 7 / 11 16:05:11当前值：1索引值：4
            //线程: 8时间: 2018 / 7 / 11 16:05:11当前值：2索引值：2
            //线程: 13时间: 2018 / 7 / 11 16:05:11当前值：3索引值：6
            //线程: 14时间: 2018 / 7 / 11 16:05:11当前值：4索引值：1
            //线程: 15时间: 2018 / 7 / 11 16:05:12当前值：5索引值：3
            //线程: 10时间: 2018 / 7 / 11 16:05:12当前值：6索引值：5
            //线程: 9时间: 2018 / 7 / 11 16:05:12当前值：7索引值：7
            //不加锁用时：2.0439261
            //线程: 10时间: 2018 / 7 / 11 16:05:13当前值：0索引值：0
            //线程: 9时间: 2018 / 7 / 11 16:05:13当前值：1索引值：4
            //线程: 8时间: 2018 / 7 / 11 16:05:13当前值：2索引值：2
            //线程: 14时间: 2018 / 7 / 11 16:05:13当前值：3索引值：1
            //线程: 15时间: 2018 / 7 / 11 16:05:13当前值：4索引值：3
            //线程: 13时间: 2018 / 7 / 11 16:05:13当前值：5索引值：6
            //线程: 16时间: 2018 / 7 / 11 16:05:14当前值：6索引值：5
            //线程: 10时间: 2018 / 7 / 11 16:05:14当前值：7索引值：7
            //加锁用时1：2.0045308
            //线程: 8时间: 2018 / 7 / 11 16:05:15当前值：0索引值：0
            //线程: 9时间: 2018 / 7 / 11 16:05:16当前值：1索引值：4
            //线程: 10时间: 2018 / 7 / 11 16:05:17当前值：2索引值：2
            //线程: 13时间: 2018 / 7 / 11 16:05:18当前值：3索引值：6
            //线程: 14时间: 2018 / 7 / 11 16:05:19当前值：4索引值：1
            //线程: 15时间: 2018 / 7 / 11 16:05:20当前值：5索引值：3
            //线程: 16时间: 2018 / 7 / 11 16:05:21当前值：6索引值：5
            //线程: 17时间: 2018 / 7 / 11 16:05:22当前值：7索引值：7
            //加锁用时2：8.0370031

            //分析：1、当改变全局变量值时，多线程内部随机
            //      2、加锁取值可以改变随机为顺序
            //      3、但加锁最好不要全部加，否则跟同步执行效率差不多或者不如同步效率高

        }
    }

    public class HeBianGu
    {
        static int Count;

        public HeBianGu()
        {
            _value = Count++;
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
