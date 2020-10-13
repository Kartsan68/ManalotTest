using UnityEngine;
using UnityEngine.Tilemaps;
using Kartsan.ManalotGamesTest.Data;
using System;

namespace Kartsan.ManalotGamesTest.WorldEntities
{
    public class GameField : MonoBehaviour
    {
        public static Action OnSetBedAction;

        private GameFieldData _gameFieldData;
        private Camera _camera;
        private TileGrid _tileGrid;

        public void Inject(GameFieldData gameTiles) => _gameFieldData = gameTiles;

        public void SetBed() => _tileGrid.SetBedToPosition(_gameFieldData.BedTile, GetTouchPosition(), OnSetBedAction);

        public void Planting()
        {
            var plantType = GameProcessData.Instance.ActualPlantType;

            if (plantType.Equals(PlantsType.none)) return;

            _tileGrid.PutInCell(GetTouchPosition(), _gameFieldData.GetPlantByType(plantType));
        }

        public void PickUpHarvest() => _tileGrid.PickUpPlant(GetTouchPosition());

        public void ResetHighlighting() => _tileGrid.ResetAllHighlighting();

        private void Awake()
        {
            _camera = Camera.main;
            _tileGrid = new TileGrid(GetComponent<Tilemap>());
        }

        private void OnMouseOver() => CheckCellsOnDrag();

        private void OnMouseExit() => ResetHighlighting();

        private void CheckCellsOnDrag()
        {
            switch (GameProcessData.Instance.ActualAction)
            {
                case ActualActionType.Planting:
                    Planting();
                    break;
                case ActualActionType.PickUpHarvest:
                    PickUpHarvest();
                    break;
                default:
                    _tileGrid.HighlightCell(GetTouchPosition());
                    break;
            }
        }

        private Vector3 GetTouchPosition() => _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}