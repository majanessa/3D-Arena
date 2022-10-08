using Model;
using UnityEngine;

namespace Mechanics
{
    public abstract class EnemyController : MonoBehaviour
    {
        protected Transform PlayerTarget;
        protected bool Alive;
        public IEnemyModel Model;

        protected virtual void Start()
        {
            Alive = true;
            PlayerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        
        public void SetAlive(bool alive) {
            Alive = alive;
        }
    }
}
