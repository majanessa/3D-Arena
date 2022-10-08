using System.Collections;
using Core;
using Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Mechanics
{
    public class BossEnemyController : EnemyController
    {
        public GameObject fireballPrefab;

        protected override void Start()
        {
            base.Start();
            transform.TransformPoint(PlayerTarget.position * 0.5f);
            StartCoroutine(FireballSpawn());
            Model = Simulation.GetModel<BossEnemyModel>();
        }

        protected void Update()
        {
            StartCoroutine(GoToPlayer());
        }

        private IEnumerator GoToPlayer()
        {
            yield return new WaitForSeconds(0);
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, Time.deltaTime * Random.Range(0.05f, 0.07f));
        }
        
        private IEnumerator FireballSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                GameObject fireball = Instantiate(fireballPrefab);
                fireball.transform.position = transform.TransformPoint(PlayerTarget.position * 0.5f);
                fireball.transform.rotation = transform.rotation;
            }
        }
    }
}
