#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/12 14:06:29  QQ:908293466
 * 文件名：Class1 
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

    /// <summary> 缓存注册管理服务 </summary>
    public class RedisRegister
    {
        public static RedisRegister Instance = new RedisRegister();

        PooledRedisClientManager prcm;

        public RedisRegister()
        {
            Func<string, string, string[]> function = (s, e) =>
                                   {
                                       return s.Split(e.ToArray());
                                   };

            // Todo ：创建链接池管理对象 
            string[] WriteServerConStr = function(RedisConfiger.WriteServerConStr, ",");

            string[] ReadServerConStr = function(RedisConfiger.ReadServerConStr, ",");

            prcm = new PooledRedisClientManager(ReadServerConStr, WriteServerConStr,
                             new RedisClientManagerConfig
                             {
                                 MaxWritePoolSize = RedisConfiger.MaxWritePoolSize,
                                 MaxReadPoolSize = RedisConfiger.MaxReadPoolSize,
                                 AutoStart = RedisConfiger.AutoStart,
                             });
        }

        /// <summary>  客户端缓存操作对象  </summary>
        public IRedisClient GetClient()
        {
            return prcm.GetClient();
        }
    }
}
