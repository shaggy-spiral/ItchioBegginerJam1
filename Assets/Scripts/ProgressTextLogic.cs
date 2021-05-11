using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTextLogic : MonoBehaviour
{
    GameLogic gameLogic;
    void Awake()
    {
        gameLogic = GameObject.Find("GameGlobal").GetComponent<GameLogic>();
        if (gameLogic == null)
        {
            Debug.Log("Error: <GameLogic> not found!");
        }
        gameObject.GetComponent<Text>().text = "";
        UpdateText();
    }

    void Start()
    {
        UpdateText();
    }

    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        gameObject.GetComponent<Text>().text = gameLogic.currentHeatLevel + "/" + gameLogic.levelObjective;
    }
}
