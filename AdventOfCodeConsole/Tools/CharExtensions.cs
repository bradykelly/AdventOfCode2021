using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole.Tools;

public static class CharExtensions
{
    public static bool IsDigit(this char target)
    {
        return target is >= '0' and <= '9';
    }
}
