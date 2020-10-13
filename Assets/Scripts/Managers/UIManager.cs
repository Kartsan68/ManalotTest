using Kartsan.ManalotGamesTest.Data;
using Kartsan.ManalotGamesTest.UI;
using Kartsan.ManalotGamesTest.WorldEntities;
using UnityEngine;
using UnityEngine.UI;

namespace Kartsan.ManalotGamesTest.Managers
{
    public class UIManager : InjectableManager
    {
        [SerializeField] private Transform _plantsCounterIconTransform;
        [SerializeField] private LimitedCounter _bedCounter;
        [SerializeField] private UsualCounter _wheatCounter;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private DraggableUIElement[] _draggableUIElements;

        public override void Inject(GameSettings gameSettings)
        {
            base.Inject(gameSettings);

            foreach (var element in _draggableUIElements) element.Inject(_canvas.scaleFactor);

            _bedCounter.SetMaximumValue(gameSettings.MaximumBedCount);

            GameProcessData.Instance.PlantsCounterIconTransform = _plantsCounterIconTransform;
        }

        protected override void SubscribeToEvents()
        {
            GameField.OnSetBedAction += BedSet;
            Plant.OnPickedUpPlantAction += PickUpPlant;
        }


        protected override void UnsubscribeToEvents()
        {
            GameField.OnSetBedAction -= BedSet;
            Plant.OnPickedUpPlantAction -= PickUpPlant;
        }

        private void BedSet() => _bedCounter.Increase(1);

        private void PickUpPlant(PlantsType type, int count) => _wheatCounter.Increase(count);
    }
}