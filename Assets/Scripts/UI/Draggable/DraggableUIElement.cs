using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Kartsan.ManalotGamesTest.Data;

namespace Kartsan.ManalotGamesTest.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class DraggableUIElement : DraggableElement
    {
        public static Action<ActualActionType> OnBeginDragAction;
        public static Action<ActualActionType> OnEndDragAction;

        [SerializeField] protected ActualActionType elementAction;

        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private float _canvasScaleFactor;

        public void Inject(float canvasScaleFactor) => _canvasScaleFactor = canvasScaleFactor;

        public override void OnBeginDrag(PointerEventData eventData)
        {
            basePosition = _rectTransform.anchoredPosition;
            _canvasGroup.blocksRaycasts = false;
            OnBeginDragAction?.Invoke(elementAction);
        }

        public override void OnDrag(PointerEventData eventData) => _rectTransform.anchoredPosition += eventData.delta / _canvasScaleFactor;

        public override void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            _rectTransform.anchoredPosition = basePosition;
            OnEndDragAction?.Invoke(elementAction);
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }
}