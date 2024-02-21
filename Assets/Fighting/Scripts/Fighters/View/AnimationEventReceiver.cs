using System;
using UnityEngine;

namespace Fighting.View
{
    public class AnimationEventReceiver : MonoBehaviour
    {
        public event Action OnHit;
        public void SendHit() => OnHit?.Invoke();
    }
}
