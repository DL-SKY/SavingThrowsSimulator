using Modules.Core.Initializing;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules.Core.Custom.Initializing
{
    public class InitializingManager : MonoBehaviour, IInitializer
    {
        public async void StartInitializing(Action completedCallback, Action<int> failedCallback)
        {
            //TODO

            //return new Task();
            //public static async Task DelayOperationAsync() // асинхронный метод
            //{
            //    BeforeCall();
            //    Task task = Task.Delay(1000); //асинхронная операция
            //    AfterCall();
            //    await task;
            //    AfterAwait();
            //}


            var task = new Task(() => { });
            task.Start();
            await task;



            completedCallback?.Invoke();
        }
    }
}
