using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroGameLogic : MonoBehaviour
{
    public void PlayButtonClick()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
