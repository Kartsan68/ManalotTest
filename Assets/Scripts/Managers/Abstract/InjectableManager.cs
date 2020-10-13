using Kartsan.ManalotGamesTest.Data;
using UnityEngine;

namespace Kartsan.ManalotGamesTest.Managers
{
    public abstract class InjectableManager : MonoBehaviour
    {
        protected GameSettings gameSettings;

        public virtual void Inject(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }

        protected abstract void SubscribeToEvents();

        protected abstract void UnsubscribeToEvents();

        private void OnEnable() => SubscribeToEvents();

        private void OnDisable() => UnsubscribeToEvents();
    }
}