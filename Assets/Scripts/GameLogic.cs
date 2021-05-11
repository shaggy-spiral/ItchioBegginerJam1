using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public int currentLevel;
    public int levelObjective;
    public int currentHeatLevel;
    public int maxPlayedLevel;
    public const int minLevel = 1;
    public const int maxLevel = 530;
    ProgressBarLogic progressBar;
    TextMeshProUGUI levelText;
    GameObject nextLevel;
    GameObject previousLevel;
    ChickAnimationScript chickAnimationScript;
    
    void Awake()
    {
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBarLogic>();
        if (progressBar == null)
        {
            Debug.Log("Error: <ProgressBar> not found!");
        }
        levelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<TextMeshProUGUI>();
        if (levelText == null)
        {
            Debug.Log("Error: <LevelText> not found!");
        }
        nextLevel = GameObject.Find("NextLevel");
        if (nextLevel == null)
        {
            Debug.Log("Error: <NextLevel> not found!");
        }
        previousLevel = GameObject.Find("PreviousLevel");
        if (previousLevel == null)
        {
            Debug.Log("Error: <previousLevel> not found!");
        }
        chickAnimationScript = GameObject.Find("ChickAnimation").GetComponent<ChickAnimationScript>();
        currentLevel = minLevel;
        maxPlayedLevel = currentLevel;
        UpdateGameScreen();   


    }

    void Update()
    {
        if (currentHeatLevel >= levelObjective)
        {
            Debug.Log("Next Level!");
            NextLevel();
        }
    }

    void CalculateObjective(int level)
    {
        float formulaValue = 9.0f * Mathf.Pow(1.08f, (float)level);
        levelObjective = Mathf.FloorToInt(formulaValue);
    }

    public void NextLevel()
    {
        if (currentLevel >= maxLevel)
        {
            Debug.Log("Maximum level achieved!");
        }
        else
        {              
            currentLevel++;
            if (currentLevel > maxPlayedLevel)
            {
                maxPlayedLevel++;
            }
            CalculateObjective(currentLevel);            
            UpdateGameScreen();
            chickAnimationScript.CreateChick();       
        }
    }

    public void PreviousLevel()
    {
        Debug.Log("clicked previous level");
        if (currentLevel > minLevel)
        {
            currentLevel--;
            
            UpdateGameScreen();
        } 
        else 
        {
            Debug.Log("Already at minimum level");
        }
    }

    void UpdateGameScreen()
    {
        CalculateObjective(currentLevel);
        currentHeatLevel = 0;
        progressBar.ChangeLevel();
        levelText.text = "Level: " + currentLevel;
        if (currentLevel == minLevel)
        {
            previousLevel.SetActive(false);
        }
        else
        {
            previousLevel.SetActive(true);
        }
        if (currentLevel == maxPlayedLevel)
        {
            nextLevel.SetActive(false);
        }
        else
        {
            nextLevel.SetActive(true);
        }
    }
}