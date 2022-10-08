using Core;
using Mechanics.Enemy;

namespace Gameplay
{
    public class EnemyDeath : Simulation.Event<PlayerEnemyCollision>
    {
        public EnemyController enemy;
        
        public override void Execute()
        {
            
        }
    }
}
