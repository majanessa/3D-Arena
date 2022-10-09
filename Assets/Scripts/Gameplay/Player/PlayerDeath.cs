using Core;
using Mechanics;
using Mechanics.Player;

namespace Gameplay.Player
{
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        public PlayerController Player;
        public override void Execute()
        {
            Player.Alive = false;
            GameController.Instance.GameOver();
        }
    }
}
