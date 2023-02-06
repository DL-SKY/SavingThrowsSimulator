using UnityEngine;

namespace Modules.StarterKIT.Components.Services
{
    public class DontDestroyComponent : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
