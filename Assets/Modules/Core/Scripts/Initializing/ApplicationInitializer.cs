using Modules.Core.Application.Settings;
using Modules.Core.Initializing.Subtasks;
using Modules.StarterKIT.Components.Services;
using Modules.StarterKIT.Services;
using Modules.Windows.Manager;
using Modules.Windows.Views.Preloaders;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Core.Initializing
{
    public class ApplicationInitializer : MonoBehaviour
    {
        private const string PRELOADER_PATH = "DefaultPreloaderView";

        /// <summary>
        /// int, int => current progress, max progress
        /// </summary>
        public event Action<int, int> OnProgressChange;

        [SerializeField] private ApplicationSettings _settings;

        private IInitializer _initializer;

        private void OnValidate()
        {
            var initializer = GetComponent<IInitializer>();
            if (initializer == null)
                UnityEngine.Debug.LogError($"Not found component with interface IInitializer");
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            _initializer = GetComponent<IInitializer>();
            _initializer.OnProgressChange += OnProgressChangeHandler;

            _initializer.AddBeforeTasks(GetBeforeTasks());
            _initializer.AddAfterTasks(GetAfterTasks());
            _initializer.Run(OnCompleted, OnFailed);
        }

        private void OnDestroy()
        {
            if (_initializer != null)
                _initializer.OnProgressChange -= OnProgressChange;
        }

        private void OnCompleted()
        {
            UnityEngine.Debug.LogError($"[ApplicationInitializer] OnCompleted()");
            //TODO

            //...
            

            Destroy(this.gameObject);
        }

        private void OnFailed(int errorCode)
        {
            UnityEngine.Debug.LogError($"[ApplicationInitializer] OnFailed({errorCode})");
            //TODO
        }

        private List<Subtask> GetBeforeTasks()
        {
            var tasks = new List<Subtask>();

            var windowsManager = ComponentLocator.Resolve<WindowsManager>();
            tasks.Add(new ShowPreloaderViewTask(windowsManager, PRELOADER_PATH));            

            return tasks;
        }

        private List<Subtask> GetAfterTasks()
        {
            var tasks = new List<Subtask>();

            var updater = ComponentLocator.Resolve<Updater>();
            //todo: temp ======
            for (int i = 0; i < 2; i++)
                tasks.Add(new PauseTask(updater, 0.1f, 1));
            //=================

            tasks.Add(new PauseTask(updater, 0.1f));

            //var windowsManager = ComponentLocator.Resolve<WindowsManager>();
            //tasks.Add(new CloseViewTask(windowsManager, typeof(PreloaderView)));

            return tasks;
        }

        private void OnProgressChangeHandler(int current, int max)
        {
            OnProgressChange?.Invoke(current, max);
        }
    }
}
