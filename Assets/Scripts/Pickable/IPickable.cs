using System;

namespace Pickable
{
    public interface IPickable
    {
        public event Action<IPickable> Picked;
        
        public PickableType Type { get; }

        public void PickUp();
    }
}
