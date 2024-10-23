using UnityEngine;

namespace BehaviorTreeSample.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerModel", menuName = "ScriptableObjects/PlayerModel")]
    public class PlayerModel : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
    }
}
