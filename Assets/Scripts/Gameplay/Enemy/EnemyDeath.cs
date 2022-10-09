using Core;
using Mechanics.Enemy;
using Mechanics.Player;
using UI;

namespace Gameplay.Enemy
{
    public class EnemyDeath : Simulation.Event<EnemyDeath>
    {
        public EnemyController Enemy;

        public PlayerController Player;
        
        public override void Execute()
        {
            Player.power.AddPower(Enemy.Model.PowerForPlayer);
            Score.Instance.AddScore(1);
            // Return enemy to spawn
            if (ReactiveTarget.OnSpawn != null)
                ReactiveTarget.OnSpawn(Enemy.gameObject);
        }
    }
}
