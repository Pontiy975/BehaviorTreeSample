//using System.Collections;

//namespace BehaviorTree.Decorators
//{
//    public class SuccessRepeaterNode : DecoratorNode
//    {
//        public SuccessRepeaterNode(IBehaviorNode childNode) : base(childNode) { }

//        public override IEnumerator Execute()
//        {
//            while (true)
//            {
//                yield return ChildNode.Execute();

//                if (ChildNode.State == ExecutionState.Failure)
//                    break;
//            }
//        }
//    }
//}
