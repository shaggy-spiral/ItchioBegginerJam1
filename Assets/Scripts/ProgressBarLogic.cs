using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarLogic : MonoBehaviour
{

    Slider slider;

    void  Awake()
    {
        slider = GetComponent<Slider>();
        if (slider == null)
        {
            Debug.Log("Error: <Slider> not found!");
        }
    }
    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 100;
    }

    void Update()
    {
        
    }

    public void IncrementSlider(float increment)
    {
        slider.value += increment;
        Debug.Log(slider.value);
    }
}
