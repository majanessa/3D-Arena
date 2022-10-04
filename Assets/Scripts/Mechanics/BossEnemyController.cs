using UnityEngine;
using UnityEngine.AI;

namespace Mechanics
{
    public class BossEnemyController : EnemyController
    {
        private NavMeshAgent _agent;
        
        public float obstacleRange = 5.0f;
        [SerializeField] private GameObject fireballPrefab;
        private GameObject _fireball;
        
        protected override void Start()
        {
            base.Start();
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = 0.2f;
        }

        protected void Update()
        {
            _agent.SetDestination(PlayerTarget.position);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerController>()) {
                    if (_fireball == null) {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position =
                        transform.TransformPoint(PlayerTarget.position * 0.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange) {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
}
