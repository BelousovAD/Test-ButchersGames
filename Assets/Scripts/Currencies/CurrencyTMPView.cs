using System.Collections.Generic;
using System.Linq;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Currencies
{
    [RequireComponent(typeof(TMP_Text))]
    public class CurrencyTMPView : MonoBehaviour
    {
        [SerializeField] private string _format = "{0}";
        [SerializeField] private CurrencyType _type;

        private TMP_Text _field;
        private Currency _currency;

        [Inject]
        private void Initialize(IEnumerable<Currency> currencies) =>
            _currency = currencies.FirstOrDefault(currency => currency.Type == _type);

        private void Awake() =>
            _field = GetComponent<TMP_Text>();

        private void OnEnable()
        {
            _currency.Changed += UpdateView;
            UpdateView();
        }
        
        private void OnDisable() =>
            _currency.Changed -= UpdateView;

        private void UpdateView(int value = 0) =>
            _field.text = string.Format(_format, _currency.Value);
    }
}