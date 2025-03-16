using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChuongCustom
{
    public class InGameManager : Singleton<InGameManager>
    {
        [SerializeField] public int PriceToPrice = 1;

        private void Start()
        {
            ScoreManager.Reset();
        }

        [Button]
        public void Win()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.Result);
            //todo:
        }

        [Button]
        public void Lose()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.Lose);
            //todo:
        }

        [Button]
        public void BeforeLose()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.BeforeLose);
            //todo:
        }

        public void Retry()
        {
            //retry
            //todo:
        }

        public void Continue()
        {
            //continue

            //todo:
        }
    }
}