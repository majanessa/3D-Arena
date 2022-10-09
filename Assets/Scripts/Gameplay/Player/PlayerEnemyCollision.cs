using Gameplay.Enemy;
using JetBrains.Annotations;
using Mechanics.Player;
using UnityEngine;
using static Core.Simulation;

namespace Gameplay.Player
{
    public class PlayerEnemyCollision : Event<PlayerEnemyCollision>
    {
        public PlayerController Player;
        [CanBeNull] public GameObject Enemy;
        public int Damage;
        public override void Execute()
        {
            Player.health.Hurt(Damage);
            if (Enemy != null)
            {
                var ev = Schedule<EnemyDeath>();
                ev.Enemy = Enemy;
            }
        }
    }
}
