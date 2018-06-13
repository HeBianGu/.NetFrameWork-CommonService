using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Tool
{

    /// <summary> 线程安全请使用 ConcurrentDictionary<TKey, TValue> 类（.Net 4新增） </summary>
    public static partial class DictionaryExtention
    {
        /// <summary> 尝试将键和值添加到字典中：如果不存在，才添加；存在，不添加也不抛导常 </summary>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key) == false) dict.Add(key, value);
            return dict;
        }

        /// <summary 将键和值添加或替换到字典中：如果不存在，则添加；存在，则替换 </summary>
        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
            return dict;
        }

        /// <summary>  获取与指定的键相关联的值，如果没有则返回输入的默认值 </summary>
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
        {
            return dict.ContainsKey(key) ? dict[key] : defaultValue;
        }

        /// <summary> 向字典中批量添加键值对 </summary>
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
        {
            foreach (var item in values)
            {
                if (dict.ContainsKey(item.Key) == false || replaceExisted)
                    dict[item.Key] = item.Value;
            }
            return dict;
        }
    }

    public static partial class DictionaryExtention
    {
        /// <summary> 遍历字典对值执行Func操作 </summary>
        public static Dictionary<TKey, TValue> ForeachEx<TKey, TValue>(this Dictionary<TKey, TValue> dic, Func<TValue, TValue> func)
        {
            Dictionary<TKey, TValue> dicNew = new Dictionary<TKey, TValue>();

            foreach (TKey d in dic.Keys)
            {
                TValue v;

                if (dic.TryGetValue(d, out v))
                {
                    dicNew.Add(d, func(v));
                }
            }

            return dicNew;
        }

        /// <summary> 对二维表的指定列进行fuc操作 </summary>
        public static List<string[]> ForeachEx(this List<string[]> list, Func<double, double> func, int col)
        {
            List<string[]> listNew = new List<string[]>();

            list.ForEach(
                l =>
                {

                    string[] strs = l.Clone() as string[];

                    strs[col] = func(Double.Parse(strs[col])).ToString();

                    listNew.Add(strs);
                }
                );

            return listNew;
        }

        public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> dic, Predicate<KeyValuePair<TKey, TValue>> macth)
        {
            foreach (KeyValuePair<TKey, TValue> v in dic)
            {
                if (macth(v))
                {
                    dic.Remove(v.Key);
                }
            }
        }
    }
}
