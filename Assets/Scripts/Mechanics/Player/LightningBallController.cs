using System.Collections;
using Mechanics.Enemy;
using UnityEngine;

namespace Mechanics.Player
{
    public class LightningBallController : MonoBehaviour
    {
        private Rigidbody _rb;
        private PlayerController player;
        private int _countEnemy;

        private void Start()
        {
            _countEnemy = 0;
            _rb = GetComponent<Rigidbody>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                _countEnemy++;
                if (_countEnemy >= 2)
                {
                    player.power.AddPower(15);
                    player.health.AddHalfHurt();
                }
                ReactiveTarget target = collision.gameObject.GetComponent<ReactiveTarget>();
                if (target != null)
                    target.ReactToHit(player);
                if (player.health.currentHealth > 80)
                    StartCoroutine(FireballNotActive(gameObject, 0));
                else if (player.health.currentHealth is > 50 and < 80)
                {
                    int random = Random.Range(1, 100);
                    if (random > 50)
                        _rb.velocity = Vector3.Reflect(-collision.relativeVelocity.normalized, collision.contacts[0].normal) * 20;
                } 
                else if (player.health.currentHealth is > 30 and < 50)
                {
                    int random = Random.Range(1, 100);
                    if (random > 30)
                        _rb.velocity = Vector3.Reflect(-collision.relativeVelocity.normalized, collision.contacts[0].normal) * 20;
                } 
                else if (player.health.currentHealth < 30)
                    _rb.velocity = Vector3.Reflect(-collision.relativeVelocity.normalized, collision.contacts[0].normal) * 20;

                StartCoroutine(FireballNotActive(gameObject, 1f));
            }
            else
                gameObject.SetActive(false);
        }
        
        private IEnumerator FireballNotActive(GameObject fireInstance, float time)
        {
            yield return new WaitForSeconds(time);
            fireInstance.SetActive(false);
        }
    }
}
