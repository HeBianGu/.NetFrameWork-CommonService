#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 北京奥伯特石油科技有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2017/4/26 17:54:16
 * 文件名：TaskMatchListEngine
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

    /// <summary> 注册匹配任务列表，监视调用匹配列表任务 </summary>
    class TaskListActionEngine<T>
    {

        // HTodo  ：2017-04-26 06:00:50 匹配和任务关系列表 
        List<Tuple<Predicate<T>, Action<T>>> task = new List<Tuple<Predicate<T>, Action<T>>>();

        /// <summary> 注册匹配和任务 </summary> 
        public void Register(Predicate<T> match, Action<T> act)
        {
            Tuple<Predicate<T>, Action<T>> t = new Tuple<Predicate<T>, Action<T>>(match, act);
        }

        /// <summary> 监视任务，如果匹配列表中有 则执行 </summary>
        public void Notify(T v)
        {
            foreach (var item in task)
            {
                if (item.Item1(v))
                {
                    item.Item2(v);
                }
            }
        }
    }
}
