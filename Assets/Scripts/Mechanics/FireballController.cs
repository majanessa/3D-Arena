using UnityEngine;

namespace Mechanics
{
    public class FireballController : EnemyController
    {
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, Time.deltaTime * 3f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().Hurt(GameController.Instance.bossEnemyModel.damage);
                gameObject.SetActive(false);
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
