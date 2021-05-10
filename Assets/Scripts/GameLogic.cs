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
    void Awake()
    {
        currentLevel = minLevel;
        currentHeatLevel = 0;
        
    }

    void Update()
    {
        
    }

    void CalculateObjective(int level)
    {
        float formulaValue = 9.0f * Mathf.Pow(1.08f, (float)level);
        levelObjective = Mathf.FloorToInt(formulaValue);
    }

    void nextLevel()
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
            BroadcastMessage("ChangeLevel");
            //TODO: reset timer
        }
    }
}
