using Core;
using Model;
using UnityEngine;

namespace Mechanics
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 3.0f, rotateSpeed = 6f;
        private int _health, _power;
        private Rigidbody _rb;
        private bool _alive;
        private GameObject[] _enemies;
        public RectTransform healthBar;
        public RectTransform powerBar;
        public PlayerModel model = Simulation.GetModel<PlayerModel>();

        private void Start() 
        {
            _health = model.hp;
            _power = model.power;
            powerBar.offsetMax = new Vector2(-1f * 200f * (model.maxPower - model.power) / 100f, 0);
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
                if (_power >= model.maxPower && Input.GetButtonDown("Fire2"))
                {
                    _enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    for (int i = 0; i < _enemies.Length; i++)
                    {
                        ReactiveTarget.OnSpawn(_enemies[i]);
                    }
                    powerBar.offsetMax = new Vector2(200f * (-model.maxPower - model.maxPower) / 100f, 0);
                    _power = 0;
                }
            }
        }
        
        public void Hurt(int damage) 
        {
            _health -= damage;
            healthBar.offsetMax = new Vector2(-1f * 200f * (model.hp - _health) / 100f, 0);
            if (_health <= 0)
                GameManager.Instance.GameOver();
        }

        public void AddPower(int power)
        {
            _power += power;
            if (_power >= model.maxPower)
                _power = model.maxPower;
            powerBar.offsetMax = new Vector2(200f * (-model.maxPower + _power) / 100f, 0);
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
