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

        checkAndUpdate(selectedSlot, selectedPlayer);

        gc.allSlots[selectedSlot].GetComponent<SlotController>().TriggerSlotBehaviour(selectedPlayer);
        //updateAllPlayers();
    }

    void checkAndUpdate(int slotIndex, int playerIndex)
    {
        selectedPlayer = playerIndex;
        int temporarySelectedSlot = slotIndex;
        int playersOnSlot = checkSelectedSlot(temporarySelectedSlot);


        switch (playersOnSlot)
        {
            case 2:
                updatePlayerPosition(new Vector3(0.25f, 0.25f, 0), temporarySelectedSlot);
                break;
            case 3:
                updatePlayerPosition(new Vector3(-0.25f, -0.25f, 0), temporarySelectedSlot);
                break;
            case 4:
                updatePlayerPosition(new Vector3(0.25f, -0.25f, 0), temporarySelectedSlot);
                break;
            default:
                updatePlayerPosition(new Vector3(0, 0, 0), temporarySelectedSlot);
                players[selectedPlayer].GetComponent<PlayerController>().isAlone = true;
                players[selectedPlayer].GetComponent<PlayerController>().wasFirst = true;
                break;
        }
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

    void updatePlayerPosition(Vector3 offset, int selectedSlot)
    {
        //move the player to the newly calculated (and assigned) slot
        players[selectedPlayer].transform.position = gc.allSlots[selectedSlot].transform.position + offset;
        players[selectedPlayer].GetComponent<PlayerController>().UpdatePosition(selectedSlot);
    }

    void updateAllPlayers() //Fortsätt här please please please !!!!!!!!!!!!!!!!!!!!!!!
    {
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i].GetComponent<PlayerController>().wasFirst == true)
            {
                if(checkSelectedSlot(players[i].GetComponent<PlayerController>().currentSlotPosition) > 1)
                {
                    updatePlayerPosition(new Vector3(-0.25f, 0.25f), players[i].GetComponent<PlayerController>().currentSlotPosition);
                }
            }
        }
    }

    /*
    void updateSoloPlayer(int selectedPlayerIndex, int caseNumber)
    {
        if(caseNumber == 1)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetComponent<PlayerController>().currentSlotPosition == players[selectedPlayerIndex].GetComponent<PlayerController>().lastSlotIndex)
                {
                    checkAndUpdate(players[i].GetComponent<PlayerController>().currentSlotPosition, i);
                }
            }
        }

        else
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetComponent<PlayerController>().currentSlotPosition == players[selectedPlayerIndex].GetComponent<PlayerController>().currentSlotPosition)
                {
                    selectedPlayer = i;
                    updatePlayerPosition(new Vector3(-0.25f, 0.25f), players[i].GetComponent<PlayerController>().currentSlotPosition);
                }

                if (players[i].GetComponent<PlayerController>().currentSlotPosition == players[selectedPlayerIndex].GetComponent<PlayerController>().lastSlotIndex)
                {
                    checkAndUpdate(players[i].GetComponent<PlayerController>().currentSlotPosition, i);
                }
            }
        }
        
    }
    */
    
}
