using Modules.Core.Initializing;
using Modules.Core.Initializing.Subtasks;
using Modules.DataBase;
using Modules.StarterKIT.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Core.Custom.Initializing
{
    public class InitializeTasker : MonoBehaviour, IInitializer
    {
        public event Action<int, int> OnProgressChange;

        private List<Subtask> _before = new List<Subtask>();
        private List<Subtask> _tasks = new List<Subtask>();
        private List<Subtask> _after = new List<Subtask>();
        private int _currentTaskIndex;

        private Action _completedCallback;
        private Action<int> _failedCallback;

        private int _currentProgress;
        private int _maxProgress;
        

        private void OnDestroy()
        {
            if (_tasks.Count > _currentTaskIndex)
            {
                var task = _tasks[_currentTaskIndex];
                task.OnComplete -= OnCompleteHandler;
                task.OnError -= OnErrorHandler;
            }
        }


        public void Run(Action completedCallback, Action<int> failedCallback)
        {
            _completedCallback = completedCallback;
            _failedCallback = failedCallback;

            _tasks = CreateTasks();
            _currentTaskIndex = 0;
            _currentProgress = 0;
            _maxProgress = 0;
            foreach (var task in _tasks)
                _maxProgress += task.Weight;

            TryStartTask();
        }

        public void AddBeforeTasks(List<Subtask> tasks)
        {
            _before.AddRange(tasks);
        }

        public void AddAfterTasks(List<Subtask> tasks)
        {
            _after.AddRange(tasks);
        }


        private List<Subtask> CreateTasks()
        {
            var tasks = new List<Subtask>();

            tasks.AddRange(_before);

            //TODO!!!!!!!!
            //tasks.Add(new LoadDataBaseTask(_dataBaseManager));
            tasks.Add(new LoadDataBaseTask(ComponentLocator.Resolve<DataBaseManager>()));
            //...
            tasks.Add(new LoadSceneTask("Dungeon"));
            //...

            tasks.AddRange(_after);

            return tasks;
        }

        private void TryStartTask()
        {
            if (_tasks.Count > _currentTaskIndex)
            {
                var task = _tasks[_currentTaskIndex];
                task.OnComplete += OnCompleteHandler;
                task.OnError += OnErrorHandler;

                task.Run();
            }
            else
            {
                _completedCallback?.Invoke();
            }
        }

        private void OnCompleteHandler(Subtask task)
        {
            task.OnComplete -= OnCompleteHandler;
            task.OnError -= OnErrorHandler;

            _currentTaskIndex++;
            _currentProgress += task.Weight;
            OnProgressChange?.Invoke(_currentProgress, _maxProgress);

            TryStartTask();
        }

        private void OnErrorHandler(Subtask task, int errorCode)
        {
            task.OnComplete -= OnCompleteHandler;
            task.OnError -= OnErrorHandler;

            _failedCallback?.Invoke(errorCode);
        }        
    }
}
