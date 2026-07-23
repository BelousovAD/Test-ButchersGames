using System;
using UnityEngine;

namespace Currencies
{
    public class Currency
    {
        private const int Min = 0;

        private int _value;

        public Currency(CurrencyType type, int max = int.MaxValue)
        {
            Type = type;
            Max = max;
        }

        public event Action<int> Changed;

        public CurrencyType Type { get; }
        
        public int Max { get; }

        public int Value
        {
            get => _value;

            private set
            {
                if (value != _value)
                {
                    _value = Mathf.Clamp(value, Min, Max);
                    Changed?.Invoke(_value);
                }
            }
        }

        public void Earn(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Can not be negative");
            }

            Value += amount;
        }

        public bool TrySpend(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Can not be negative");
            }

            if (Value < amount)
            {
                return false;
            }
            
            Value -= amount;
            
            return true;
        }
    }
}