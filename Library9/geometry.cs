using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder.MyLib;

public static partial class Geometry
{
    public static long SapporoDistance(List<int> a, List<int> b)
    {
        long result = 0;
        for (var i = 0; i < a.Count; i++)
        {
            result += Math.Abs(a[i] - b[i]);
        }
        return result;
    }
}
