using BehaviorTree.Actions;
using System.Collections;

namespace BehaviorTree
{
    public class ActionNode : BehaviorNode
    {
        private readonly IAction _action;

        public ActionNode(IAction action)
        {
            _action = action;
        }

        public override IEnumerator Execute()
        {
            yield return _action.Execute();
            SetState(_action.State);
        }
    }
}
