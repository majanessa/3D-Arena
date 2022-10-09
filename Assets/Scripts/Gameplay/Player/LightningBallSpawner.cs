using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Player
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
