using Kartsan.ManalotGamesTest.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Kartsan.ManalotGamesTest.UI
{
    public class DraggablePlantUIElement : DraggableUIElement
    {
        [SerializeField] private PlantsType _plantType;

        public override void OnBeginDrag(PointerEventData eventData)
        {
            GameProcessData.Instance.ActualPlantType = _plantType;
            base.OnBeginDrag(eventData);
        }


        public override void OnEndDrag(PointerEventData eventData)
        {
            GameProcessData.Instance.ActualPlantType = PlantsType.none;
            base.OnEndDrag(eventData);
        }
    }
}