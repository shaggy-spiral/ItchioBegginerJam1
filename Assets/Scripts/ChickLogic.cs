using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickLogic : MonoBehaviour
{
    public float speed = 5.0f;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("Chick position: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);        
        if (spriteRenderer.isVisible == false)
        {
            Destroy(gameObject);
        }
    }
}