using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;
using UnityEngine.UI;

public class KnifeGroup : Singleton<KnifeGroup>
{
    [SerializeField] private Image knifeImage;
    
    public void ShowKnife(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(knifeImage, transform);
        }
    }

    public void RemoveKnife()
    {
        if (transform.childCount <= 0) return;
        Destroy(GetComponentInChildren<Image>().gameObject);
    }
}
