using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Coral.Components.InputSystem
{
    public class ClickReceiver : MonoBehaviour, IPointerClickHandler
    {
        public ClickAndRotate cameraController;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            cameraController.SetTarget(eventData.pointerClick.transform);
        }
    }
}