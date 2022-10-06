using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class FireballSpawner : MonoBehaviour {
        /*public float speed = 10.0f;
        public int damage = 1;
        void Update() {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    
        void OnTriggerEnter(Collider other) {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Hurt(damage);
            }
            Destroy(this.gameObject);
        }*/

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

        public IEnumerator Fireball(GameObject fireball, Vector3 playerPosition)
        {
            if (!fireball.activeSelf)
            {
                yield return new WaitForSeconds(3f);
                fireball.SetActive(true);
            }
            yield return new WaitForSeconds(0);
            fireball.transform.position = Vector3.MoveTowards(fireball.transform.position, playerPosition, Time.deltaTime * 3f);
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
