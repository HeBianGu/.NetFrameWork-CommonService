#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/12 14:17:12  QQ:908293466
 * 文件名：Class4 
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

namespace HeBianGu.Product.CommonService.Redis
{

    /// <summary> 字符串缓存 </summary>
    public class StringRedisService : RedisServiceBase
    {
        /// <summary>  设置key的value  </summary>
        public static bool Set(string key, string value)
        {
            return RedisServiceBase.Core.Set<string>(key, value);
        }

        /// <summary> 设置key的value并设置过期时间 </summary>
        public static bool Set(string key, string value, DateTime dt)
        {
            return RedisServiceBase.Core.Set<string>(key, value, dt);
        }

        /// <summary> 设置key的value并设置过期时间 </summary>
        public static bool Set(string key, string value, TimeSpan sp)
        {
            return RedisServiceBase.Core.Set<string>(key, value, sp);
        }

        /// <summary> 设置多个key/value </summary>
        public static void Set(Dictionary<string, string> dic)
        {
            RedisServiceBase.Core.SetAll(dic);
        }
        
        /// <summary> 在原有key的value值之后追加value </summary>
        public static long Append(string key, string value)
        {
            return RedisServiceBase.Core.AppendToValue(key, value);
        }

        /// <summary> 获取key的value值 </summary>
        public static string Get(string key)
        {
            return RedisServiceBase.Core.GetValue(key);
        }

        /// <summary> 获取多个key的value值 </summary>
        public static List<string> Get(List<string> keys)
        {
            return RedisServiceBase.Core.GetValues(keys);
        }

        /// <summary> 获取多个key的value值 </summary>
        public static List<T> Get<T>(List<string> keys)
        {
            return RedisServiceBase.Core.GetValues<T>(keys);
        }

        /// <summary> 获取旧值赋上新值 </summary>
        public string GetAndSetValue(string key, string value)
        {
            return RedisServiceBase.Core.GetAndSetValue(key, value);
        }

        /// <summary> 获取值的长度 </summary>
        public static long GetCount(string key)
        {
            return RedisServiceBase.Core.GetStringCount(key);
        }

        /// <summary> 自增1，返回自增后的值 </summary>
        public static long Incr(string key)
        {
            return RedisServiceBase.Core.IncrementValue(key);
        }

        /// <summary> 自增count，返回自增后的值 </summary>
        public static double IncrBy(string key, double count)
        {
            return RedisServiceBase.Core.IncrementValueBy(key, count);
        }
        /// <summary> 自减1，返回自减后的值 </summary>
        public static long Decr(string key)
        {
            return RedisServiceBase.Core.DecrementValue(key);
        }

        /// <summary> 自减count ，返回自减后的值 </summary>
        public static long DecrBy(string key, int count)
        {
            return RedisServiceBase.Core.DecrementValueBy(key, count);
        }
    }
}

