using System;
using Gameplay.Enemy;
using Mechanics.Player;
using UnityEngine;
using static Core.Simulation;

namespace Mechanics.Enemy
{
    public class ReactiveTarget : MonoBehaviour {

        public static Action<GameObject> OnSpawn;

        public void ReactToHit(PlayerController player) {
            var ev = Schedule<EnemyDeath>();
            ev.Enemy = gameObject.GetComponent<EnemyController>();
            ev.Player = player;
        }
    }
}
