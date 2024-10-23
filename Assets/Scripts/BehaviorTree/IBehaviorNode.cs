using System.Collections;

namespace BehaviorTree
{
    public interface IBehaviorNode
    {
        public ExecutionState State { get; }
        public IEnumerator Execute();
        public void SetDebugMode(bool debug);
    }
}