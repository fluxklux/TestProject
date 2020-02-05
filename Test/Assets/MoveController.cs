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

        int playersOnSlot = checkSelectedSlot(selectedSlot);

        switch (playersOnSlot)
        {
            case 2:
                updatePlayerPosition(new Vector3(0, -2, 0));
                break;
            case 3:
                updatePlayerPosition(new Vector3(0, -2, 0));
                break;
            case 4:
                updatePlayerPosition(new Vector3(0, -2, 0));
                break;
            default:
                updatePlayerPosition(new Vector3(0, 0, 0));
                break;
        }

        gc.allSlots[selectedSlot].GetComponent<SlotController>().TriggerSlotBehaviour(selectedPlayer);
    }

    int checkSelectedSlot(int slotIndex)
    {
        int amountOfPlayers = 1;

        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].GetComponent<PlayerController>().currentSlotPosition == slotIndex)
            {
                amountOfPlayers++;
            }
        }
        return amountOfPlayers;
    }

    void updatePlayerPosition(Vector3 offset)
    {
        //move the player to the newly calculated (and assigned) slot
        players[selectedPlayer].transform.position = gc.allSlots[selectedSlot].transform.position + offset;
        players[selectedPlayer].GetComponent<PlayerController>().UpdatePosition(selectedSlot);
    }

    void updateSoloPlayer()
    {

    }
}
