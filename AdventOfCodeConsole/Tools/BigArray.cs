namespace AdventOfCodeConsole.Tools;

public class BigArray
{
    public static void Resize<T>(ref T[] array, long newSize)
    {
        if (newSize < 0)
            throw new ArgumentOutOfRangeException(nameof(newSize));

        T[] larray = array;
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (larray == null)
        {
            array = new T[newSize];
            return;
        }

        if (larray.Length != newSize)
        {
            T[] newArray = new T[newSize];
            Array.Copy(larray, 0, newArray, 0, larray.LongLength > newSize ? newSize : larray.LongLength);
            array = newArray;
        }
    }
}