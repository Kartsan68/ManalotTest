using UnityEngine;

namespace Kartsan.ManalotGamesTest.UI
{
    public abstract class UsualCounter : MonoBehaviour
    {
        protected int count;

        public virtual void SetValue(int value) => count = value;

        public virtual void Increase(int value) => count += value;

        public virtual void Decrease(int value) => count -= value;

        private void Awake() => count = 0;
    }
}