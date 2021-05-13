using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

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
        slider.maxValue = 1;
    }

    public void IncrementSlider(BigInteger increment)
    {
        float incrementRatioNoIncrement = (float)((double)(gameLogic.currentHeatLevel) / (double)gameLogic.levelObjective);
        float incrementRatioWithIncrement = (float)((double)(gameLogic.currentHeatLevel + increment) / (double)gameLogic.levelObjective);
        targetProgress = slider.value + (incrementRatioWithIncrement - incrementRatioNoIncrement);
        slider.value += (incrementRatioWithIncrement - incrementRatioNoIncrement);       
    }

    public void ChangeLevel()
    {
        slider.value = 0;
        targetProgress = 0;
        gameLogic.currentHeatLevel = 0;
        Debug.Log("Min value: " + slider.minValue);
        Debug.Log("Max value: " + slider.maxValue);        
    }
}
