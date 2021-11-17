using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBoard : MonoBehaviour
{
    public GameEvents gameEvents;

    void Start()
    {
        gameEvents.onGameOver.AddListener(showGameOver);
    }


    public void showGameOver()
    {
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<TextMesh>().text = "You Lost!";
    }
}