using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.ThreadTester
{
    public static class TestUtil
    {

        public static void Log(this string value)
        {
            Debug.WriteLine(value);
        }

        public static void TaskLog(this string value)
        {
            Debug.WriteLine("线程:" + Task.CurrentId + "日志：" + value);
        }

        public static void TaskLog(this string value,Task task)
        {
            Debug.WriteLine("线程:" + task.Id + "日志：" + value);
        }

        public static Action CommandLogWithAction(this string value)
        {
            Action action = () =>
              {
                  Debug.WriteLine("线程:" + Task.CurrentId + "日志：" + value);
              };


            return action;
        }
    }
}
