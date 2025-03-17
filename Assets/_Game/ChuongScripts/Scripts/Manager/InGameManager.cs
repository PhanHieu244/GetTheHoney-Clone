
using Sirenix.OdinInspector;
using UnityEngine;

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
            FirebaseInit.Instance.Log("Ingame", "win", 1);
            Manager.ScreenManager.OpenScreen(ScreenType.Result);
            //todo:
        }

        [Button]
        public void Lose()
        {
            FirebaseInit.Instance.Log("Ingame", "lose", 1);
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