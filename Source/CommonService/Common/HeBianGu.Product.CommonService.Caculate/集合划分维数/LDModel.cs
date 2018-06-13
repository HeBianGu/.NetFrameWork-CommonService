#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 北京奥伯特石油科技有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2017/4/26 16:35:49
 * 文件名：LDModel
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
    /// <summary> 二维集合 </summary>
    public class LDD<T> : List<List<T>>
    {

        /// <summary> 索引器 </summary>
        public T this[int x, int y]
        {
            get { return this[x][y]; }
            set { this[x][y] = value; }
        }
    }

    /// <summary> 三维集合 </summary>
    public class LDDD<T> : List<LDD<T>>
    {

        /// <summary> 索引器 </summary>
        public T this[int x, int y, int z]
        {
            get { return this[x][y][z]; }
            set { this[x][y][z] = value; }
        }
    }
}
