using Kartsan.ManalotGamesTest.WorldEntities;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kartsan.ManalotGamesTest.Data
{
    [CreateAssetMenu(fileName = "GameFieldData", menuName = "ScriptableObjects/GameFieldDataScriptableObject")]
    public class GameFieldData : ScriptableObject
    {
        [SerializeField] public TileBase BedTile;
        [SerializeField] public TileBase GrassTile;
        [Space]
        [SerializeField] public Plant[] _plants;

        public Plant GetPlantByType(PlantsType type)
        {
            foreach (var plant in _plants)
                if (plant.GetPlantsType.Equals(type)) return plant;

            Debug.LogFormat("Plant by type {0} is not found", type.ToString());
            return null;
        }
    }
}