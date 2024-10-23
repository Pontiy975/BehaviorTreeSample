using UnityEngine;

namespace BehaviorTreeSample.Enemy.Data
{
    [CreateAssetMenu(fileName = "EnemyModel", menuName = "ScriptableObjects/EnemyModel")]
    public class EnemyModel : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
    }
}
