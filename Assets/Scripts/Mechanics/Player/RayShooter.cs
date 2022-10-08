using Gameplay;
using UnityEngine;

namespace Mechanics.Player
{
    public class RayShooter : MonoBehaviour {
        private Camera _camera;

        private void Start() {
            _camera = GetComponent<Camera>();
            
            /*Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;*/
        }

        private void OnGUI() {
            int size = 12;
            float posX = _camera.pixelWidth/2 - size/4;
            float posY = _camera.pixelHeight/2 - size/2;
            GUI.Label(new Rect(posX, posY, size, size), "*");
        }

        private void Update() {
            if (Input.GetButtonDown("Fire1")) {
                Vector3 point = new Vector3(
                    _camera.pixelWidth/2, _camera.pixelHeight/2, 0);
                Ray ray = _camera.ScreenPointToRay(point);
                if (Physics.Raycast(ray, out var hit))
                {
                    GameObject fireInstance = GetComponent<LightningBallSpawner>().GetPooledObject(hit.point);
                    if (fireInstance != null)
                    {
                        fireInstance.SetActive(true);
                        fireInstance.GetComponent<Rigidbody>().velocity = fireInstance.transform.forward * 20;
                    }
                }
                
            }
        }
    }
}
