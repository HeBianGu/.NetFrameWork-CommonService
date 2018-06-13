#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 北京奥伯特石油科技有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2017/4/27 9:20:17
 * 文件名：TaskLastModelEngine
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

namespace HeBianGu.Product.CommonService.Caculate
{
    class TaskLastModelEngine<T>
    {

        List<ITaskBehaviorEntity<T>> _taskList = new List<ITaskBehaviorEntity<T>>();

        Queue<T> _queues = new Queue<T>(5);

        Stack<T> _stack = new Stack<T>(5);


        /// <summary> 注册任务 </summary>
        public void Register(ITaskBehaviorEntity<T> task)
        {
            _taskList.Add(task);        
        }

        /// <summary> 执行监控 调用任务 </summary>
        public void Notify(T t)
        {
            foreach (var item in _taskList)
            {
                // HTodo  ：先调用先决条件检查 通过则执行后续任务 2017-04-27 09:39:44 
                if (item.BeforeCheck(t))
                {
                    try
                    {
                        item.BeforeUpdate(t);

                        item.Update(t);

                        item.AfterUpdate(t);

                    }
                    catch (Exception e)
                    {
                        item.OnException(e);
                    }
                    finally
                    {
                        if(item.AfterCheck(t))
                        {
                            // HTodo  ：如果后决条件检查成功则添加到堆栈 2017-04-27 09:47:38 
                            _stack.Push(t);
                        }
                        else
                        {
                            // HTodo  ：如果检查失败了则添加到队列 2017-04-27 09:50:04
                            _queues.Enqueue(t);
                        }
                    }
                }
            }
        }
    }


    /// <summary> 任务实体 </summary>
    interface ITaskBehaviorEntity<T>
    {
        /// <summary> 先决条件检查 </summary>
        bool BeforeCheck(T t);

        /// <summary> 执行任务之前的操作 </summary>
        void BeforeUpdate(T t);

        /// <summary> 执行任务 </summary>
        void Update(T t);

        /// <summary> 执行任务之后的操作 </summary>
        void AfterUpdate(T t);

        /// <summary> 后决条件检查 </summary>
        bool AfterCheck(T t);

        void OnException(Exception e);
    }

    /// <summary> 任务实体 </summary>
    class TaskDelegateEntity<T> : ITaskBehaviorEntity<T>
    {
        Predicate<T> _beforeCheckHandle;

        Action<T> _beforeHandle;

        Action<T> _updateHandle;

        Action<T> _afterHandle;

        Predicate<T> _afterCheckHandle;

        /// <summary> 先决条件检查 </summary>
        public bool BeforeCheck(T t)
        {
            if (_beforeCheckHandle != null)
            {
                return _beforeCheckHandle(t);
            }

            return true;
        }

        /// <summary> 执行任务之前的操作 </summary>
        public void BeforeUpdate(T t)
        {
            if (_beforeHandle != null)
            {
                _beforeHandle(t);
            }
        }

        /// <summary> 执行任务 </summary>
        public void Update(T t)
        {
            if (_updateHandle != null)
            {
                _updateHandle(t);
            }
        }

        /// <summary> 执行任务之后的操作 </summary>
        public void AfterUpdate(T t)
        {
            if (_afterHandle != null)
            {
                _afterHandle(t);
            }

        }

        /// <summary> 后决条件检查 </summary>
        public bool AfterCheck(T t)
        {
            if (_afterCheckHandle != null)
            {
                return _afterCheckHandle(t);
            }

            return true;
        }


        /// <summary> 异常情况 </summary>
        public void OnException(Exception e)
        {
            throw e;
        }
    }


}
