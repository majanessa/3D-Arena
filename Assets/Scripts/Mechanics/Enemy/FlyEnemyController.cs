using System.Collections;
using Gameplay.Player;
using Mechanics.Player;
using Model.Enemy;
using UnityEngine;
using static Core.Simulation;

namespace Mechanics.Enemy
{
    public class FlyEnemyController : EnemyController
    {
        private bool _up;
        private Transform _heightTarget;

        protected override void Start()
        {
            base.Start();
            _up = false;
            _heightTarget = GameObject.FindGameObjectWithTag("HeightFly").GetComponent<Transform>();
            Model = GetModel<FlyEnemyModel>();
        }

        protected void Update()
        {
            if (playerController.Alive)
                StartCoroutine(Fly());
        }

        private IEnumerator Fly()
        {
            if (!_up)
            {
                yield return new WaitForSeconds(0.5f);
                transform.position = Vector3.MoveTowards(transform.position, _heightTarget.position, Time.deltaTime * Random.Range(1f, 1.5f));
                _up = true;
            }
            
            yield return new WaitForSeconds(1.5f);
            
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, Time.deltaTime * Random.Range(1f, 1.5f));
            
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.Player = collision.gameObject.GetComponent<PlayerController>();
                ev.Damage = Model.Damage;
            }
        }
    }
}
