using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenLogic : MonoBehaviour
{
    ProgressBarLogic progressBar;
    private float incrementValue = 1.0f;
    void Awake()
    {
        Debug.Log("Bóque bóque!");
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBarLogic>();
        if (progressBar == null)
        {
            Debug.Log("Error: <progressBar> not found!");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            progressBar.IncrementSlider(incrementValue);
            FloatingTextManager.Instance.CreateText(transform.position, incrementValue.ToString(), Color.white);
        }
    }
}
