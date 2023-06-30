using System.Runtime.InteropServices;

namespace Rsreu.Diploma.Extensions;

public static class ArrayExtensions
{
    public static T[] GetRow<T>(this T[,] array, int row)
    {
        if (!typeof(T).IsPrimitive)
        {
            throw new InvalidOperationException($"Extension method {nameof(GetRow)} is not supported for managed types.");
        }
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        var cols = array.GetUpperBound(1) + 1;
        var result = new T[cols];
        int size;

        if (typeof(T) == typeof(bool))
        {
            size = 1;
        }
        else if (typeof(T) == typeof(char))
        {
            size = 2;
        }
        else
        {
            size = Marshal.SizeOf<T>();
        }

        Buffer.BlockCopy(array, row * cols * size, result, 0, cols * size);

        return result;
    }
}
