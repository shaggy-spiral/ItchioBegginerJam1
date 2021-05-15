using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class ChickenLogic : MonoBehaviour
{
    ProgressBarLogic progressBar;
    GameLogic gameLogic;
    private BigInteger incrementValue;
    void Awake()
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
        if (gameLogic == null)
        {
            Debug.Log("Error: <GameLogic> not found!");
        } 
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBarLogic>();
        if (progressBar == null)
        {
            Debug.Log("Error: <progressBar> not found!");
        }
    }
    void Start()
    {
        incrementValue = 1;
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (gameLogic.isPaused)
            {
                return;
            }
            else
            {
                gameLogic.isRunning = true;
                gameLogic.currentHeatLevel += incrementValue;
                progressBar.IncrementSlider(incrementValue);
                FloatingTextManager.Instance.CreateText(transform.position, incrementValue.ToString(), Color.white);
            }
        }
    }

    public void UpgradeFeathers(int upgradeLevel)
    {
        // Upgrade incremental value formula
        incrementValue += gameLogic.upgradeLevel;
    }
}
