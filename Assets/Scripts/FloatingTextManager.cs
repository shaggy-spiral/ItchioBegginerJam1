using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float fadeTime = 1.0f;
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

    public void CreateText(Vector3 position, string text, Color color)
    {
        GameObject newText = (GameObject)Instantiate(textPrefab, position, Quaternion.identity);
        newText.transform.SetParent(canvasTransform);
        newText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newText.GetComponent<FloatingText>().Initialize(speed, direction, fadeTime);
        newText.GetComponent<Text>().text = text;
        newText.GetComponent<Text>().color = color;
    }
}
