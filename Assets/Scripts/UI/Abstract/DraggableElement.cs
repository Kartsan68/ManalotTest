using UnityEngine;
using UnityEngine.EventSystems;

namespace Kartsan.ManalotGamesTest.UI
{
    public abstract class DraggableElement : MonoBehaviour, IBeginDragHandler, IDragHandler,
                                             IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        protected Vector3 basePosition;

        public virtual void OnBeginDrag(PointerEventData eventData) { }

        public virtual void OnDrag(PointerEventData eventData) { }

        public virtual void OnEndDrag(PointerEventData eventData) { }

        public virtual void OnPointerDown(PointerEventData eventData) { }

        public virtual void OnPointerUp(PointerEventData eventData) { }
    }
}