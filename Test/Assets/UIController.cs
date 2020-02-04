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

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPlayerInts();
    }

    void DisplayPlayerInts()
    {
        playerOne.text = "P1 Fruits: " + playerOneFruits;

        playerTwo.text = "P2 Fruits: " + playerTwoFruits;

        playerThree.text = "P3 Fruits: " + playerThreeFruits;

        playerFour.text = "P4 Fruits: " + playerFourFruits;
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