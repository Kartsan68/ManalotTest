using UnityEngine;
using UnityEngine.UI;

namespace Kartsan.ManalotGamesTest.UI
{
    public class UsualTextCounter : UsualCounter
    {
        [SerializeField] protected Text _counterTextField;

        public override void SetValue(int value)
        {
            base.SetValue(value);
            SetCountText();
        }

        public override void Increase(int value)
        {
            base.Increase(value);
            SetCountText();
        }

        public override void Decrease(int value)
        {
            base.Decrease(value);
            SetCountText();
        }

        protected virtual void SetCountText() => _counterTextField.text = count.ToString();
    }
}