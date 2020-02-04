using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GameObject[] players;

    GameController gc;
    UIController uc;
    int selectedPlayer = 0;
    int selectedSlot = 0;
    string moveAmount;

    void Start()
    {
        gc = GetComponent<GameController>();
        uc = GetComponent<UIController>();
    }

    public void MovePlayer(int playerIndex, int steps)
    {
        selectedPlayer = playerIndex;

        //event
        uc.TriggerEvent("MOVE P" + (playerIndex + 1) + ": " + steps + " STEPS");

        int calcIndex = players[selectedPlayer].GetComponent<PlayerController>().currentSlotPosition + steps;
        calcIndex = (int)Mathf.Repeat(calcIndex, gc.allSlots.Length);
        selectedSlot = calcIndex;

        players[selectedPlayer].transform.position = gc.allSlots[selectedSlot].transform.position;
        players[selectedPlayer].GetComponent<PlayerController>().UpdatePosition(calcIndex);

        gc.allSlots[selectedSlot].GetComponent<SlotController>().TriggerSlotBehaviour(selectedPlayer);
    }
}
