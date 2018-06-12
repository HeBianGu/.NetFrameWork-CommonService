#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/12 14:09:20  QQ:908293466
 * 文件名：Class2 
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
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.RedisService
{

    /// <summary> 缓存配置信息 </summary>
    public sealed class RedisConfiger : ConfigurationSection
    {

        public static string WriteServerConStr
        {
            get
            {
                return string.Format("{0},{1}", "127.0.0.1:6379", "127.0.0.1:6380");
            }
        }
        public static string ReadServerConStr
        {
            get
            {
                return string.Format("{0}", "127.0.0.1:6379");
            }
        }
        public static int MaxWritePoolSize
        {
            get
            {
                return 50;
            }
        }
        public static int MaxReadPoolSize
        {
            get
            {
                return 200;
            }
        }
        public static bool AutoStart
        {
            get
            {
                return true;
            }
        }

    }
}
