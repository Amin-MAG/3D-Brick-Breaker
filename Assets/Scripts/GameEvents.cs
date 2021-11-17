using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public int playerScore = 0;
    public int lastDeltaScore = 0;

    private bool isStarted = false;
    public UnityEvent onGameOver;
    public UnityEvent onScoreChange;

    public FrontBoard frontBoard;
    public DescriptionBoard descriptionBoard;
    public ScoreBoard scoreBoard;

    public BallController ballController;

    void Awake()
    {
        onGameOver = new UnityEvent();
        onScoreChange = new UnityEvent();
    }

    private void Update()
    {
        // Reload Game
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            descriptionBoard.gameObject.GetComponent<TextMesh>().text = "";
            isStarted = false;
            playerScore = 0;
            lastDeltaScore = 0;
            this.onScoreChange.Invoke();
        }

        // Start the game
        if (Input.GetKey(KeyCode.Space) && !isStarted)
        {
            isStarted = true;
            ballController.kickBall();
            frontBoard.gameObject.GetComponent<TextMesh>().text = "";
            descriptionBoard.gameObject.GetComponent<TextMesh>().text = "";
        }
    }
}