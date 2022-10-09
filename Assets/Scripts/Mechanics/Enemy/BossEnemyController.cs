using System.Collections;
using Core;
using Model.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Mechanics.Enemy
{
    public class BossEnemyController : EnemyController
    {
        public GameObject fireballPrefab;

        protected override void Start()
        {
            base.Start();
            Model = Simulation.GetModel<BossEnemyModel>();
            transform.TransformPoint(PlayerTarget.position * Model.Speed);
            if (playerController.Alive)
                StartCoroutine(FireballSpawn());
        }

        protected void Update()
        {
            if (playerController.Alive)
                StartCoroutine(GoToPlayer());
        }

        private IEnumerator GoToPlayer()
        {
            yield return new WaitForSeconds(0);
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, Time.deltaTime * Random.Range(0.05f, 0.07f));
        }
        
        private IEnumerator FireballSpawn()
        {
            while (!GameController.Instance.gameOver)
            {
                yield return new WaitForSeconds(3);
                GameObject fireball = Instantiate(fireballPrefab);
                fireball.transform.position = transform.TransformPoint(PlayerTarget.position * Model.Speed);
                fireball.transform.rotation = transform.rotation;
            }
        }
    }
}
