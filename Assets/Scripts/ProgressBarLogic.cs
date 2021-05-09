using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarLogic : MonoBehaviour
{

    Slider slider;
    ParticleSystem particleSys;
    private float targetProgress = 0.0f;
    [SerializeField] public float fillSpeed = 1.0f;

    void  Awake()
    {
        slider = GetComponent<Slider>();
        if (slider == null)
        {
            Debug.Log("Error: <Slider> not found!");
        }
        particleSys = GameObject.Find("ParticleEffect").GetComponent<ParticleSystem>();
        if (particleSys == null)
        {
            Debug.Log("Error: <ParticleSystem> not found!");
        }
    }
    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 100;
    }

    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
            if (!particleSys.isPlaying)
            {
                particleSys.Play();
            }
            else
            {
                particleSys.Stop();
            }
        }
        
    }

    public void IncrementSlider(float increment)
    {
        targetProgress = slider.value + increment;    
        Debug.Log(targetProgress);
    }
}
