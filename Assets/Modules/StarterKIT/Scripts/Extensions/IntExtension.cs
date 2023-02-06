namespace Modules.StarterKIT.Extensions
{
    public static class IntExtension
    {
        public static string ToString1000(this int integer)
        {
            if (integer < 1000)
                return integer.ToString();

            var liters = 1;
            for (int i = 1; integer / (i * 1000) >= 1000; i++)
            {
                Modules.StarterKIT.CustomLogger.Logger.LogError(typeof(int), $"i : {i} :: {integer / (i * 1000)}");
                liters = i;
            }

            var kkk = "";
            for (int i = 0; i < liters; i++)
                kkk += "K";
            Modules.StarterKIT.CustomLogger.Logger.LogError(typeof(int), $"{integer} , {liters} , {kkk}");
            return $"{ integer / (liters * 1000)}{kkk}";
        }
    }
}
