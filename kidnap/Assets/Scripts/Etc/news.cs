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

    void Start()
    {
        Rect = transform.GetComponent<RectTransform>();
        Destroy(gameObject, DeleteTime);
    }

    void Update()
    {
        
            Rect.Translate(Vector2.left * moveSpeed1);
       
        
    }
}
