using System;
using System.Collections.Generic;
using System.Linq;
using Currencies;
using Pickable;
using Reflex.Attributes;
using UnityEngine;

namespace PlayerLogic
{
    public class Player : MonoBehaviour
    {
        private const int EarnAmount = 10;
        private const int SpendAmount = 10;
        
        [SerializeField] private Picker _picker;

        private Currency _currency;

        [Inject]
        private void Initialize(IEnumerable<Currency> currencies) =>
            _currency = currencies.FirstOrDefault(currency => currency.Type == CurrencyType.RideMoney);

        private void OnEnable() =>
            _picker.Picking += HandlePickUp;

        private void OnDisable() =>
            _picker.Picking -= HandlePickUp;

        private void HandlePickUp(IPickable pickable)
        {
            switch (pickable.Type)
            {
                case PickableType.Money:
                    _currency.Earn(EarnAmount);
                    break;
                case PickableType.Wine:
                    _currency.TrySpend(SpendAmount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}