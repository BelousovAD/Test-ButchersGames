using System;
using UnityEngine;

namespace Pickable
{
    public class Picker : MonoBehaviour
    {
        public event Action<IPickable> Picking;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out IPickable pickable))
            {
                Picking?.Invoke(pickable);
                pickable.PickUp();
            }
        }
    }
}
