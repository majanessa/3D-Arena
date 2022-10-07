using Model;
using UnityEngine;

namespace Mechanics
{
    public class FireballController : EnemyController
    {
        private BossEnemyModel _bossEnemyModel;

        protected override void Start()
        {
            base.Start();
            _bossEnemyModel = GameController.Instance.bossEnemyModel;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, Time.deltaTime * 3f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                player.Hurt(_bossEnemyModel.damage);
                player.AddPower(_bossEnemyModel.powerForPlayer);
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
