using System;
using System.Collections;

namespace BehaviorTree
{
    public class ConditionNode : BehaviorNode
    {
        private readonly Func<bool> _condition;

        public ConditionNode(Func<bool> condition)
        {
            _condition = condition;
        }

        public override IEnumerator Execute()
        {
            SetState(_condition() ? ExecutionState.Success : ExecutionState.Failure);
            yield break;
        }
    }
}
