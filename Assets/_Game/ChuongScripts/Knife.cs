using System;
using UnityEngine;

namespace _Game.ChuongScripts
{
    public class Knife : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("bee"))
            {
                Player.Instance.ShowLose();
            }
        }
    }
}