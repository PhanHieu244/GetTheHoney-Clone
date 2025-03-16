using System;
using ChuongCustom;
using UnityEngine;

namespace _Game.ChuongScripts
{
    public class Honey : Singleton<Honey>
    {
        public Slicing slicing;


        private void OnValidate()
        {
            slicing = GetComponentInChildren<Slicing>();
        }
    }
}