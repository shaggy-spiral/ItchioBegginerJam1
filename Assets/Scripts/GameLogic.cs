using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Numerics;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public int currentLevel;
    public BigInteger levelObjective;
    public BigInteger currentHeatLevel;
    public int maxPlayedLevel;
    public const int minLevel = 1;
    public const int maxLevel = 530;
    public bool isRunning;
    public bool isPaused;
    public BigInteger eggCoin;
    public int upgradeLevel;
    BigInteger upgradeCost;
    ProgressBarLogic progressBar;
    TextMeshProUGUI levelText;
    TextMeshProUGUI eggCoinText;
    GameObject nextLevel;
    GameObject previousLevel;
    GameObject upgradeButton;
    ChickAnimationScript chickAnimationScript;
    TimerScript timerScript;
    ChickenLogic chickenLogic;
    SpriteRenderer pauseOverlay;
    GameObject exitButton;
    
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
        timerScript = GameObject.Find("Timer").GetComponent<TimerScript>();
        if (timerScript == null)
        {
            Debug.Log("Error: <timerScript> not found!");
        }
        eggCoinText = GameObject.Find("EggCoin").GetComponent<TextMeshProUGUI>();
        if (eggCoinText == null)
        {
            Debug.Log("Error: <eggCoinText> not found!");
        }
        upgradeButton = GameObject.Find("Upgrade");
        if (upgradeButton == null)
        {
            Debug.Log("Error: <upgradeButton> not found!");
        }
        chickenLogic = GameObject.FindWithTag("Player").GetComponent<ChickenLogic>();
        if (chickenLogic == null)
        {
            Debug.Log("Error: <chickenLogic> not found!");
        }
        pauseOverlay = GameObject.Find("PauseOverlay").GetComponent<SpriteRenderer>();
        if (pauseOverlay == null)
        {
            Debug.Log("Error: <pauseOverlay> not found!");
        }
        exitButton = GameObject.Find("ExitButton");
        if (exitButton == null)
        {
            Debug.Log("Error: <exitButton> not found!");
        }
        else
        {
            exitButton.SetActive(false);
        }
        chickAnimationScript = GameObject.Find("ChickAnimation").GetComponent<ChickAnimationScript>();
        InitGame();
    }

    void Update()
    {
        if (currentHeatLevel >= levelObjective)
        {            
            NextLevel();
            chickAnimationScript.CreateChick(); 
        }
        if (eggCoin >= upgradeCost)
        {
            upgradeButton.SetActive(true);
            upgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "WARMER FEATHERS\n" + "(" + upgradeCost + ")";
        }
        else
        {
            upgradeButton.SetActive(false);
        }
        HandleInput();
    }

    void CalculateObjective(int level)
    {
        // Next level eggCoin cost
        float formulaValue = 9.0f * Mathf.Pow(1.07f, (float)level);
        levelObjective = Mathf.FloorToInt(formulaValue);
    }

    public void NextLevel()
    {
        if (!isPaused)
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
                // simple reward formula Level x time in seconds to 0
                int reward = currentLevel * timerScript.RemainingSeconds(); 
                addEggCoin(reward);
                UpdateGameScreen();  
            }
        }
    }

    public void PreviousLevel()
    {
        if (!isPaused)
        {
            if (currentLevel > minLevel)
            {
                currentLevel--;            
                UpdateGameScreen();
            } 
            else 
            {
                UpdateGameScreen();
            }
        }
    }

    void UpdateGameScreen()
    {
        CalculateObjective(currentLevel);
        currentHeatLevel = 0;
        progressBar.ChangeLevel();
        levelText.text = "Level: " + currentLevel;
        eggCoinText.text = "EggCoin: " + eggCoin;
        timerScript.ResetTimer();
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

    void addEggCoin(BigInteger ammount)
    {
        eggCoin += ammount;
    }

    void spendEggCoin(BigInteger ammount)
    {
        eggCoin -= ammount;
    }

    public void ClickBuyUpgrade()
    {
        if (!isPaused)
        {
            upgradeLevel += 1;
            chickenLogic.UpgradeFeathers(upgradeLevel);
            spendEggCoin(upgradeCost);
            upgradeCost = CalculateNextUpgrade(upgradeLevel);
            UpdateGameScreen();
        }
    }

    BigInteger CalculateNextUpgrade(int level)
    {
        //BigInteger cost = 10 * (int)Mathf.Pow(1.1f, upgradeLevel);
        BigInteger cost = 8 * (int)Mathf.Pow(upgradeLevel, 2);
        return cost;
    }

    void InitGame()
    {
        currentLevel = minLevel;
        maxPlayedLevel = currentLevel;
        eggCoin = 0;
        upgradeLevel = 1;
        upgradeCost = CalculateNextUpgrade(upgradeLevel);
        isRunning = false;
        isPaused = false;
        UpdateGameScreen();   
    }

    void HandleInput()
    {
        if (!isPaused)
        {
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && currentLevel >= minLevel)
                PreviousLevel();
            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && currentLevel < maxPlayedLevel)
                NextLevel();
            if (Input.GetKeyDown(KeyCode.Space) && upgradeButton.activeInHierarchy)
                ClickBuyUpgrade();
        }
    }

    public void PauseClick()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseOverlay.enabled = true;
            exitButton.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseOverlay.enabled = false;
            exitButton.SetActive(false);
        }
    }

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("IntroScreen");
    }

}