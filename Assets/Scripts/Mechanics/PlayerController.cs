using UnityEngine;

namespace Mechanics
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float speed = 3.0f;
        public float gravity = -9.8f;
        private CharacterController _charController;
        private int _health;

        private void Start() {
            _charController = GetComponent<CharacterController>();
            _health = 5;
        }

        private void Update() {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement.y = gravity;
        
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);
        }
        
        public void Hurt(int damage) {
            _health -= damage;
                Debug.Log("Health: " + _health);
        }
    }
}
