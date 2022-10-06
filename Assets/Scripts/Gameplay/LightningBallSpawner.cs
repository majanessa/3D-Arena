using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class LightningBallSpawner : MonoBehaviour
    {
        public List<GameObject> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;

        private void Start()
        {
            pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        public IEnumerator LightningBall(GameObject lightningBall, Vector3 playerPosition)
        {
            yield return new WaitForSeconds(0);
            lightningBall.SetActive(true);
            lightningBall.transform.position = Vector3.MoveTowards(lightningBall.transform.position, playerPosition, Time.deltaTime * 3f);
        }

        public GameObject GetPooledObject(Vector3 position)
        {
            foreach (var t in pooledObjects)
            {
                if (!t.activeInHierarchy)
                {
                    t.transform.position = position;
                    return t;
                }
            }

            return null;
        }
    }
}