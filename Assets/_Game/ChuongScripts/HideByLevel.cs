using System;
using ChuongCustom;
using UnityEngine;

namespace _Game.ChuongScripts
{
    public class HideByLevel : MonoBehaviour
    {
        public int level;
        
        private void Start()
        {
            gameObject.SetActive(level <= Data.Player.level);
        }
    }
}