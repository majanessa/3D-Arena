using System.Collections;
using Core;
using Model;
using UnityEngine;

namespace Mechanics
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
            //model = GameController.Instance.flyEnemyModel;
            Model = Simulation.GetModel<FlyEnemyModel>();
        }

        protected void Update()
        {
            //if (Alive)
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
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                player.Hurt(Model.Damage);
                ReactiveTarget.OnSpawn(gameObject);
            }
        }
    }
}
