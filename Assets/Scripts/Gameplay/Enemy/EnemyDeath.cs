using Core;
using Mechanics.Enemy;
using UnityEngine;

namespace Gameplay.Enemy
{
    public class EnemyDeath : Simulation.Event<EnemyDeath>
    {
        public GameObject Enemy;
        
        public override void Execute()
        {
            // Return enemy to spawn
            if (ReactiveTarget.OnSpawn != null)
                ReactiveTarget.OnSpawn(Enemy);
        }
    }
}
