using System;
using UnityEngine;

namespace _Game
{
    public static class Fill
    {
        public static event Action<float> OnFillChange;
        private static float _fill;

        public static float fill
        {
            get => _fill;
            set
            {
                value = Mathf.Min(1f, value);
                _fill = value;
                OnFillChange?.Invoke(value);
            }
        }
    }
}