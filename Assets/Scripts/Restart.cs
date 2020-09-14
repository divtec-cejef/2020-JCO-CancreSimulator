using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    GameManager gameManager;

    public void RestartGame()
    {
        pointeurController.lastColorIndex = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.timerIsRunning = false;
        SceneManager.LoadScene("Game");   
    }
}
