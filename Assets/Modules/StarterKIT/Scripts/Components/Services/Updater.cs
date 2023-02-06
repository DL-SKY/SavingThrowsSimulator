using System;
using UnityEngine;

namespace Modules.StarterKIT.Components.Services
{
    public class Updater : MonoBehaviour
    {
        public event Action<float> OnUpdate;
        public event Action<float> OnLateUpdate;


        private void Update()
        {
            OnUpdate?.Invoke(Time.deltaTime);
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke(Time.deltaTime);
        }


        #region Obsolete
        //private HashSet<IUpdateHandler> _handlers = new HashSet<IUpdateHandler>();
        //private HashSet<IUpdateHandler> _removers = new HashSet<IUpdateHandler>();


        //private void Update()
        //{
        //    _handlers.ExceptWith(_removers);
        //    _removers.Clear();

        //    foreach (var handler in _handlers)
        //        handler.Update(Time.time);
        //}


        //public void AddHandler(IUpdateHandler handler)
        //{
        //    if (!_handlers.Contains(handler))
        //        _handlers.Add(handler);
        //}

        //public void RemoveHandler(IUpdateHandler handler)
        //{
        //    if (!_removers.Contains(handler))
        //        _removers.Add(handler);
        //}
        #endregion
    }
}
