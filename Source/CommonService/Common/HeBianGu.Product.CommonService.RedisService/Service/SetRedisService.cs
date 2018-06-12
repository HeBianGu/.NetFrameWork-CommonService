#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/12 14:18:45  QQ:908293466
 * 文件名：Class7 
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

    /// <summary> 集缓存服务 </summary>
    public class SetRedisService : RedisServiceBase
    {
        /// <summary> key集合中添加value值 </summary>
        public static void Add(string key, string value)
        {
            RedisServiceBase.Core.AddItemToSet(key, value);
        }

        /// <summary> key集合中添加list集合 </summary>
        public static void Add(string key, List<string> list)
        {
            RedisServiceBase.Core.AddRangeToSet(key, list);
        }
        
        /// <summary> 随机获取key集合中的一个值 </summary>
        public static string GetRandomItemFromSet(string key)
        {
            return RedisServiceBase.Core.GetRandomItemFromSet(key);
        }

        /// <summary> 获取key集合值的数量 </summary>
        public static long GetCount(string key)
        {
            return RedisServiceBase.Core.GetSetCount(key);
        }

        /// <summary> 获取所有key集合的值 </summary>
        public static HashSet<string> GetAllItemsFromSet(string key)
        {
            return RedisServiceBase.Core.GetAllItemsFromSet(key);
        }
        
        /// <summary> 随机删除key集合中的一个值 </summary>
        public static string PopItemFromSet(string key)
        {
            return RedisServiceBase.Core.PopItemFromSet(key);
        }

        /// <summary> 删除key集合中的value </summary>
        public static void RemoveItemFromSet(string key, string value)
        {
            RedisServiceBase.Core.RemoveItemFromSet(key, value);
        }

        /// <summary> 从fromkey集合中移除值为value的值，并把value添加到tokey集合中 </summary>
        public static void MoveBetweenSets(string fromkey, string tokey, string value)
        {
            RedisServiceBase.Core.MoveBetweenSets(fromkey, tokey, value);
        }

        /// <summary> 返回keys多个集合中的并集，返还hashset </summary>
        public static HashSet<string> GetUnionFromSets(string[] keys)
        {
            return RedisServiceBase.Core.GetUnionFromSets(keys);
        }

        /// <summary> keys多个集合中的并集，放入newkey集合中 </summary>
        public static void StoreUnionFromSets(string newkey, string[] keys)
        {
            RedisServiceBase.Core.StoreUnionFromSets(newkey, keys);
        }
        /// <summary>
        /// 把fromkey集合中的数据与keys集合中的数据对比，fromkey集合中不存在keys集合中，则把这些不存在的数据放入newkey集合中
        /// </summary>
        public static void StoreDifferencesFromSet(string newkey, string fromkey, string[] keys)
        {
            RedisServiceBase.Core.StoreDifferencesFromSet(newkey, fromkey, keys);
        }
    }
}

