using BehaviorTree;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using System;
using BehaviorTree.Actions;
using BehaviorTreeSample.Enemy.Data;

namespace BehaviorTreeSample.Enemy.BehaviorTree.Actions
{
    public class MoveToPlayerAction : IAction
    {
        public ExecutionState State { get; private set; }

        private readonly Blackboard _blackboard;
        private readonly Func<bool> _abortCondition;

        public MoveToPlayerAction(Blackboard blackboard, Func<bool> abortCondition)
        {
            _blackboard = blackboard;
            _abortCondition = abortCondition;
        }

        public IEnumerator Execute()
        {
            NavMeshAgent agent = _blackboard.GetValue<NavMeshAgent>("Agent");
            EnemyModel model = _blackboard.GetValue<EnemyModel>("Model");

            if (agent == null)
            {
                State = ExecutionState.Failure;
                yield break;
            }

            agent.speed = model.Speed;
            agent.ResetPath();

            Vector3 playerPosition = GetPlayerPosition();
            
            while (Vector3.Distance(agent.transform.position, playerPosition) > 0.2f)
            {
                playerPosition = GetPlayerPosition();
                agent.SetDestination(playerPosition);

                if (_abortCondition())
                {
                    agent.ResetPath();
                    State = ExecutionState.Failure;
                    yield break;
                }

                yield return null;
            }

            State = ExecutionState.Success;
        }

        private Vector3 GetPlayerPosition()
        {
            return _blackboard.GetValue<Vector3>("PlayerPosition");
        }
    }
}
