using System.Text;

namespace AdventOfCodeConsole.Tools
{
    public static class StringBuilderExtensions
    {
        public static int IndexOf(this StringBuilder target, string stringToFind)
        {
            return target.ToString().IndexOf(stringToFind, StringComparison.InvariantCulture);
        }
    }
}
