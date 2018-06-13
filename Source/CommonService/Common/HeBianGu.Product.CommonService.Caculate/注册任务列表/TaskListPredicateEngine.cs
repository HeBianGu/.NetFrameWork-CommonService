#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 北京奥伯特石油科技有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2017/4/26 18:03:22
 * 文件名：TaskListPredicateEngine
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Caculate.注册任务列表
{

    /// <summary> 注册有返回值的任务，对任务执行退出或继续的监视 </summary>
    class TaskListPredicateEngine<T>
    {

        // HTodo  ：2017-04-26 06:00:50 匹配和任务关系列表 
        List<Tuple<Predicate<T>, Predicate<T>>> task = new List<Tuple<Predicate<T>, Predicate<T>>>();

        /// <summary> 注册匹配和任务 </summary> 
        public void Register(Predicate<T> match, Predicate<T> act)
        {
            Tuple<Predicate<T>, Predicate<T>> t = new Tuple<Predicate<T>, Predicate<T>>(match, act);
        }

        Action<T, Tuple<Predicate<T>, Predicate<T>>> OnFalse;

        /// <summary> 监视任务，如果返回false则退出 </summary>
        public void NotifyFalseBreak(T v)
        {
            foreach (var item in task)
            {
                if (item.Item1(v))
                {
                    // HTodo  ：2017-04-26 06:04:59执行注册任务，如果返回false则退出 
                    if (!item.Item2(v)) break;
                }
            }
        }

        /// <summary> 监视任务，如果返回false则过滤继续  </summary>
        public void NotifyFalseContine(T v)
        {
            foreach (var item in task)
            {
                if (item.Item1(v))
                {
                    // HTodo  ：2017-04-26 06:04:59执行注册任务，如果返回false则过滤继续 
                    if (!item.Item2(v)) continue;
                }
            }
        }

        /// <summary> 监视任务，如果返回false则抛出事件 </summary>
        public void NotifyFalseEvent(T v)
        {
            foreach (var item in task)
            {
                if (item.Item1(v))
                {
                    // HTodo  ：2017-04-26 06:04:59执行注册任务，如果返回false则抛出事件
                    if (!item.Item2(v))
                    {
                        if(this.OnFalse!=null)
                        {
                            this.OnFalse(v, item);
                        }
                    }
                }
            }
        }
    }
}
