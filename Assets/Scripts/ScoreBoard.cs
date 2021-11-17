using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public GameEvents gameEvents;

    void Start()
    {
        gameEvents.onScoreChange.AddListener(updateScore);
    }

    void updateScore()
    {
        this.gameObject.GetComponent<TextMesh>().text = "Score: " + gameEvents.playerScore;
    }
}