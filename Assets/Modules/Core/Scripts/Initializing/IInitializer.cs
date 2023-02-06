using System;

namespace Modules.Core.Initializing
{
    public interface IInitializer
    {
        void StartInitializing(Action completedCallback, Action<int> failedCallback);
    }
}
