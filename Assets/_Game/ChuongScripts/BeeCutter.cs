using UnityEngine;
using System.Collections.Generic;
using UnitySpriteCutter;

[RequireComponent(typeof(LineRenderer))]
public class BeeCutter : MonoBehaviour
{
    public int cutCount;
    public LayerMask layerMask;

    Vector2 mouseStart;


    public void Cut(float x, GameObject go, out SpriteCutterOutput output)
    {
        output = SpriteCutter.Cut(new SpriteCutterInput()
        {
            lineStart = new Vector2(x, -100f),
            lineEnd = new Vector2(x, 100f),
            gameObject = go,
            gameObjectCreationMode = SpriteCutterInput.GameObjectCreationMode.CUT_OFF_ONE,
        });

        if (output != null && output.secondSideGameObject != null)
        {
            Rigidbody2D newRigidbody = output.secondSideGameObject.AddComponent<Rigidbody2D>();
            newRigidbody.velocity = output.firstSideGameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }
    
    void LinecastCut(Vector2 lineStart, Vector2 lineEnd, int layerMask = Physics2D.AllLayers)
    {
        List<GameObject> gameObjectsToCut = new List<GameObject>();
        RaycastHit2D[] hits = Physics2D.LinecastAll(lineStart, lineEnd, layerMask);
        foreach (RaycastHit2D hit in hits)
        {
            if (HitCounts(hit))
            {
                cutCount--;
                gameObjectsToCut.Add(hit.transform.gameObject);
            }
        }

        foreach (GameObject go in gameObjectsToCut)
        {
            SpriteCutterOutput output = SpriteCutter.Cut(new SpriteCutterInput()
            {
                lineStart = lineStart,
                lineEnd = lineEnd,
                gameObject = go,
                gameObjectCreationMode = SpriteCutterInput.GameObjectCreationMode.CUT_OFF_ONE,
            });

            if (output != null && output.secondSideGameObject != null)
            {
                Rigidbody2D newRigidbody = output.secondSideGameObject.AddComponent<Rigidbody2D>();
                newRigidbody.velocity = output.firstSideGameObject.GetComponent<Rigidbody2D>().velocity;
            }
        }
    }

    bool HitCounts(RaycastHit2D hit)
    {
        return (hit.transform.GetComponent<SpriteRenderer>() != null ||
                hit.transform.GetComponent<MeshRenderer>() != null);
    }
}