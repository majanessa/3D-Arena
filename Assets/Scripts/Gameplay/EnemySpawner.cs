using System.Collections;
using System.Collections.Generic;
using Mechanics;
using UnityEngine;

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

        private float _maxIntervalSpawn = 5.0f;
        private float _minxIntervalSpawn = 2.0f;
        private Vector3 spawnPos = Vector3.zero;
        [SerializeField]
        private int countForSpawn = 1;

        private void Start()
        {
            _enemies = new Dictionary<GameObject, EnemyController>();
            _currentPrefabs = new Queue<GameObject>();

            for (int i = 0; i < poolCount; i++)
            {
                spawnPos.x = Random.Range(-2, 2);
                spawnPos.y = 0.5f;
                spawnPos.z = Random.Range(-2, 2);
                var prefab = Instantiate(objectToPool, spawnPos, Quaternion.identity);
                var script = prefab.GetComponent<EnemyController>();
                prefab.SetActive(false);
                _enemies.Add(prefab, script);
                _currentPrefabs.Enqueue(prefab);
            }

            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_maxIntervalSpawn > _minxIntervalSpawn)
                {
                    yield return new WaitForSeconds(_maxIntervalSpawn);
                    _maxIntervalSpawn--;
                }
                else
                    yield return new WaitForSeconds(_minxIntervalSpawn);

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
    }
}