using System.Collections.Generic;

namespace BehaviorTree
{
    public abstract class CompositeNode : BehaviorNode
    {
        public List<IBehaviorNode> Children { get; private set; }

        public CompositeNode(List<IBehaviorNode> children)
        {
            Children = children;
        }
    }
}
