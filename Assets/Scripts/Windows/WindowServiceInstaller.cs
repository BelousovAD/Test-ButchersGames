using Reflex.Core;
using UnityEngine;

namespace Windows
{
    internal class WindowServiceInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private MonoBehaviour _horizontalSpawner;

        public void InstallBindings(ContainerBuilder builder) =>
            builder.RegisterValue(new WindowService(_horizontalSpawner as IWindowSpawner),
                new[] { typeof(IWindowService) });

        private void OnValidate()
        {
            if (_horizontalSpawner is not null and not IWindowSpawner)
            {
                _horizontalSpawner = null;
                Debug.LogError($"{nameof(_horizontalSpawner)} must inherited {nameof(IWindowSpawner)}");
            }
        }
    }
}