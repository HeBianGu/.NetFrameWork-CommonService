
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Tool
{

    /// <summary> 此类的说明 </summary>
    public class TMap<T> 
    {
        List<T> _cache = new List<T>();

        /// <summary> 此方法的说明 </summary>
        public void Set(T t)
        {



            if (_cache.Exists(l => l.Equals(t))) return;

            _cache.Add(t);
        }

        /// <summary> 此方法的说明 </summary>
        public T Get(Predicate<T> match)
        {
            T t = _cache.Find(match);

            if (t == null)
            {
                throw new Exception("没有检索到注册的项" + match.ToString());
            }

            return t;
        }
    }
}
