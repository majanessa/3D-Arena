using System.Collections;
using UnityEngine;

namespace Mechanics
{
    public class FlyEnemyController : EnemyController
    {
        private bool _up = false;
        public Transform heightTarget;

        protected override void Start()
        {
            base.Start();
            heightTarget = GameObject.FindGameObjectWithTag("HeightFly").GetComponent<Transform>();
        }

        protected void Update()
        {
            StartCoroutine(Fly());
        }

        private IEnumerator Fly()
        {
            if (!_up)
            {
                yield return new WaitForSeconds(0.5f);
                transform.position = Vector3.MoveTowards(transform.position, heightTarget.position, Time.deltaTime * Random.Range(1f, 1.5f));
                _up = true;
            }
            
            yield return new WaitForSeconds(1.5f);
            
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, Time.deltaTime * Random.Range(1f, 1.5f));
            
        }
        
        /*private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().Hurt(GameController.Instance.flyEnemyModel.damage);
            }
            gameObject.SetActive(false);
        }*/
    }
}
