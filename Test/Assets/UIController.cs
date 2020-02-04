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

    [Header("Player Ints")]

    public int playerOneFruits;
    public int playerTwoFruits;
    public int playerThreeFruits;
    public int playerFourFruits;

    public Text timerText;
    public Text eventText;

    GameController gc;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        DisplayPlayerInts();
    }

    void DisplayPlayerInts()
    {
        playerOne.text = "P1: " + playerOneFruits;
        playerTwo.text = "P2: " + playerTwoFruits;
        playerThree.text = "P3: " + playerThreeFruits;
        playerFour.text = "P4: " + playerFourFruits;
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