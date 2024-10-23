using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class SequenceNode : CompositeNode
    {
        public SequenceNode(List<IBehaviorNode> children) : base(children) { }

        public override IEnumerator Execute()
        {
            foreach (IBehaviorNode child in Children)
            {
                yield return child.Execute();

                if (child.State == ExecutionState.Failure)
                {
                    SetState(ExecutionState.Failure);
                    yield break;
                }
            }

            SetState(ExecutionState.Success);
        }
    }
}
