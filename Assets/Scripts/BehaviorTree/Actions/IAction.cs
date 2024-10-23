using System.Collections;

namespace BehaviorTree.Actions
{
    public interface IAction
    {
        public ExecutionState State { get; }
        public IEnumerator Execute();
    }
}
