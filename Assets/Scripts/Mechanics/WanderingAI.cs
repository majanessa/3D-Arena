/*using UnityEngine;
using UnityEngine.AI;

namespace Mechanics
{
    public class WanderingAI : MonoBehaviour {
        public float speed = 3.0f;
        public float obstacleRange = 5.0f;
        private bool _alive;
        [SerializeField] private GameObject fireballPrefab;
        private GameObject _fireball;
        private NavMeshAgent _agent;
        private Transform _target;

        void Start() {
            _alive = true;
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update() {
            if (_alive)
            {
                _agent.SetDestination(_target.position);
                /*transform.Translate(0, 0, speed * Time.deltaTime);
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (Physics.SphereCast(ray, 0.75f, out hit)) {
                    GameObject hitObject = hit.transform.gameObject;
                    if (hitObject.GetComponent<PlayerController>()) {
                        if (_fireball == null) {
                                _fireball = Instantiate(fireballPrefab) as GameObject;
                                _fireball.transform.position =
                                transform.TransformPoint(Vector3.forward * 1.5f);
                            _fireball.transform.rotation = transform.rotation;
                        }
                    }
                    else if (hit.distance < obstacleRange) {
                        float angle = Random.Range(-110, 110);
                        transform.Rotate(0, angle, 0);
                    }
                }#1#
            }
        }
        
        public void SetAlive(bool alive) {
                _alive = alive;
        }
    }
}*/
