using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Mechanics
{
    public class ReactiveTarget : MonoBehaviour {
        
        public static Action<GameObject> OnSpawn;
        
        public void ReactToHit() {
            StartCoroutine(Die());
        }
        private IEnumerator Die()
        {
            NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
            if (agent != null)
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
            yield return new WaitForSeconds(0);
            //gameObject.GetComponent<EnemyController>().SetAlive(false);
            OnSpawn(gameObject);
        }
    }
}
