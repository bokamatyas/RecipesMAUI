using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Utility
{
    public static class TryUriValidity
    {
        public static bool TryUriConvert(string _url)
        {
            HttpClient httpClient = new();
            Uri result;
            return Uri.TryCreate(_url, UriKind.Absolute, out result);
        }
    }
}
