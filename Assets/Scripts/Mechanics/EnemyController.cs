using Model;
using UnityEngine;

namespace Mechanics
{
    public abstract class EnemyController : MonoBehaviour
    {
        protected Transform PlayerTarget;
        public IEnemyModel Model;

        protected virtual void Start()
        {
            PlayerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }
}
