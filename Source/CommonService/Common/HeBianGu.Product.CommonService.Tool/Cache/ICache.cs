#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/13 9:49:23  QQ:908293466
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Tool
{
    public interface ICache : IDisposable
    {

        void Remove(string key);
        object Get(string key);
        T Get<T>(string key);
        T Get<T>(string key, T defaultValue);
        bool HasKey(string key);
        void Store(string key, object data);
        //void Store(string key, object data, DateTime expiryTime);
        void Flush();
        object this[string key] { get; }
    }
}
