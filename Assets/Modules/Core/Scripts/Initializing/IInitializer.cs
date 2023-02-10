using Modules.Core.Initializing.Subtasks;
using System;
using System.Collections.Generic;

namespace Modules.Core.Initializing
{
    public interface IInitializer
    {
        event Action<int, int> OnProgressChange;

        void Run(Action completedCallback, Action<int> failedCallback);
        void AddBeforeTasks(List<Subtask> tasks);
        void AddAfterTasks(List<Subtask> tasks);
    }
}
