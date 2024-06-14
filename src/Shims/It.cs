using System;
using System.Collections.Generic;
using System.Text;

namespace Shims
{
    public static class It
    {
        public static T Any<T>()
        {
            return default;
        }
    }
}
