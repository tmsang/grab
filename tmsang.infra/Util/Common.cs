using System;
using System.Collections.Generic;
using System.Text;

namespace tmsang.infra
{
    public static class Common
    {
        // =========================================================
        // Extension
        // =========================================================
        public static string ReplaceExtra(this string value, IEnumerable<Tuple<string, string>> toReplace)
        {
            var result = new StringBuilder(value);
            foreach (var item in toReplace)
            {
                result.Replace(item.Item1, item.Item2);
            }
            return result.ToString();
        }        
        
    }
}
