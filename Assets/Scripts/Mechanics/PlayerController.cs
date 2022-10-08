using Core;
using Model;
using UnityEngine;

namespace Mechanics
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 3.0f, rotateSpeed = 6f;
        public int health;
        public int power;
        private Rigidbody _rb;
        private bool _alive;
        private GameObject[] _enemies;
        public RectTransform healthBar;
        public RectTransform powerBar;
        public PlayerModel model = Simulation.GetModel<PlayerModel>();

        private void Start()
        {
            health = model.hp;
            power = model.power;
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
                Ulta();
            }
        }
        
        public void Hurt(int damage)
        {
            health -= damage;
            healthBar.offsetMax = new Vector2(-1f * 200f * (model.hp - health) / 100f, 0);
            if (health <= 0)
                GameManager.Instance.GameOver();
        }
        
        public void AddHalfHurt()
        {
            healthBar.offsetMax = new Vector2(-1f * 200f * 50f / 100f, 0);
        }

        public void AddPower(int power)
        {
            this.power += power;
            if (this.power >= model.maxPower)
                this.power = model.maxPower;
            powerBar.offsetMax = new Vector2(200f * (-model.maxPower + this.power) / 100f, 0);
        }

        private void Ulta()
        {
            if (power >= model.maxPower && Input.GetButtonDown("Fire2"))
            {
                _enemies = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < _enemies.Length; i++)
                {
                    ReactiveTarget.OnSpawn(_enemies[i]);
                }
                powerBar.offsetMax = new Vector2(200f * (-model.maxPower - model.maxPower) / 100f, 0);
                power = 0;
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
