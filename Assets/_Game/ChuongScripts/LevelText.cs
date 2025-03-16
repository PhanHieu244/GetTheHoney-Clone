using ChuongCustom;
using TMPro;
using UnityEngine;

namespace _Game.ChuongScripts
{
    public class LevelText : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        [SerializeField] private string prefix;
        [SerializeField] private float add = 1;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            Show();
        }

        private void Show(int value = 0)
        {
            _text.SetText( prefix + " " + (Data.Player.level + add));
        }
    }
}