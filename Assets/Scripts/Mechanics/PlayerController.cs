using Model;
using UI;
using UnityEngine;

namespace Mechanics
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 3.0f, rotateSpeed = 6f;
        private int _health;
        private Rigidbody _rb;
        private PlayerModel _model;
        private bool _alive;

        private void Start() {
            _model = GameController.Instance.playerModel;
            _health = _model.hp;
            _rb = GetComponent<Rigidbody>();
            _alive = true;
        }

        private void Update() {
            if (_alive)
            {
                float vertMove = Input.GetAxis("Vertical");
                _rb.MovePosition(transform.position + (transform.forward * Time.fixedDeltaTime * speed * vertMove));
                transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Horizontal"));
            }
        }
        
        public void Hurt(int damage) {
            _health -= damage;
            Debug.Log(damage);
            if (_health <= 0)
            {
                GameController.Instance.gameObject.GetComponent<GameOver>().SetActive();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("ArenaBorders"))
            {
                transform.position = new Vector3(-transform.position.x, transform.position.y, -transform.position.z);
            }
        }
    }
}
