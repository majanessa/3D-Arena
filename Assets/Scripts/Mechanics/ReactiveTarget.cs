using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Mechanics
{
    public class ReactiveTarget : MonoBehaviour {

        public static Action<GameObject> OnSpawn;
        
        public void ReactToHit() {
            StartCoroutine(Die());
        }
        private IEnumerator Die()
        {
            yield return new WaitForSeconds(0);
            OnSpawn(gameObject);
            gameObject.GetComponent<EnemyController>().SetAlive(false);
            Score.Instance.AddScore(1);
        }
    }
}
