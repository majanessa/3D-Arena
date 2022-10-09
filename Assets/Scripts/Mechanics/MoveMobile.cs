using Mechanics.Player;
using UI;
using UnityEngine;

namespace Mechanics
{
    public class MoveMobile : MonoBehaviour
    {
        public FixedJoystick moveJoystick;
        public FixedTouchField lookJoystick;
        public FixedButton ultaButton;
        private PlayerController _player;
        private MouseLook _mouseLook;
        private Power _power;
        private bool _isPlayerNotNull;
        private bool _isPowerNotNull;

        private void Start()
        {
            _power = GetComponent<Power>();
            _mouseLook = GetComponent<MouseLook>();
            _player = GetComponent<PlayerController>();
            _isPowerNotNull = _power != null;
            _isPlayerNotNull = _player != null;
        }

        private void Update()
        {
            if (_isPlayerNotNull)
            {
                _player.runAxis.x = Application.isEditor ? Input.GetAxis("Horizontal") : moveJoystick.Horizontal;
                _player.runAxis.y = Application.isEditor ? Input.GetAxis("Vertical") : moveJoystick.Vertical;
            }
            
            if (_isPowerNotNull)
                _power.powerAxis = Application.isEditor ? Input.GetButtonDown("Fire2") : ultaButton.pressed;

            _mouseLook.lookAxis.x = Application.isEditor ? Input.GetAxis("Mouse X") : lookJoystick.touchDist.x;
            _mouseLook.lookAxis.y = Application.isEditor ? Input.GetAxis("Mouse Y") : lookJoystick.touchDist.y;
        }
    }
}
