using BehaviorTreeSample.Player.Data;
using UnityEngine;

namespace BehaviorTreeSample.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerModel model;

        private void Update()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * model.Speed * Time.deltaTime;
            Vector3 newPosition = transform.position + movement;

            newPosition.x = Mathf.Clamp(newPosition.x, -14f, 14f);
            newPosition.z = Mathf.Clamp(newPosition.z, -9f, 9f);

            transform.position = newPosition;
        }
    }
}
