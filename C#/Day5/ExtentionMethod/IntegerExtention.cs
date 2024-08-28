using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod
{
    public static class IntegerExtention
    {
        public static string Dublication(this int x)
        {
            return (x*2).ToString();
        }

        public static string Reverse(this string x)
        {
            char[] arr = x.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
