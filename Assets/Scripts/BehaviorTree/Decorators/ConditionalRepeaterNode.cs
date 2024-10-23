//using System;
//using System.Collections;

//namespace BehaviorTree.Decorators
//{
//    public class ConditionalRepeaterNode : DecoratorNode
//    {
//        private readonly Func<bool> _condition;

//        public ConditionalRepeaterNode(IBehaviorNode childNode, Func<bool> condition) : base(childNode)
//        {
//            _condition = condition;
//        }

//        public override IEnumerator Execute()
//        {
//            while (_condition())
//            {
//                yield return ChildNode.Execute();
//            }
//        }
//    }
//}
