using BehaviorTree;
using BehaviorTree.Actions;
using BehaviorTreeSample.Enemy.Data;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTreeSample.Enemy.BehaviorTree.Actions
{
    public class MoveToWaypointAction : IAction
    {
        public ExecutionState State { get; private set; }

        private readonly Blackboard _blackboard;
        private readonly Func<bool> _abortCondition;

        public MoveToWaypointAction(Blackboard blackboard, Func<bool> abortCondition)
        {
            _blackboard = blackboard;
            _abortCondition = abortCondition;
        }

        public IEnumerator Execute()
        {
            Transform[] waypoints = _blackboard.GetValue<Transform[]>("Waypoints");
            NavMeshAgent agent = _blackboard.GetValue<NavMeshAgent>("Agent");
            EnemyModel model = _blackboard.GetValue<EnemyModel>("Model");

            if (waypoints.Length == 0 || agent == null)
            {
                State = ExecutionState.Failure;
                yield break;
            }

            Vector3 waypoint = waypoints[UnityEngine.Random.Range(0, waypoints.Length)].position;
            agent.speed = model.Speed;
            
            while (Vector3.Distance(agent.transform.position, waypoint) > 0.1f)
            {
                agent.SetDestination(waypoint);

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
    }
}
