using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.ThreadTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Debug.WriteLine("当前主线程ID:" + Thread.CurrentThread.ManagedThreadId);

            this.AsyncMethod();

            Debug.WriteLine("主线程完成！");

            while (true)
            {

            }

            //结果：
            //当前主线程ID: 10
            //Async方法开始: 10
            //Async方法Await: 10
            //主线程完成！
            //线程: 8正在执行..,时间: 2018 / 7 / 11 16:18:32
            //线程: 8完成执行..,时间: 2018 / 7 / 11 16:18:34
            //异步方法结束: 8

            //分析： async 内部await前面的代码扔属于主线程，await后面的代码属于异步线程

        }

        async void AsyncMethod()
        {
            Debug.WriteLine("Async方法开始:" + Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(1000);


            Action action = () =>
              {
                  Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,时间:" + DateTime.Now);

                  Thread.Sleep(2000);

                  Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "完成执行..,时间:" + DateTime.Now);

              };

            Task task = Task.Run(action);

            Debug.WriteLine("Async方法Await:" + Thread.CurrentThread.ManagedThreadId);

            await task;

            Debug.WriteLine("异步方法结束:" + Thread.CurrentThread.ManagedThreadId);


        }


        [TestMethod]
        public void TestMethod2()
        {

            Debug.WriteLine("当前主线程ID:" + Thread.CurrentThread.ManagedThreadId);

            this.AsyncMethod1();

            Debug.WriteLine("主线程完成！");

            while (true)
            {

            }

            //结果：
            //当前主线程ID: 10
            //AsyncMethod1方法开始: 10
            //AsyncMethod1方法Await: 10
            //AsyncMethod2方法开始: 10
            //“vstest.executionengine.x86.exe”(CLR v4.0.30319: TestSourceHost: Enumering assembly): 已加载“C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\mscorlib.resources\v4.0_4.0.0.0_zh - Hans_b77a5c561934e089\mscorlib.resources.dll”。模块已生成，不包含符号。
            //AsyncMethod2方法Await: 10
            //线程: 8正在执行..,时间: 2018 / 7 / 11 16:32:16
            //主线程完成！
            //线程: 8完成执行..,时间: 2018 / 7 / 11 16:32:18

            //分析： 1、await用来返回一个Task或者等待Task运行结束
            //       2、await如果修饰有返回值得async则await后面的代码不执行，修饰没有返回值得会用异步执行后面的代码
        }


        async Task AsyncMethod2()
        {
            Debug.WriteLine("AsyncMethod2方法开始:" + Thread.CurrentThread.ManagedThreadId);

            Action action = () =>
            {
                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,时间:" + DateTime.Now);

                Thread.Sleep(2000);

                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "完成执行..,时间:" + DateTime.Now);

            };

            Task task = Task.Run(action);

            Debug.WriteLine("AsyncMethod2方法Await:" + Thread.CurrentThread.ManagedThreadId);

            await task;

            Debug.WriteLine("AsyncMethod2异步方法结束:" + Thread.CurrentThread.ManagedThreadId);


        }

        async void AsyncMethod1()
        {

            Debug.WriteLine("AsyncMethod1方法开始:" + Thread.CurrentThread.ManagedThreadId);

            Debug.WriteLine("AsyncMethod1方法Await:" + Thread.CurrentThread.ManagedThreadId);

            await AsyncMethod2();

            Debug.WriteLine("AsyncMethod2异步方法结束:" + Thread.CurrentThread.ManagedThreadId);


        }



        [TestMethod]
        public void TestMethod3()
        {

            Debug.WriteLine("当前主线程ID:" + Thread.CurrentThread.ManagedThreadId);

            this.AsyncMethod3();

            Debug.WriteLine("主线程完成！");

            while (true)
            {







            }

            //结果：
            //当前主线程ID: 10
            //Async方法开始: 10
            //Async方法Await: 10
            //主线程完成！
            //线程: 8正在执行..,时间: 2018 / 7 / 11 16:18:32
            //线程: 8完成执行..,时间: 2018 / 7 / 11 16:18:34
            //异步方法结束: 8

            //分析： async 内部await前面的代码扔属于主线程，await后面的代码属于异步线程

        }

        async void AsyncMethod3()
        {
            Debug.WriteLine("Async方法开始:" + Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(1000);



            //[() => $name$;

            //  ToDo：说明




            Action







            Action action = () =>
            {
                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "正在执行..,时间:" + DateTime.Now);

                Thread.Sleep(2000);

                Debug.WriteLine("线程:" + Thread.CurrentThread.ManagedThreadId + "完成执行..,时间:" + DateTime.Now);

            };

            Task task = Task.Run(action);

            await task;

            //  Message：说明

            //  ToDelete ：说明







            //  TooDo ：这后面的


            Debug.WriteLine("异步方法1结束:" + Thread.CurrentThread.ManagedThreadId);

            Task task1 = Task.Run(action);

            await task1;


        }



        public void Method()
        {

            lock (this)
            {

            }
        }











    }
}
