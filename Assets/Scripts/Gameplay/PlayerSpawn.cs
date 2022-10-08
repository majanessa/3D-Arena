using Core;
using Mechanics.Player;
using UnityEngine;

namespace Gameplay
{
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        public PlayerController Player;
        public override void Execute()
        {
            Vector3 position = Player.gameObject.transform.position;
            Player.gameObject.transform.position = new Vector3(-position.x, position.y, -position.z);
        }
    }
}
