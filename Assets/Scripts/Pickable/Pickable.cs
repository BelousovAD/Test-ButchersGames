using System;
using UnityEngine;

namespace Pickable
{
    public class Pickable : MonoBehaviour, IPickable
    {
        [SerializeField] private PickableType _type;
        
        public event Action<IPickable> Picked;

        public PickableType Type => _type;

        public void PickUp()
        {
            Picked?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
