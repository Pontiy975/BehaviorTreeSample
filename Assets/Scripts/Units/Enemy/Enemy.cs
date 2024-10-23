using BehaviorTree;
using BehaviorTreeSample.Components;
using BehaviorTreeSample.Enemy.BehaviorTree;
using BehaviorTreeSample.Enemy.Data;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTreeSample.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private bool debug;
        [SerializeField] private EnemyModel model;
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform[] waypoints;

        private global::BehaviorTree.BehaviorTree _behaviorTree;
        private Blackboard _blackboard;

        private void Start()
        {
            healthComponent.Init(model.Health);
            RunBehaviorTree();
        }

        private void RunBehaviorTree()
        {
            _blackboard = new Blackboard();
            _blackboard.SetValue("Health", healthComponent);
            _blackboard.SetValue("Model", model);
            _blackboard.SetValue("Agent", agent);
            _blackboard.SetValue("Waypoints", waypoints);

            _behaviorTree = new EnemyBehaviorTree(_blackboard, debug);
            StartCoroutine(_behaviorTree.Execute());
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
                _blackboard.SetValue("PlayerPosition", other.transform.position);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                _blackboard.RemoveKey("PlayerPosition");
        }
    }
}
