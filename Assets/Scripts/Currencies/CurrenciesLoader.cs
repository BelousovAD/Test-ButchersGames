using System.Collections.Generic;
using System.Linq;
using Bootstrap;
using Reflex.Attributes;
using UnityEngine;

namespace Currencies
{
    internal class CurrenciesLoader : MonoBehaviour, ILoadable
    {
        private IEnumerable<SaveableCurrency> _currencies;

        [Inject]
        private void Initialize(IEnumerable<Currency> currencies)
        {
            _currencies = currencies
                .Select(currency => currency as SaveableCurrency)
                .Where(currency => currency is not null);
        }
        
        public void Load()
        {
            foreach (SaveableCurrency currency in _currencies)
            {
                currency.Load();
            }
        }
    }
}