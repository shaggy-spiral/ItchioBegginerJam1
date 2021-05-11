using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBarLogic : MonoBehaviour
{

    Slider slider;
    ParticleSystem particleSys;
    GameLogic gameLogic;
    
    private float targetProgress;
    [SerializeField] public float fillSpeed = 1.0f;

    void Awake()
    {

        gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
        if (gameLogic == null)
        {
            Debug.Log("Error: <GameLogic> not found!");
        } 
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
        slider.value = 0;
        slider.maxValue = gameLogic.levelObjective;
        
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

    public void IncrementSlider(int increment)
    {
        targetProgress = slider.value + increment;    
        Debug.Log("Slider value: " + slider.value);

    }

    public void ChangeLevel()
    {
        slider.minValue = 0;
        slider.maxValue = gameLogic.levelObjective;
        slider.value = 0;
        targetProgress = 0;
        gameLogic.currentHeatLevel = 0;
        Debug.Log("Min value: " + slider.minValue);
        Debug.Log("Max value: " + slider.maxValue);
        Debug.Log("Slider value: " + slider.value);
    }
}
