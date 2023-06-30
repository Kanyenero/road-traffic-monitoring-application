namespace Rsreu.Diploma.Extensions;

public static class EnumerableExtensions
{
    public static T[,] ToArray<T>(this IEnumerable<T> source, int dim1, int dim2)
    {
        var array = source.ToArray();
        var result = new T[dim1, dim2];

        for (var i = 0; i < array.Length; i++)
        {
            result[i / dim2, i % dim2] = array[i];
        }

        return result;
    }
}
