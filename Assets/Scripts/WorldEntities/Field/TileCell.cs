using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kartsan.ManalotGamesTest.WorldEntities
{
    public class TileCell
    {
        private Bed _actualBed;
        private Transform _tilemapTransform;
        private Tilemap _cellTilemap;
        private Vector3Int _cellTilePosition;

        public TileCell(Vector3Int cellPosition, in Tilemap tilemap)
        {
            _tilemapTransform = tilemap.transform;
            _cellTilemap = tilemap;
            _cellTilePosition = cellPosition;

            var cellCenterPosition = _cellTilemap.GetCellCenterLocal(_cellTilePosition);
            _actualBed = new Bed(cellCenterPosition, _tilemapTransform);
        }

        public void SetBed(TileBase tile, Action onSet)
        {
            if (_actualBed.IsActive) return;

            _actualBed.DestroyGrass();
            _cellTilemap.SetTile(_cellTilePosition, tile);
            Data.GameProcessData.Instance.ActualBedCount++;
            onSet?.Invoke();
        }

        public void PutInBed(Plant plant)
        {
            if (!_actualBed.IsActive || !_actualBed.IsFree) return;

            _actualBed.SetPlant(plant);
        }

        public void PickUpPlant()
        {
            if (!_actualBed.IsActive || _actualBed.IsFree) return;

            _actualBed.PickUpPlant();
        }
    }
}