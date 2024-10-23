namespace BehaviorTree.Decorators
{
    public abstract class DecoratorNode : BehaviorNode
    {
        public IBehaviorNode ChildNode { get; private set; }

        public DecoratorNode(IBehaviorNode childNode)
        {
            ChildNode = childNode;
        }
    }
}
