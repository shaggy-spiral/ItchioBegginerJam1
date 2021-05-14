using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickLogic : MonoBehaviour
{
    public float speed = 5.0f;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);        
        if (spriteRenderer.isVisible == false)
        {
            Destroy(gameObject);
        }
    }
}