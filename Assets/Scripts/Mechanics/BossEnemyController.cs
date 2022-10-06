using System;
using System.Collections;
using Gameplay;
using Model;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Mechanics
{
    public class BossEnemyController : EnemyController
    {
        public float obstacleRange = 5.0f;
        //private NavMeshAgent _agent;
        private FireballSpawner _fireballSpawner;
        private BossEnemyModel _model;
        
        protected override void Start()
        {
            base.Start();
            /*_agent = GetComponent<NavMeshAgent>();
            _agent.enabled = true;
            _agent.speed = 0.2f;*/
            _fireballSpawner = GetComponent<FireballSpawner>();
            _model = GameController.Instance.bossEnemyModel;
        }

        protected void Update()
        {
            /*if (Alive)
            {
                _agent.SetDestination(PlayerTarget.position);
                GameObject fireball = _fireballSpawner.GetPooledObject(transform.position);
                if (fireball != null)
                {
                    StartCoroutine(_fireballSpawner.Fireball(fireball, PlayerTarget.position));
                }
            }*/

            StartCoroutine(Go());
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit)) {
                
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerController>() == null && hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }

                /*if (_fireball == null) {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position =
                    transform.TransformPoint(PlayerTarget.position * 0.5f);
                    _fireball.transform.rotation = transform.rotation;
                }*/
                GameObject fireball = _fireballSpawner.GetPooledObject(transform.position);
                if (fireball != null)
                    StartCoroutine(_fireballSpawner.Fireball(fireball, PlayerTarget.position));
            }
        }

        private IEnumerator Go()
        {
            yield return new WaitForSeconds(0);
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, Time.deltaTime * Random.Range(0.05f, 0.07f));
        }
    }
}
