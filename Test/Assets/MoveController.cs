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
        uc.TriggerEvent("MOVE P" + (playerIndex + 1) + ": " + steps + " STEPS");

        int calcIndex = players[selectedPlayer].GetComponent<PlayerController>().currentSlotPosition + steps;
        calcIndex = (int)Mathf.Repeat(calcIndex, gc.allSlots.Length);
        selectedSlot = calcIndex;
        checkAndUpdate(selectedSlot, selectedPlayer);

        selectedPlayer = playerIndex;
        gc.allSlots[selectedSlot].GetComponent<SlotController>().TriggerSlotBehaviour(selectedPlayer);
    }

    void checkAndUpdate(int slotIndex, int playerIndex)
    {
        selectedPlayer = playerIndex;
        int temporarySelectedSlot = slotIndex;
        int playersOnSlot = checkSelectedSlot(temporarySelectedSlot);

        switch (playersOnSlot)
        {
            case 1:
                updatePlayerPosition(new Vector3(0.25f, 0.25f, 0), temporarySelectedSlot);
                players[selectedPlayer].GetComponent<PlayerController>().wasFirst = false;
                updateAllPlayers(0);
                break;
            case 2:
                updatePlayerPosition(new Vector3(-0.25f, -0.25f, 0), temporarySelectedSlot);
                players[selectedPlayer].GetComponent<PlayerController>().wasFirst = false;
                updateAllPlayers(0);
                break;
            case 3:
                updatePlayerPosition(new Vector3(0.25f, -0.25f, 0), temporarySelectedSlot);
                players[selectedPlayer].GetComponent<PlayerController>().wasFirst = false;
                updateAllPlayers(0);
                break;
            case 0:
                updatePlayerPosition(new Vector3(0, 0, 0), temporarySelectedSlot);
                players[selectedPlayer].GetComponent<PlayerController>().wasFirst = true;
                updateAllPlayers(1);
                break;
            default:
                break;
        }
    }

    int checkSelectedSlot(int slotIndex)
    {
        int amountOfPlayers = 0;

        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].GetComponent<PlayerController>().currentSlotPosition == slotIndex)
            {
                amountOfPlayers++;
            }
        }
        return amountOfPlayers;
    }

    void updatePlayerPosition(Vector3 offset, int selectedSlot)
    {
        players[selectedPlayer].transform.position = gc.allSlots[selectedSlot].transform.position + offset;
        players[selectedPlayer].GetComponent<PlayerController>().UpdatePosition(selectedSlot);
    }

    void updateAllPlayers(int caseNumber)
    {
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i].GetComponent<PlayerController>().wasFirst == true)
            {
                if(checkSelectedSlot(players[i].GetComponent<PlayerController>().currentSlotPosition) > 1)
                {
                    selectedPlayer = i;
                    updatePlayerPosition(new Vector3(-0.25f, 0.25f), players[i].GetComponent<PlayerController>().currentSlotPosition);
                }
            }

            if (checkSelectedSlot(players[i].GetComponent<PlayerController>().lastSlotIndex) == 1)
            {
                for(int j = 0; j < players.Length; j++)
                {
                    if(players[j].GetComponent<PlayerController>().currentSlotPosition == players[i].GetComponent<PlayerController>().lastSlotIndex)
                    {
                        Debug.Log("updating J");
                        
                        selectedPlayer = j;
                        updatePlayerPosition(new Vector3(0, 0), players[j].GetComponent<PlayerController>().currentSlotPosition);
                    }
                }
            }
        }
    }
}
