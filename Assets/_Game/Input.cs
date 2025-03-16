using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game
{
    public class Input : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Player.Instance.Throw();
        }
    }
}