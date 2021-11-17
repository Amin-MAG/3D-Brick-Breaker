using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionBoard : MonoBehaviour
{
    public GameEvents gameEvents;

    void Start()
    {
        gameEvents.onScoreChange.AddListener(printAddedScore);
        gameEvents.onGameOver.AddListener(printResetHelper);
    }

    void printAddedScore()
    {
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<TextMesh>().text = "+" + gameEvents.lastDeltaScore;
        Invoke("disableBoard", 0.4f);
    }

    void disableBoard()
    {
        this.gameObject.SetActive(false);
    }

    void printResetHelper()
    {
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<TextMesh>().text = "Press Left Shift + R To Reset";
    }
}