using System.Collections;
using UnityEngine;

namespace Mechanics
{
    public class ReactiveTarget : MonoBehaviour {
        public void ReactToHit() {
            StartCoroutine(Die());
        }
        private IEnumerator Die() {
            transform.Rotate(-75, 0, 0);
            yield return new WaitForSeconds(1.5f);
        
            Destroy(gameObject);
        }
    }
}
