using System.Collections;
using System.Collections.Generic;
using Mechanics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public abstract class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject objectToPool;

        [Tooltip("Number of objects in the pool")] [SerializeField]
        private int poolCount;
        
        private static Dictionary<GameObject, EnemyController> _enemies;
        private Queue<GameObject> _currentPrefabs;

        private int _maxIntervalSpawn = 5;
        private readonly int _minIntervalSpawn = 2;
        private Vector3 _spawnPos = Vector3.zero;
        [SerializeField]
        private int countForSpawn = 1;

        private void Start()
        {
            _enemies = new Dictionary<GameObject, EnemyController>();
            _currentPrefabs = new Queue<GameObject>();

            for (int i = 0; i < poolCount; i++)
            {
                _spawnPos.x = Random.Range(-2, 2);
                _spawnPos.y = 0.5f;
                _spawnPos.z = Random.Range(-2, 2);
                var prefab = Instantiate(objectToPool, _spawnPos, Quaternion.identity);
                var script = prefab.GetComponent<EnemyController>();
                prefab.SetActive(false);
                _enemies.Add(prefab, script);
                _currentPrefabs.Enqueue(prefab);
            }
            ReactiveTarget.OnSpawn += ReturnToSpawn;

            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_maxIntervalSpawn > _minIntervalSpawn)
                {
                    yield return new WaitForSeconds(_maxIntervalSpawn);
                    _maxIntervalSpawn--;
                }
                else
                    yield return new WaitForSeconds(_minIntervalSpawn);

                if (_currentPrefabs.Count > 0)
                {
                    for (int i = 0; i < countForSpawn; i++)
                    {
                        var prefab = _currentPrefabs.Dequeue();
                        prefab.SetActive(true);
                    }
                }
            }
        }
        
        private void ReturnToSpawn(GameObject prefab)
        {
            prefab.transform.position = transform.position;
            prefab.SetActive(false);
            _currentPrefabs.Enqueue(prefab);
        }
    }
}