using System.Collections;
using UnityEngine;

namespace BehaviorTree.Actions
{
    public class WaitAction : IAction
    {
        public ExecutionState State { get; private set; }

        private readonly float _duration;

        public WaitAction(float duration)
        {
            _duration = duration;
        }

        public IEnumerator Execute()
        {
            yield return new WaitForSeconds(_duration);
            State = ExecutionState.Success;
        }
    }
}
