using Gameplay.Player;
using Model;
using UnityEngine;
using static Core.Simulation;

namespace Mechanics.Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector]
        public Health health;
        [HideInInspector]
        public Power power;

        public Vector3 runAxis;
        private Rigidbody _rb;

        public bool Alive { get; set; }

        public PlayerModel model = GetModel<PlayerModel>();

        private void Start()
        {
            health = GetComponent<Health>();
            power = GetComponent<Power>();
            _rb = GetComponent<Rigidbody>();
            Alive = true;
        }

        private void Update()
        {
            if (Alive)
            {
                float vertMove = runAxis.y;
                _rb.MovePosition(transform.position + (transform.forward * Time.fixedDeltaTime * model.speed * vertMove));
                transform.Rotate(Vector3.up * model.rotateSpeed * runAxis.x);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("ArenaBorders") && Alive)
            {
                var ev = Schedule<PlayerSpawn>();
                ev.Player = this;
            }
        }
    }
}
