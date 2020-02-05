using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Player Texts")]

    public Text[] playerTexts;

    public Text timerText;
    public Text eventText;

    GameController gc;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void UpdatePlayerFruits(int[] playerFruits)
    {
        for (int i = 0; i < playerTexts.Length; i++)
        {
            playerTexts[i].text = "P" + i + ": " + playerFruits[i];
        }
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