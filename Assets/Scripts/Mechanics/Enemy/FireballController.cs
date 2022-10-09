using Gameplay.Player;
using Mechanics.Player;
using Model.Enemy;
using UnityEngine;
using static Core.Simulation;

namespace Mechanics.Enemy
{
    public class FireballController : EnemyController
    {
        private readonly BossEnemyModel _bossEnemyModel = GetModel<BossEnemyModel>();

        private void Update()
        {
            if (playerController.Alive)
                transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, Time.deltaTime * 3f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.Player = collision.gameObject.GetComponent<PlayerController>();
                ev.Damage = _bossEnemyModel.Damage;
                Destroy(gameObject);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("ArenaBorders"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
