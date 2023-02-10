using System;

namespace Modules.Core.Initializing.Subtasks
{
    public abstract class Subtask
    {
        public event Action<Subtask> OnComplete;
        public event Action<Subtask, int> OnError;

        public abstract int Weight { get; }

        public abstract void Run();

        protected void Complete()
        {
            OnComplete?.Invoke(this);
        }

        protected void Fail(int errorCode)
        {
            OnError?.Invoke(this, errorCode);
        }
    }
}
