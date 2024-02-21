using System;

namespace Fighting
{
    public interface IFighterController
    {
        event Action OnDisabled;
        event Action OnEnabled;

        void Disable();
        void Enable();
    }
}