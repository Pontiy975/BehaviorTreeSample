using BehaviorTree;
using BehaviorTree.Actions;
using BehaviorTreeSample.Components;
using BehaviorTreeSample.Enemy.BehaviorTree.Actions;

namespace BehaviorTreeSample.Enemy.BehaviorTree
{
    public class EnemyBehaviorTree : global::BehaviorTree.BehaviorTree
    {
        public EnemyBehaviorTree(Blackboard blackboard, bool debug)
        {
            this.blackboard = blackboard;

            rootNode = new SelectorNode(new()
            {
                InitCombatBranch(),
                InitPatrolBranch()
            });

            SetDebugMode(rootNode, debug);
        }

        #region Branches
        private IBehaviorNode InitCombatBranch()
        {
            // Branch conditions
            IBehaviorNode PlayerVisibleCondition = new ConditionNode(IsPlayerVisible);
            //IBehaviorNode PlayerInRangeCondition = new ConditionNode(IsPlayerInRange);

            // Branch actions
            //IBehaviorNode attackAction = new ActionNode(new AttackAction());
            IBehaviorNode moveToPlayerAction = new ActionNode(new MoveToPlayerAction(blackboard, () => !IsPlayerVisible()));

            // Composite nodes
            //IBehaviorNode checkDistanceSequence = new SequenceNode(new()
            //{
            //    PlayerInRangeCondition,
            //    attackAction
            //});

            IBehaviorNode attackSelector = new SelectorNode(new()
            {
                //checkDistanceSequence,
                moveToPlayerAction
            });

            return new SequenceNode(new()
            {
                PlayerVisibleCondition,
                attackSelector
            });
        }

        private IBehaviorNode InitPatrolBranch()
        {
            return new SequenceNode(new()
            {
                new ActionNode(new MoveToWaypointAction(blackboard, IsPlayerVisible)),
                new ActionNode(new WaitAction(1f)) // 1f - duration;
            });
        }
        #endregion

        #region Conditions
        private bool IsPlayerVisible()
        {
            return blackboard.HasKey("PlayerPosition");
        }

        //private bool IsPlayerInRange()
        //{
        //    // TODO: compare distance between enemy and player
        //    return false;
        //}

        protected override bool RunCondition()
        {
            HealthComponent healthComponent = blackboard.GetValue<HealthComponent>("Health");
            return healthComponent != null && !healthComponent.IsDead;
        }
        #endregion
    }
}
