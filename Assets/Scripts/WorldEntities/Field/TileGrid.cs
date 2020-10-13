using Kartsan.ManalotGamesTest.Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kartsan.ManalotGamesTest.WorldEntities
{
    public class TileGrid
    {
        private Tilemap _tilemap;
        private Dictionary<string, TileCell> _allTileDictionary;

        public TileGrid(Tilemap tilemap)
        {
            _tilemap = tilemap;
            InitializeTileCells();
        }

        public void PutInCell(Vector3 worldPosition, Plant plant)
        {
            TileCell cellForPut = GetTileCellByPosition(worldPosition);

            if (cellForPut == null || plant == null) return;

            cellForPut.PutInBed(plant);
        }

        public void PickUpPlant(Vector3 worldPosition)
        {
            TileCell cellForPut = GetTileCellByPosition(worldPosition);

            if (cellForPut == null) return;

            cellForPut.PickUpPlant();
        }

        public void SetBedToPosition(TileBase bedTile, Vector3 worldPosition, Action onSet)
        {
            TileCell setCandidate = GetTileCellByPosition(worldPosition);

            if (setCandidate == null) return;

            setCandidate.SetBed(bedTile, onSet);
        }

        public void HighlightCell(Vector3 worldPosition)
        {
            if (GameProcessData.Instance.ActualAction != ActualActionType.none)
            {
                var cellPosition = _tilemap.WorldToCell(worldPosition);

                _tilemap.RefreshAllTiles();
                _tilemap.SetTileFlags(cellPosition, TileFlags.None);
                _tilemap.SetColor(cellPosition, Color.red);
            }
        }

        public void ResetAllHighlighting() => _tilemap.RefreshAllTiles();


        private void InitializeTileCells()
        {
            _allTileDictionary = new Dictionary<string, TileCell>();

            foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
            {
                Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);

                if (_tilemap.HasTile(cellPosition))
                    _allTileDictionary.Add(GetDictionaryKey(cellPosition), new TileCell(cellPosition, in _tilemap));
            }
        }

        private TileCell GetTileCellByPosition(Vector3 worldPosition)
        {
            var cellPosition = _tilemap.WorldToCell(worldPosition);
            var key = GetDictionaryKey(cellPosition);

            return _allTileDictionary.ContainsKey(key) ? _allTileDictionary[key] : null;
        }

        private string GetDictionaryKey(Vector3Int cellPosition) => string.Format("{0}{1}{2}", cellPosition.x, cellPosition.y, cellPosition.z);
    }
}
