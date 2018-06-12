#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/12 14:17:52  QQ:908293466
 * 文件名：Class5 
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

namespace HeBianGu.Product.CommonService.RedisService
{

    /// <summary> 集合缓存服务 </summary>
    public class ListRedisSercie : RedisServiceBase
    {
        /// <summary> 从左侧向list中添加值 </summary>
        public static void LPush(string key, string value)
        {
            RedisServiceBase.Core.PushItemToList(key, value);
        }

        /// <summary> 从左侧向list中添加值，并设置过期时间 </summary>
        public static void LPush(string key, string value, DateTime dt)
        {
            RedisServiceBase.Core.PushItemToList(key, value);
            RedisServiceBase.Core.ExpireEntryAt(key, dt);
        }

        /// <summary> 从左侧向list中添加值，设置过期时间 </summary>
        public static void LPush(string key, string value, TimeSpan sp)
        {
            RedisServiceBase.Core.PushItemToList(key, value);
            RedisServiceBase.Core.ExpireEntryIn(key, sp);
        }

        /// <summary> 从左侧向list中添加值 </summary>
        public static void RPush(string key, string value)
        {
            RedisServiceBase.Core.PrependItemToList(key, value);
        }

        /// <summary> 从右侧向list中添加值，并设置过期时间 </summary>    
        public static void RPush(string key, string value, DateTime dt)
        {
            RedisServiceBase.Core.PrependItemToList(key, value);
            RedisServiceBase.Core.ExpireEntryAt(key, dt);
        }

        /// <summary> 从右侧向list中添加值，并设置过期时间 </summary>        
        public static void RPush(string key, string value, TimeSpan sp)
        {
            RedisServiceBase.Core.PrependItemToList(key, value);
            RedisServiceBase.Core.ExpireEntryIn(key, sp);
        }

        /// <summary> 添加key/value </summary>     
        public static void Add(string key, string value)
        {
            RedisServiceBase.Core.AddItemToList(key, value);
        }

        /// <summary> 添加key/value ,并设置过期时间 </summary>  
        public static void Add(string key, string value, DateTime dt)
        {
            RedisServiceBase.Core.AddItemToList(key, value);
            RedisServiceBase.Core.ExpireEntryAt(key, dt);
        }

        /// <summary> 添加key/value。并添加过期时间 </summary>  
        public static void Add(string key, string value, TimeSpan sp)
        {
            RedisServiceBase.Core.AddItemToList(key, value);
            RedisServiceBase.Core.ExpireEntryIn(key, sp);
        }

        /// <summary> 为key添加多个值 </summary>  
        public static void Add(string key, List<string> values)
        {
            RedisServiceBase.Core.AddRangeToList(key, values);
        }

        /// <summary> 为key添加多个值，并设置过期时间 </summary>  
        public static void Add(string key, List<string> values, DateTime dt)
        {
            RedisServiceBase.Core.AddRangeToList(key, values);
            RedisServiceBase.Core.ExpireEntryAt(key, dt);
        }

        /// <summary> 为key添加多个值，并设置过期时间 </summary>  
        public static void Add(string key, List<string> values, TimeSpan sp)
        {
            RedisServiceBase.Core.AddRangeToList(key, values);
            RedisServiceBase.Core.ExpireEntryIn(key, sp);
        }

        /// <summary> 获取list中key包含的数据数量 </summary>  
        public static long Count(string key)
        {
            return RedisServiceBase.Core.GetListCount(key);
        }

        /// <summary> 获取key包含的所有数据集合 </summary>  
        public static List<string> Get(string key)
        {
            return RedisServiceBase.Core.GetAllItemsFromList(key);
        }

        /// <summary> 获取key中下标为star到end的值集合 </summary>  
        public static List<string> Get(string key, int star, int end)
        {
            return RedisServiceBase.Core.GetRangeFromList(key, star, end);
        }

        /// <summary>  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp </summary>  
        public static string BlockingPopItemFromList(string key, TimeSpan? sp)
        {
            return RedisServiceBase.Core.BlockingDequeueItemFromList(key, sp);
        }

        /// <summary> 阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp </summary>  
        public static ItemRef BlockingPopItemFromLists(string[] keys, TimeSpan? sp)
        {
            return RedisServiceBase.Core.BlockingPopItemFromLists(keys, sp);
        }

        /// <summary> 阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp </summary>  
        public static string BlockingDequeueItemFromList(string key, TimeSpan? sp)
        {
            return RedisServiceBase.Core.BlockingDequeueItemFromList(key, sp);
        }

        /// <summary> 阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp </summary>  
        public static ItemRef BlockingDequeueItemFromLists(string[] keys, TimeSpan? sp)
        {
            return RedisServiceBase.Core.BlockingDequeueItemFromLists(keys, sp);
        }

        /// <summary> 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp </summary>  
        public static string BlockingRemoveStartFromList(string keys, TimeSpan? sp)
        {
            return RedisServiceBase.Core.BlockingRemoveStartFromList(keys, sp);
        }

        /// <summary> 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp </summary>  
        public static ItemRef BlockingRemoveStartFromLists(string[] keys, TimeSpan? sp)
        {
            return RedisServiceBase.Core.BlockingRemoveStartFromLists(keys, sp);
        }

        /// <summary> 阻塞命令：从list中一个fromkey的尾部移除一个值，添加到另外一个tokey的头部，并返回移除的值，阻塞时间为sp </summary>  
        public static string BlockingPopAndPushItemBetweenLists(string fromkey, string tokey, TimeSpan? sp)
        {
            return RedisServiceBase.Core.BlockingPopAndPushItemBetweenLists(fromkey, tokey, sp);
        }

        /// <summary> 从尾部移除数据，返回移除的数据 </summary>  
        public static string PopItemFromList(string key)
        {
            return RedisServiceBase.Core.PopItemFromList(key);
        }

        /// <summary> 移除list中，key/value,与参数相同的值，并返回移除的数量 </summary>  
        public static long RemoveItemFromList(string key, string value)
        {
            return RedisServiceBase.Core.RemoveItemFromList(key, value);
        }

        /// <summary> 从list的尾部移除一个数据，返回移除的数据 </summary>  
        public static string RemoveEndFromList(string key)
        {
            return RedisServiceBase.Core.RemoveEndFromList(key);
        }

        /// <summary> 从list的头部移除一个数据，返回移除的值 </summary>  
        public static string RemoveStartFromList(string key)
        {
            return RedisServiceBase.Core.RemoveStartFromList(key);
        }

        /// <summary> 从一个list的尾部移除一个数据，添加到另外一个list的头部，并返回移动的值 </summary>  
        public static string PopAndPushItemBetweenLists(string fromKey, string toKey)
        {
            return RedisServiceBase.Core.PopAndPushItemBetweenLists(fromKey, toKey);
        }
    }
}
