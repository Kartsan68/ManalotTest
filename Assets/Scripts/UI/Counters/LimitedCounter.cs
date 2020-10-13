using UnityEngine;

namespace Kartsan.ManalotGamesTest.UI
{
    public class LimitedCounter : UsualTextCounter
    {
        [SerializeField] private string _separator;

        private int _maximumValue;

        public void SetMaximumValue(int value)
        {
            _maximumValue = value;
            SetCountText();
        }

        protected override void SetCountText()
        {
            count = count < _maximumValue ? count : _maximumValue;

            _counterTextField.text = string.Format("{0}{1}{2}", count, _separator, _maximumValue);
        }
    }
}