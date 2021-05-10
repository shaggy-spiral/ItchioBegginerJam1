using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenLogic : MonoBehaviour
{
    ProgressBarLogic progressBar;
    GameLogic gameLogic;
    private int incrementValue = 1;
    void Awake()
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
        if (gameLogic == null)
        {
            Debug.Log("Error: <GameLogic> not found!");
        } 
        // Test startingLevel        
        Debug.Log("I'm in level: " + gameLogic.currentLevel);
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
            gameLogic.currentHeatLevel += incrementValue;
            progressBar.IncrementSlider(incrementValue);
            FloatingTextManager.Instance.CreateText(transform.position, incrementValue.ToString(), Color.white);
            
        }
    }

    
}
