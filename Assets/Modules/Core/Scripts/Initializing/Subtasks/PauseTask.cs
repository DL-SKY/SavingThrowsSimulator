using Modules.StarterKIT.Components.Services;

namespace Modules.Core.Initializing.Subtasks
{
    public class PauseTask : Subtask
    {
        public override int Weight => _weight;
        private int _weight;

        private Updater _updater;
        private float _timer;

        public PauseTask(Updater updater, float duration, int weight = 0)
        {
            _updater = updater;
            _timer = duration;
            _weight = weight;
        }

        public override void Run()
        {
            _updater.OnUpdate += OnUpdateHandler;
        }

        private void OnUpdateHandler(float delta)
        {
            _timer -= delta;
            if (_timer <= 0.0f)
            {
                _updater.OnUpdate -= OnUpdateHandler;
                Complete();
            }
        }
    }
}
