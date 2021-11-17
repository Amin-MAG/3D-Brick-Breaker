using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    private bool isStarted = false;
    public UnityEvent onGameOver;

    public BallController ballController;

    void Awake()
    {
        onGameOver = new UnityEvent();
    }

    private void Update()
    {
        // Reload Game
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isStarted = false;
        }

        // Start the game
        if (Input.GetKey(KeyCode.Space) && !isStarted)
        {
            isStarted = true;
            ballController.kickBall();
        }
    }
}