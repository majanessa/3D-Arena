using Core;
using Gameplay;
using Model;
using UnityEngine;
using static Core.Simulation;

namespace Mechanics.Player
{
    public class PlayerController : MonoBehaviour
    {
        public FixedJoystick moveJoystick;
        [HideInInspector]
        public Health health;
        [HideInInspector]
        public Power power;
        private Rigidbody _rb;
        private bool _alive;
        private readonly PlayerModel _model = Simulation.GetModel<PlayerModel>();

        private void Start()
        {
            health = GetComponent<Health>();
            power = GetComponent<Power>();
            _rb = GetComponent<Rigidbody>();
            _alive = true;
        }

        private void Update()
        {
            if (_alive)
            {
                float vertMove = moveJoystick.Vertical;
                _rb.MovePosition(transform.position + (transform.forward * Time.fixedDeltaTime * _model.speed * vertMove));
                transform.Rotate(Vector3.up * _model.rotateSpeed * moveJoystick.Horizontal);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("ArenaBorders"))
            {
                var ev = Schedule<PlayerSpawn>();
                ev.Player = this;
            }
        }
    }
}
