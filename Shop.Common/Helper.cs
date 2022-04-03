using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common
{
    public static class Helper
    {
        public static string GetKey()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
