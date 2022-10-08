using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector]
        public Vector2 touchDist;
        [HideInInspector]
        public Vector2 pointerOld;
        [HideInInspector]
        public bool pressed;
        private int _pointerId;
        
        private void Update()
        {
            if (pressed)
            {
                if (_pointerId >= 0 && _pointerId < Input.touches.Length)
                {
                    touchDist = Input.touches[_pointerId].position - pointerOld;
                    pointerOld = Input.touches[_pointerId].position;
                }
                else
                {
                    touchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointerOld;
                    pointerOld = Input.mousePosition;
                }
            }
            else
            {
                touchDist = new Vector2();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            pressed = true;
            _pointerId = eventData.pointerId;
            pointerOld = eventData.position;
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            pressed = false;
        }
    }
}
