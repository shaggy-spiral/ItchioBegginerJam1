using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int currentLevel;
    public int levelObjective;
    public int currentHeatLevel;
    public int maxPlayedLevel;
    public const int minLevel = 1;
    public const int maxLevel = 530;
    ProgressBarLogic progressBar;
    void Awake()
    {
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBarLogic>();
        currentLevel = minLevel;
        currentHeatLevel = 0;
        CalculateObjective(currentLevel);
        
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

    void NextLevel()
    {
        if (currentLevel >= maxLevel)
        {
            Debug.Log("Maximum level achieved!");
        }
        else
        {
            currentHeatLevel = 0;
            currentLevel += 1;
            CalculateObjective(currentLevel);
            //BroadcastMessage("ChangeLevel");
            progressBar.ChangeLevel();
            //TODO: reset timer
        }
    }
}
