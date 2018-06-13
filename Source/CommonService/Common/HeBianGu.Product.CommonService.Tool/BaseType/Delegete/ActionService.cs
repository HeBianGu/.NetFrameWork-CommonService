using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Tool
{
    public static class ActionService
    {

        /// <summary> Debug下执行方法 </summary>
        public static void DoWhenDebug(this Action act)
        {
            #if (DEBUG)
            act();
            #else

            #endif
        }

        /// <summary> Debug下执行方法 </summary>
        public static void DoWhenDebug<T>(this Action<T> act ,T t)
        {
            #if (DEBUG)
            act(t);
            #else

            #endif
        }
    }
}
