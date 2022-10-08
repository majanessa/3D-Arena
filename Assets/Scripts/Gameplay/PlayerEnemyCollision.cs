using JetBrains.Annotations;
using Mechanics.Player;
using UnityEngine;
using static Core.Simulation;

namespace Gameplay
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
                Schedule<EnemyDeath>();
        }
    }
}
