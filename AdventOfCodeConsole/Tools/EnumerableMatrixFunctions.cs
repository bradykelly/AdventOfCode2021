using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole.Tools
{
    public class EnumerableMatrixFunctions
    {
        public static IEnumerable<T> AdjacentElementsOrthogonal<T>(T[,] array, int row, int column)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int y = row - 1; y <= row + 1; y++)
            for (int x = column - 1; x <= column + 1; x++)
                if (x >= 0 && y >= 0 && x < columns && y < rows) 
                    if (!(y == row && x == column) 
                        && !(y == row - 1 && x == column - 1) 
                        && !(y == row + 1 && x == column + 1) 
                        && !(y == row - 1 && x == column + 1)
                        && !(y == row + 1 && x == column - 1))
                        yield return array[y, x];
        }

        public static IEnumerable<T> AdjacentElements<T>(T[,] array, int row, int column)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int y = row - 1; y <= row + 1; y++)
            for (int x = column - 1; x <= column + 1; x++)
                if (x >= 0 && y >= 0 && x < columns && y < rows && !(y == row && x == column))
                    yield return array[y, x];
        }
    }
}
