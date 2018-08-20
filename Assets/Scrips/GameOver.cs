using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverText;
    public static bool gameOver;

    private void Start()
    {
        gameOver = false;
        gameOverText.SetActive(false);
    }

    private void Update()
    {
        if (gameOver == true)
        {
            gameOverText.SetActive(true);
            BallController.ForwardPower = 0;
        }
    }
}
