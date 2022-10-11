using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class news : MonoBehaviour
{

    [SerializeField]
    float DeleteTime;

    [SerializeField]
    float moveSpeed1;

    RectTransform Rect;
    RectTransform rect2;

    void Start()
    {
        rect2 = transform.parent.transform.GetComponent<RectTransform>();
        Rect = transform.GetComponent<RectTransform>();
        Destroy(gameObject, DeleteTime);
    }

    void FixedUpdate()
    {
        if(Rect.anchoredPosition.x <= -rect2.rect.width)
        {
            Destroy(gameObject);
        }


        Rect.Translate(Vector2.left * moveSpeed1);
       
        
    }
}
