#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 北京奥伯特石油科技有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2017/4/26 16:35:10
 * 文件名：ListSplitHelper
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
    public static class ListSplitHelper
    {
        /// <summary> 将满足指定行信息的行进行划分 </summary>
        public static LDDD<T> SplitD2Array<T>(this List<List<T>> arr, Predicate<List<T>> match)
        {
            LDDD<T> ddd = new LDDD<T>();

            LDD<T> dd = new LDD<T>();

            for (int i = 0; i < arr.Count; i++)
            {
                if (match(arr[i]))
                {
                    dd = new LDD<T>();

                    ddd.Add(dd);
                }

                dd.Add(arr[i]);
            }

            return ddd;
        }


        /// <summary> 将指定行索引值等于指定参数的行进行划分 </summary>
        public static LDDD<T> SplitD2Array<T>(this List<List<T>> arr, int index, T matchValue)
        {
            Predicate<List<T>> match = l =>
            {
                return l[index].Equals(matchValue);
            };

            return arr.SplitD2Array<T>(match);
        }

        /// <summary> 一维转换成二维数据 P1=行中列的个数 </summary>
        public static LDD<T> SplitDValue<T>(this List<T> list, int lineCount)
        {
            int count = list.Count / lineCount;

            LDD<T> dd = new LDD<T>();

            for (int j = 0; j < count; j++)
            {
                List<T> t = new List<T>();

                for (int i = 0; i < lineCount; i++)
                {
                    int index = (j * lineCount + i);

                    t.Add(list[index]);
                }

                dd.Add(t);
            }

            return dd;
        }
    }
}
