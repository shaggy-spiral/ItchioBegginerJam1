using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    public float startTime = 5.0f;
    private float remainingTime;
    TextMeshProUGUI timerText;
    GameLogic gameLogic;
    FloatingTextManager floatingTextManager;
    GameObject player;
    void Awake()
    {     
        gameLogic = GameObject.Find("GameGlobal").GetComponent<GameLogic>();
        if (gameLogic == null)
        {
            Debug.Log("Error: <gameLogic> not found!");
        }
        timerText = GetComponent<TextMeshProUGUI>();
        if (timerText == null)
        {
            Debug.Log("Error: <timerText> not found!");
        }
        floatingTextManager = GameObject.Find("FloatingTextManager").GetComponent<FloatingTextManager>();
        if (floatingTextManager == null)
        {
            Debug.Log("Error: <floatingTextManager> not found!");
        }
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("Error: <player> not found!");
        }
    }
    void Start()
    {
        remainingTime = startTime;
        DisplayTime();
    }

    public void ResetTimer()
    {
        remainingTime = startTime;
        DisplayTime();
    }
    void Update()
    {
        if (gameLogic.isRunning)
        {
            remainingTime -= Time.deltaTime;
            // Level lose
            if (remainingTime < 0)
            {
                floatingTextManager.CreateText(player.transform.position, "Too cold!", Color.magenta);
                gameLogic.isRunning = false;
                gameLogic.PreviousLevel();
            }
            DisplayTime();
        }
    }

    void DisplayTime()
    {
        int seconds = Mathf.FloorToInt(remainingTime);        
        int decimals = Mathf.RoundToInt((remainingTime - seconds) * 100);
        timerText.text = string.Format("{0:0}:{1:00}", seconds, decimals);
    }

    public int RemainingSeconds()
    {
        return Mathf.FloorToInt(remainingTime);
    }
}
