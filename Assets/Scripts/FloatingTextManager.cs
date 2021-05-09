using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textPrefab;
    public RectTransform canvasTransform;
    // Singleton pattern here
    private static FloatingTextManager instance;

    public static FloatingTextManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<FloatingTextManager>();        
            }
            return instance;
        }
    }

    public void CreateText(Vector3 position)
    {
        GameObject newText = (GameObject)Instantiate(textPrefab, position, Quaternion.identity);
        newText.transform.SetParent(canvasTransform);

    }
}
