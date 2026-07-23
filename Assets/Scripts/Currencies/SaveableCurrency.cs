using System;
using UnityEngine;

namespace Currencies
{
    public class SaveableCurrency : Currency, IDisposable
    {
        public SaveableCurrency(CurrencyType type)
            : base(type) =>
            Changed += Save;

        public void Dispose() =>
            Changed -= Save;
        
        public bool Load()
        {
            int value = PlayerPrefs.GetInt(Type + nameof(Value), -1);

            if (value < 0)
            {
                return false;
            }

            Earn(value);
            
            return true;
        }

        private void Save(int value)
        {
            PlayerPrefs.SetInt(Type + nameof(Value), value);
            PlayerPrefs.Save();
        }
    }
}