using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Player Texts")]

    public Text playerOne;
    public Text playerTwo;
    public Text playerThree;
    public Text playerFour;

    public Text timerText;
    public Text eventText;

    GameController gc;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void UpdatePlayerFruits(int[] playerFruits)
    {
        //byt till for loop
        playerOne.text = "P1: " + playerFruits[0];
        playerTwo.text = "P2: " + playerFruits[1];
        playerThree.text = "P3: " + playerFruits[2];
        playerFour.text = "P4: " + playerFruits[3];
    }

    public void DisplayTimerFloat(float timer)
    {
        timerText.text = timer.ToString("F1");
    }

    public void TriggerEvent(string eventString)
    {
        eventText.text = eventString;
    }
}