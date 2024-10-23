using BehaviorTree.Decorators;
using System.Collections;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BehaviorTree
    {
        protected bool debug;

        protected Blackboard blackboard;
        protected IBehaviorNode rootNode;

        public IEnumerator Execute()
        {
            Log($"BT is running");
            while (RunCondition())
            {
                yield return rootNode.Execute();
            }
            Log($"BT is stopped");
        }

        protected abstract bool RunCondition();

        protected void Log(string message)
        {
            if (debug)
                Debug.Log($"{message}".LogFormat(this, Color.green));
        }

        public void SetDebugMode(IBehaviorNode node, bool debug)
        {
            this.debug = debug;
            node.SetDebugMode(debug);

            if (node is CompositeNode compositeNode)
            {
                foreach (var child in compositeNode.Children)
                {
                    SetDebugMode(child, debug);
                }
            }

            if (node is DecoratorNode decoratorNode)
                SetDebugMode(decoratorNode.ChildNode, debug);
        }
    }

    public enum ExecutionState
    {
        Success,
        Failure
    }
}
