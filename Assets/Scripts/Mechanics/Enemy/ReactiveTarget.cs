using System;
using Mechanics.Player;
using UI;
using UnityEngine;

namespace Mechanics.Enemy
{
    public class ReactiveTarget : MonoBehaviour {

        public static Action<GameObject> OnSpawn;

        public void ReactToHit(PlayerController player) {
            EnemyController enemy = gameObject.GetComponent<EnemyController>();
            player.power.AddPower(enemy.Model.PowerForPlayer);
            OnSpawn(gameObject);
            Score.Instance.AddScore(1);
        }
    }
}
