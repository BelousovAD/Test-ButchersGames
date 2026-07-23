using Reflex.Core;
using UnityEngine;

namespace Currencies
{
    internal class CurrenciesInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.RegisterValue(new Money(), new[] { typeof(Currency) });
            builder.RegisterValue(new RideMoney(), new[] { typeof(Currency) });
        }
    }
}