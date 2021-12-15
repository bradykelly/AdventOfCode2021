using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole.Tools
{
    public static class StringBuilderExtensions
    {
        public static int IndexOf(this StringBuilder target, string stringToFind)
        {
            // ReSharper disable once StringIndexOfIsCultureSpecific.1
            return target.ToString().IndexOf(stringToFind);
        }
    }
}
