using System.Collections;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BehaviorNode : IBehaviorNode
    {
        private bool _debug;
        public ExecutionState State { get; protected set; }
        public abstract IEnumerator Execute();

        protected void SetState(ExecutionState state)
        {
            State = state;
            Log($"Node completed: {State}");
        }

        public void SetDebugMode(bool debug)
        {
            _debug = debug;
        }

        protected void Log(string message)
        {
            if (_debug)
                Debug.Log(message.LogFormat(this, Color.green));
        }
    }
}
