using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class SelectorNode : CompositeNode
    {
        public SelectorNode(List<IBehaviorNode> children) : base(children) { }

        public override IEnumerator Execute()
        {
            foreach (IBehaviorNode child in Children)
            {
                yield return child.Execute();

                if (child.State == ExecutionState.Success)
                {
                    SetState(ExecutionState.Success);
                    yield break;
                }
            }

            SetState(ExecutionState.Failure);
        }
    }
}
