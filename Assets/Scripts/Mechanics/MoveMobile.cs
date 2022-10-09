using Mechanics.Player;
using UI;
using UnityEngine;

namespace Mechanics
{
    public class MoveMobile : MonoBehaviour
    {
        public FixedJoystick moveJoystick;
        public FixedTouchField lookJoystick;
        public FixedButton ultaButton, shootButton, pauseButton;
        private PlayerController _player;
        private MouseLook _mouseLook;
        private Power _power;
        private RayShooter _shoot;
        private GameController _pause;
        private bool _isPlayerNotNull, _isPowerNotNull, _isRayShooterNotNull, _isPauseNotNull, _isMouseLookNotNull;

        private void Start()
        {
            _power = GetComponent<Power>();
            _mouseLook = GetComponent<MouseLook>();
            _player = GetComponent<PlayerController>();
            _shoot = GetComponent<RayShooter>();
            _pause = GetComponent<GameController>();
            _isPowerNotNull = _power != null;
            _isPlayerNotNull = _player != null;
            _isRayShooterNotNull = _shoot != null;
            _isPauseNotNull = _pause != null;
            _isMouseLookNotNull = _mouseLook != null;
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
            
            if (_isRayShooterNotNull)
                _shoot.shootAxis = Application.isEditor ? Input.GetButtonDown("Fire1") : shootButton.pressed;
            
            if (_isPauseNotNull)
                _pause.pauseAxis = Application.isEditor ? Input.GetButtonDown("Pause") : pauseButton.pressed;

            if (_isMouseLookNotNull)
            {
                _mouseLook.lookAxis.x = Application.isEditor ? Input.GetAxis("Mouse X") : lookJoystick.touchDist.x;
                _mouseLook.lookAxis.y = Application.isEditor ? Input.GetAxis("Mouse Y") : lookJoystick.touchDist.y;
            }
        }
    }
}
