#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/12 14:20:21  QQ:908293466
 * 文件名：Class8 
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
    public class ZSetRedisService : RedisServiceBase
    {
        /// <summary>
        /// 添加key/value，默认分数是从1.多*10的9次方以此递增的,自带自增效果
        /// </summary>
        public static bool AddItemToSortedSet(string key, string value)
        {
            return RedisServiceBase.Core.AddItemToSortedSet(key, value);
        }
        /// <summary>
        /// 添加key/value,并设置value的分数
        /// </summary>
        public static bool AddItemToSortedSet(string key, string value, double score)
        {
            return RedisServiceBase.Core.AddItemToSortedSet(key, value, score);
        }
        /// <summary>
        /// 为key添加values集合，values集合中每个value的分数设置为score
        /// </summary>
        public static bool AddRangeToSortedSet(string key, List<string> values, double score)
        {
            return RedisServiceBase.Core.AddRangeToSortedSet(key, values, score);
        }
        /// <summary>
        /// 为key添加values集合，values集合中每个value的分数设置为score
        /// </summary>
        public static bool AddRangeToSortedSet(string key, List<string> values, long score)
        {
            return RedisServiceBase.Core.AddRangeToSortedSet(key, values, score);
        }

        /// <summary> 获取key的所有集合 </summary>
        public static List<string> GetAllItemsFromSortedSet(string key)
        {
            return RedisServiceBase.Core.GetAllItemsFromSortedSet(key);
        }

        /// <summary> 获取key的所有集合，倒叙输出 </summary>
        public static List<string> GetAllItemsFromSortedSetDesc(string key)
        {
            return RedisServiceBase.Core.GetAllItemsFromSortedSetDesc(key);
        }

        /// <summary> 获取可以的说有集合，带分数 </summary>
        public static IDictionary<string, double> GetAllWithScoresFromSortedSet(string key)
        {
            return RedisServiceBase.Core.GetAllWithScoresFromSortedSet(key);
        }

        /// <summary> 获取key为value的下标值 </summary>
        public static long GetItemIndexInSortedSet(string key, string value)
        {
            return RedisServiceBase.Core.GetItemIndexInSortedSet(key, value);
        }

        /// <summary> 倒叙排列获取key为value的下标值 </summary>
        public static long GetItemIndexInSortedSetDesc(string key, string value)
        {
            return RedisServiceBase.Core.GetItemIndexInSortedSetDesc(key, value);
        }

        /// <summary> 获取key为value的分数 </summary>
        public static double GetItemScoreInSortedSet(string key, string value)
        {
            return RedisServiceBase.Core.GetItemScoreInSortedSet(key, value);
        }

        /// <summary> 获取key所有集合的数据总数 </summary>
        public static long GetSortedSetCount(string key)
        {
            return RedisServiceBase.Core.GetSortedSetCount(key);
        }

        /// <summary> key集合数据从分数为fromscore到分数为toscore的数据总数 </summary>
        public static long GetSortedSetCount(string key, double fromScore, double toScore)
        {
            return RedisServiceBase.Core.GetSortedSetCount(key, fromScore, toScore);
        }

        /// <summary> 获取key集合从高分到低分排序数据，分数从fromscore到分数为toscore的数据 </summary>
        public static List<string> GetRangeFromSortedSetByHighestScore(string key, double fromscore, double toscore)
        {
            return RedisServiceBase.Core.GetRangeFromSortedSetByHighestScore(key, fromscore, toscore);
        }

        /// <summary> 获取key集合从低分到高分排序数据，分数从fromscore到分数为toscore的数据 </summary>
        public static List<string> GetRangeFromSortedSetByLowestScore(string key, double fromscore, double toscore)
        {
            return RedisServiceBase.Core.GetRangeFromSortedSetByLowestScore(key, fromscore, toscore);
        }

        /// <summary> 获取key集合从高分到低分排序数据，分数从fromscore到分数为toscore的数据，带分数 </summary>
        public static IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string key, double fromscore, double toscore)
        {
            return RedisServiceBase.Core.GetRangeWithScoresFromSortedSetByHighestScore(key, fromscore, toscore);
        }

        /// <summary>  获取key集合从低分到高分排序数据，分数从fromscore到分数为toscore的数据，带分数 </summary>
        public static IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string key, double fromscore, double toscore)
        {
            return RedisServiceBase.Core.GetRangeWithScoresFromSortedSetByLowestScore(key, fromscore, toscore);
        }

        /// <summary>  获取key集合数据，下标从fromRank到分数为toRank的数据 </summary>
        public static List<string> GetRangeFromSortedSet(string key, int fromRank, int toRank)
        {
            return RedisServiceBase.Core.GetRangeFromSortedSet(key, fromRank, toRank);
        }

        /// <summary> 获取key集合倒叙排列数据，下标从fromRank到分数为toRank的数据 </summary>
        public static List<string> GetRangeFromSortedSetDesc(string key, int fromRank, int toRank)
        {
            return RedisServiceBase.Core.GetRangeFromSortedSetDesc(key, fromRank, toRank);
        }

        /// <summary> 获取key集合数据，下标从fromRank到分数为toRank的数据，带分数 </summary>
        public static IDictionary<string, double> GetRangeWithScoresFromSortedSet(string key, int fromRank, int toRank)
        {
            return RedisServiceBase.Core.GetRangeWithScoresFromSortedSet(key, fromRank, toRank);
        }

        /// <summary>  获取key集合倒叙排列数据，下标从fromRank到分数为toRank的数据，带分数 </summary>
        public static IDictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string key, int fromRank, int toRank)
        {
            return RedisServiceBase.Core.GetRangeWithScoresFromSortedSetDesc(key, fromRank, toRank);
        }

        /// <summary> 删除key为value的数据 </summary>
        public static bool RemoveItemFromSortedSet(string key, string value)
        {
            return RedisServiceBase.Core.RemoveItemFromSortedSet(key, value);
        }

        /// <summary> 删除下标从minRank到maxRank的key集合数据 </summary>
        public static long RemoveRangeFromSortedSet(string key, int minRank, int maxRank)
        {
            return RedisServiceBase.Core.RemoveRangeFromSortedSet(key, minRank, maxRank);
        }

        /// <summary> 删除分数从fromscore到toscore的key集合数据 </summary>
        public static long RemoveRangeFromSortedSetByScore(string key, double fromscore, double toscore)
        {
            return RedisServiceBase.Core.RemoveRangeFromSortedSetByScore(key, fromscore, toscore);
        }

        /// <summary> 删除key集合中分数最大的数据 </summary>
        public static string PopItemWithHighestScoreFromSortedSet(string key)
        {
            return RedisServiceBase.Core.PopItemWithHighestScoreFromSortedSet(key);
        }

        /// <summary> 删除key集合中分数最小的数据 </summary>
        public static string PopItemWithLowestScoreFromSortedSet(string key)
        {
            return RedisServiceBase.Core.PopItemWithLowestScoreFromSortedSet(key);
        }

        /// <summary> 判断key集合中是否存在value数据 </summary>
        public static bool SortedSetContainsItem(string key, string value)
        {
            return RedisServiceBase.Core.SortedSetContainsItem(key, value);
        }

        /// <summary> 为key集合值为value的数据，分数加scoreby，返回相加后的分数 </summary>
        public static double IncrementItemInSortedSet(string key, string value, double scoreBy)
        {
            return RedisServiceBase.Core.IncrementItemInSortedSet(key, value, scoreBy);
        }

        /// <summary> 获取keys多个集合的交集，并把交集添加的newkey集合中，返回交集数据的总数 </summary>
        public static long StoreIntersectFromSortedSets(string newkey, string[] keys)
        {
            return RedisServiceBase.Core.StoreIntersectFromSortedSets(newkey, keys);
        }

        /// <summary> 获取keys多个集合的并集，并把并集数据添加到newkey集合中，返回并集数据的总数 </summary>
        public static long StoreUnionFromSortedSets(string newkey, string[] keys)
        {
            return RedisServiceBase.Core.StoreUnionFromSortedSets(newkey, keys);
        }
    }
}
