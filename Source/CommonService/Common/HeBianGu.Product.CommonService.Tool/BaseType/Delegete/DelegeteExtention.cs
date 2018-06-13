#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/13 10:12:44  QQ:908293466
 * 文件名：Class1 
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

namespace HeBianGu.Product.CommonService.Tool.BaseType
{ 
    public static class DelegeteExtention
    {

        public static bool IsRegistedMethod(this Delegate handle, string methodName)
        {
            return handle == null ? false : handle.GetInvocationList().ToList().Exists(l => l.Method.Name == methodName);
        }

    }
}
