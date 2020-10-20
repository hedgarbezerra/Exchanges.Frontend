using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Utils
{
    public static class Extensions
    {
        public static T MostCommon<T>(this IEnumerable<T> list)
        {
           return  list.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

    }
}
