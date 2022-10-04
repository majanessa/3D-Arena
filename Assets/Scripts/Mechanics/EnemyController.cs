using UnityEngine;

namespace Mechanics
{
    public abstract class EnemyController : MonoBehaviour
    {
        protected Transform PlayerTarget;

        protected virtual void Start()
        {
            PlayerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }
}
