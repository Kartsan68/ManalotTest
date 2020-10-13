using Kartsan.ManalotGamesTest.WorldEntities;
using UnityEngine;

namespace Kartsan.ManalotGamesTest.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettingsScriptableObject")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] public int MaximumBedCount;
        [SerializeField] public GameField ActualGameField;
    }
}