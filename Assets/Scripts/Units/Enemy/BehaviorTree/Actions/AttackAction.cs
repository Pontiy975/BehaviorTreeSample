using BehaviorTree;
using BehaviorTree.Actions;
using System.Collections;

namespace BehaviorTreeSample.Enemy.BehaviorTree.Actions
{
    public class AttackAction : IAction
    {
        public ExecutionState State { get; private set; }

        public IEnumerator Execute()
        {
            yield return null;
        }
    }
}
