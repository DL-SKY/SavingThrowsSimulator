using Modules.Windows.Manager;
using System;

namespace Modules.Core.Initializing.Subtasks
{
    public class CloseViewTask : Subtask
    {
        public override int Weight => 0;

        private WindowsManager _windowsManager;
        private Type _windows;

        public CloseViewTask(WindowsManager windowsManager, Type windows)
        {
            _windowsManager = windowsManager;
            _windows = windows;
        }

        public override void Run()
        {
            if (_windowsManager == null)
            {
                Fail(1);
                return;
            }

            _windowsManager.CloseWindow(_windows);

            Complete();
        }
    }
}
