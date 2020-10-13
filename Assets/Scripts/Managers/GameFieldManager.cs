using UnityEngine;
using Kartsan.ManalotGamesTest.UI;
using Kartsan.ManalotGamesTest.Data;
using Kartsan.ManalotGamesTest.WorldEntities;

namespace Kartsan.ManalotGamesTest.Managers
{
    public class GameFieldManager : InjectableManager
    {
        [SerializeField] private Transform _grid;
        [SerializeField] private GameFieldData _tileData;

        private GameField _actualGameField;

        public override void Inject(GameSettings gameSettings)
        {
            base.Inject(gameSettings);

            _actualGameField = Instantiate(gameSettings.ActualGameField, _grid);
            _actualGameField.Inject(_tileData);
        }

        protected override void SubscribeToEvents()
        {
            DraggableUIElement.OnBeginDragAction += OnBeginDrag;
            DraggableUIElement.OnEndDragAction += OnEndDrag;
        }

        protected override void UnsubscribeToEvents()
        {
            DraggableUIElement.OnBeginDragAction -= OnBeginDrag;
            DraggableUIElement.OnEndDragAction -= OnEndDrag;
        }

        private void OnBeginDrag(ActualActionType actualActionType)
        {
            GameProcessData.Instance.ActualAction = actualActionType;
        }

        private void OnEndDrag(ActualActionType actualActionType)
        {
            DropCheck(actualActionType);
            GameProcessData.Instance.ActualAction = ActualActionType.none;
        }

        private void DropCheck(ActualActionType actualActionType)
        {
            if (GameProcessData.Instance.ActualBedCount < gameSettings.MaximumBedCount && actualActionType.Equals(ActualActionType.SetBed))
                _actualGameField.SetBed();

            _actualGameField.ResetHighlighting();
        }
    }
}