using Kartsan.ManalotGamesTest.Data;
using UnityEngine;

namespace Kartsan.ManalotGamesTest.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettingsScriptableObject;
        [Space]
        [SerializeField] private InjectableManager[] _managers;

        private GameProcessData _gameProcessData;

        private void Start()
        {
            _gameProcessData = new GameProcessData();

            foreach (var manager in _managers) manager.Inject(_gameSettingsScriptableObject);
        }
    }
}