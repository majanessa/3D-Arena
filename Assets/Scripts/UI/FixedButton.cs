using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [HideInInspector]
        public bool pressed;

        public void OnPointerDown(PointerEventData eventData)
        {
            pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            pressed = false;
        }
    }
}
