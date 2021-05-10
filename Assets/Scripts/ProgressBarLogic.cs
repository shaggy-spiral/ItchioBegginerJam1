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

    public void IncrementSlider(float increment)
    {
        targetProgress = slider.value + increment;    
        
    }

    private void ChangeLevel()
    {
        slider.minValue = 0;
        slider.maxValue = gameLogic.levelObjective;

    }
}
