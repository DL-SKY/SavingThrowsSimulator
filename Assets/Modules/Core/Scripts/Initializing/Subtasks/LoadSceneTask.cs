using UnityEngine.SceneManagement;

namespace Modules.Core.Initializing.Subtasks
{
    public class LoadSceneTask : Subtask
    {
        public override int Weight => _weight;
        private int _weight;

        private string _sceneName;

        public LoadSceneTask(string sceneName)
        {
            _sceneName = sceneName;
        }

        public override void Run()
        {
            SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
            Complete();
        }
    }
}
