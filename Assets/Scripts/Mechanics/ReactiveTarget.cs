using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Mechanics
{
    public class ReactiveTarget : MonoBehaviour {

        public static Action<GameObject> OnSpawn;

        public void ReactToHit(PlayerController player) {
            StartCoroutine(Die(player));
        }
        private IEnumerator Die(PlayerController player)
        {
            yield return new WaitForSeconds(0);
            EnemyController enemy = gameObject.GetComponent<EnemyController>();
            player.AddPower(enemy.Model.PowerForPlayer);
            OnSpawn(gameObject);
            Score.Instance.AddScore(1);
        }
    }
}
