using Model;
using UnityEngine;

namespace Mechanics
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 3.0f, rotateSpeed = 6f;
        private int _health, _power;
        private Rigidbody _rb;
        private PlayerModel _model;
        private bool _alive;
        private GameObject[] _enemies;

        private void Start() 
        {
            _model = GameController.Instance.playerModel;
            _health = _model.hp;
            _power = _model.power;
            _rb = GetComponent<Rigidbody>();
            _alive = true;
        }

        private void Update() 
        {
            if (_alive)
            {
                float vertMove = Input.GetAxis("Vertical");
                _rb.MovePosition(transform.position + (transform.forward * Time.fixedDeltaTime * speed * vertMove));
                transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Horizontal"));
                if (_power >= _model.maxPower && Input.GetButtonDown("Fire2"))
                {
                    _enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    for (int i = 0; i < _enemies.Length; i++)
                    {
                        ReactiveTarget.OnSpawn(_enemies[i]);
                    }
                    _power = 0;
                }
            }
        }
        
        public void Hurt(int damage) 
        {
            _health -= damage;
            if (_health <= 0)
                GameManager.Instance.GameOver();
        }

        public void AddPower(int power)
        {
            _power += power;
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
