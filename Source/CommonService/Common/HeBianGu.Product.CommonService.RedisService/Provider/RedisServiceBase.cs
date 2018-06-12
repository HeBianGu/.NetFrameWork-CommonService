#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/12 14:16:04  QQ:908293466
 * 文件名：Class3 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Redis
{

    /// <summary>
    /// RedisServiceBase类，是redis操作的基类，继承自IDisposable接口，主要用于释放内存
    /// </summary>
    public abstract class RedisServiceBase : IDisposable
    {
        public static IRedisClient Core { get; private set; }

        private bool _disposed = false;

        static RedisServiceBase()
        {
            Core = RedisRegister.Instance.GetClient();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Core.Dispose();

                    Core = null;
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary> 保存数据DB文件到硬盘 </summary>
        public void Save()
        {
            Core.Save();
        }
        /// <summary> 异步保存数据DB文件到硬盘 </summary>
        public void SaveAsync()
        {
            Core.SaveAsync();
        }
    }
}
