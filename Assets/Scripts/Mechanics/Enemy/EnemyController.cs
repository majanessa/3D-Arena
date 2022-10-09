using Mechanics.Player;
using Model.Enemy;
using UnityEngine;

namespace Mechanics.Enemy
{
    public abstract class EnemyController : MonoBehaviour
    {
        public IEnemyModel Model;
        public PlayerController playerController;
        protected Transform PlayerTarget;

        protected virtual void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            playerController = player.GetComponent<PlayerController>();
            PlayerTarget = player.GetComponent<Transform>();
        }
    }
}
