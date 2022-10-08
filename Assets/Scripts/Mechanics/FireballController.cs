using Core;
using Model;
using UnityEngine;

namespace Mechanics
{
    public class FireballController : EnemyController
    {
        private readonly BossEnemyModel _bossEnemyModel = Simulation.GetModel<BossEnemyModel>();

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, Time.deltaTime * 3f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                player.Hurt(_bossEnemyModel.Damage);
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
