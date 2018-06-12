#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/12 14:18:22  QQ:908293466
 * 文件名：Class6 
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

namespace HeBianGu.Product.CommonService.RedisService
{

    /// <summary> Hash缓存服务 </summary>
    public class HashRedisService : RedisServiceBase
    {
        /// <summary> 向hashid集合中添加key/value </summary>       
        public static bool SetEntryInHash(string hashid, string key, string value)
        {
            return RedisServiceBase.Core.SetEntryInHash(hashid, key, value);
        }

        /// <summary> 如果hashid集合中存在key/value则不添加返回false，如果不存在在添加key/value,返回true </summary>
        public static bool SetEntryInHashIfNotExists(string hashid, string key, string value)
        {
            return RedisServiceBase.Core.SetEntryInHashIfNotExists(hashid, key, value);
        }

        /// <summary> 存储对象T t到hash集合中 </summary>
        public static void StoreAsHash<T>(T t)
        {
            RedisServiceBase.Core.StoreAsHash<T>(t);
        }

        /// <summary> 获取对象T中ID为id的数据。 </summary>
        public static T GetFromHash<T>(object id)
        {
            return RedisServiceBase.Core.GetFromHash<T>(id);
        }

        /// <summary> 获取所有hashid数据集的key/value数据集合 </summary>
        public static Dictionary<string, string> GetAllEntriesFromHash(string hashid)
        {
            return RedisServiceBase.Core.GetAllEntriesFromHash(hashid);
        }

        /// <summary> 获取hashid数据集中的数据总数 </summary>
        public static long GetHashCount(string hashid)
        {
            return RedisServiceBase.Core.GetHashCount(hashid);
        }

        /// <summary> 获取hashid数据集中所有key的集合 </summary>
        public static List<string> GetHashKeys(string hashid)
        {
            return RedisServiceBase.Core.GetHashKeys(hashid);
        }

        /// <summary> 获取hashid数据集中的所有value集合 </summary>
        public static List<string> GetHashValues(string hashid)
        {
            return RedisServiceBase.Core.GetHashValues(hashid);
        }

        /// <summary> 获取hashid数据集中，key的value数据 </summary>
        public static string GetValueFromHash(string hashid, string key)
        {
            return RedisServiceBase.Core.GetValueFromHash(hashid, key);
        }

        /// <summary> 获取hashid数据集中，多个keys的value集合 </summary>
        public static List<string> GetValuesFromHash(string hashid, string[] keys)
        {
            return RedisServiceBase.Core.GetValuesFromHash(hashid, keys);
        }

        /// <summary> 删除hashid数据集中的key数据 </summary>
        public static bool RemoveEntryFromHash(string hashid, string key)
        {
            return RedisServiceBase.Core.RemoveEntryFromHash(hashid, key);
        }

        /// <summary> 判断hashid数据集中是否存在key的数据 </summary>
        public static bool HashContainsEntry(string hashid, string key)
        {
            return RedisServiceBase.Core.HashContainsEntry(hashid, key);
        }

        /// <summary> 给hashid数据集key的value加countby，返回相加后的数据 </summary>
        public static double IncrementValueInHash(string hashid, string key, double countBy)
        {
            return RedisServiceBase.Core.IncrementValueInHash(hashid, key, countBy);
        }
    }
}
