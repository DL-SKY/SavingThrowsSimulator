namespace Modules.StarterKIT.Extensions
{
    public static class ArrayExtension
    {
        public static T[,] Convert<T>(this T[] array, int width, int height)
        {
            var result = new T[width, height];
            for (int i = 0; i < array.Length; i++)
            {
                var x = i % width;
                var y = (i - x) / width;
                result[x, y] = array[i];
            }

            return result;
        }

        public static T[] Convert<T>(this T[,] array, int width, int height)
        {
            var result = new T[width * height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    result[y * width + x] = array[x, y];

            return result;
        }
    }
}
