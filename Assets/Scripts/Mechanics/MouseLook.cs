using UI;
using UnityEngine;

namespace Mechanics
{
    public class MouseLook : MonoBehaviour {
        public enum RotationAxes {
            MouseXAndY = 0,
            MouseX = 1,
            MouseY = 2
        }
        public RotationAxes axes = RotationAxes.MouseXAndY;
        public float sensitivityHor = 2.0f;
        public float sensitivityVert = 2.0f;
        public float minimumVert = -45.0f;
        public float maximumVert = 45.0f;
        private float _rotationX = 0;
        public FixedTouchField LookJoystick;

        private void Start() {
            Rigidbody body = GetComponent<Rigidbody>();
            if (body != null)
                body.freezeRotation = true;
        }

        private void Update() {
            if (!GameManager.Instance.pause)
            {
                if (axes == RotationAxes.MouseX) {
                    transform.Rotate(0, LookJoystick.TouchDist.x * sensitivityHor, 0);
                }
                else if (axes == RotationAxes.MouseY) {
                    _rotationX -= LookJoystick.TouchDist.y * sensitivityVert;
                    _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                    float rotationY = transform.localEulerAngles.y;
                    transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                }
                else {
                    _rotationX -= LookJoystick.TouchDist.y * sensitivityVert;
                    _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                    float delta = LookJoystick.TouchDist.x * sensitivityHor;
                    float rotationY = transform.localEulerAngles.y + delta;
            
                    transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                }
            }
        }
    }
}

