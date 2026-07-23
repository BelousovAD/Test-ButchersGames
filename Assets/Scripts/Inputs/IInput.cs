using System;

namespace Inputs
{
    public interface IInput
    {
        public event Action<float> MoveRequested;
    }
}