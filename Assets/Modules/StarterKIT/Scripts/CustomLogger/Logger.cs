using Modules.StarterKIT.Services;
using System;
using UnityEngine;

namespace Modules.StarterKIT.CustomLogger
{
    public static class Logger
    {
        private static LoggerHolder _holder;


        public static void Log(Type sender, string log)
        {
            var defaultColor = Color.white;
            Log(defaultColor, sender, log);
        }

        public static void Log(Color color, Type sender, string log)
        {
            if (TryGetHolder(out var holder))
                holder.AddLog();

            Debug.Log(GetColorString(color, sender, log));
        }

        public static void LogWarning(Type sender, string log)
        {
            var defaultColor = Color.yellow;
            LogWarning(defaultColor, sender, log);
        }

        public static void LogWarning(Color color, Type sender, string log)
        {
            if (TryGetHolder(out var holder))
                holder.AddLog();

            Debug.LogWarning(GetColorString(color, sender, log));
        }

        public static void LogError(Type sender, string log)
        {
            var defaultColor = Color.red;
            LogError(defaultColor, sender, log);
        }

        public static void LogError(Color color, Type sender, string log)
        {
            if (TryGetHolder(out var holder))
                holder.AddLog();

            var defaultColor = Color.red;
            Debug.LogError(GetColorString(defaultColor, sender, log));
        }


        private static bool TryGetHolder(out LoggerHolder holder)
        {
            if (_holder == null)
                _holder = ComponentLocator.Resolve<LoggerHolder>();

            holder = _holder;

            return holder != null;
        }

        private static string GetColorString(Color color, Type sender, string log)
        {
            return string.Format("<color=#{0}>[{1}] {2}</color>",
                ColorUtility.ToHtmlStringRGB(color),
                sender.Name,
                log);
        }
    }
}
