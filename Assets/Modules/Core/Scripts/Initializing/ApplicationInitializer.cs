using Modules.Core.Application.Settings;
using UnityEngine;

namespace Modules.Core.Initializing
{
    public class ApplicationInitializer : MonoBehaviour
    {
        [SerializeField] private ApplicationSettings _settings;

        private void OnValidate()
        {
            var initializer = GetComponent<IInitializer>();
            if (initializer == null)
                UnityEngine.Debug.LogError($"Not found component with interface IInitializer");
        }

        private void Awake()
        {
            var initializer = GetComponent<IInitializer>();
            initializer.StartInitializing(OnCompleted, OnFailed);
        }

        private void OnCompleted()
        {
            UnityEngine.Debug.LogError($"OnCompleted()");
            //TODO
        }

        private void OnFailed(int errorCode)
        {
            UnityEngine.Debug.LogError($"OnFailed({errorCode})");
            //TODO
        }
    }
}
