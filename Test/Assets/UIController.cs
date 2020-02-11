using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Player Texts: ")]
    public GameObject[] playerTexts;
    public GameObject[] connectionPanelsNotJoined;//vidrigt, fixa längre fram
    public GameObject[] connectionPanelsJoined;//vidrigt, fixa längre fram
    public GameObject connectionPanel;
    public GameObject[] visuals;

    [Header("Main Texts: ")]
    public Text timerText;
    public Text eventText;

    private GameController gc;

    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void TogglePlayerUi (int index)
    {
        playerTexts[index].SetActive(true);
        connectionPanelsNotJoined[index].SetActive(false);
        connectionPanelsJoined[index].SetActive(true);
    }

    public void ToggleConnectionUi (bool onOff)
    {
        connectionPanel.SetActive(onOff);

        for (int i = 0; i < visuals.Length; i++)
        {
            visuals[i].SetActive(true);
        }
    }

    public void UpdatePlayerFruits(int[] playerFruits)
    {
        for (int i = 0; i < playerTexts.Length; i++)
        {
            playerTexts[i].GetComponentInChildren<Text>().text = "P" + i + ": " + playerFruits[i];
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