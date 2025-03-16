using System.Collections;
using UnityEngine;

namespace _Game.ChuongScripts
{
    public class Movement
    {
        public bool isMoving;

        public IEnumerator IEMove(Transform transform, Vector2 target, float timeMove)
        {
            isMoving = true;
            Vector2 startPosition = transform.position;
            Vector2 targetPosition = target;
            
            float elapsedTime = 0;

            while (elapsedTime < timeMove)
            {
                transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / timeMove);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
            isMoving = false;
        }
    }
}