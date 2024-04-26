using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartgame : MonoBehaviour
{
    public void startBtn()
    {
        SceneManager.LoadScene("menu");
    }

    public void quitBtn()
    {
        Application.Quit();
    }

}