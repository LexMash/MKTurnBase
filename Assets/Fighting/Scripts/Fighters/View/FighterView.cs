using Fighting.View;
using UnityEngine;

namespace Fighting
{
    public class FighterView : MonoBehaviour
    {
        [field:SerializeField] public Animator Animator { get; private set; }
        [field:SerializeField] public AnimationEventReceiver AnimationEventReceiver { get; private set; }

        private int idleHash = UnityEngine.Animator.StringToHash("Idle");

        private void Awake()
        {
            var state = Animator.GetCurrentAnimatorStateInfo(0);
            //Debug.Log("info lenght " + state.Length);
            Debug.Log("state name " + state.shortNameHash);
            Debug.Log("idle hash " + idleHash);

            //var v = Animator.runtimeAnimatorController.animationClips;

            //foreach(var c in v)
            //{
            //    Debug.Log(c.name);
            //}
        }
    }
}
