using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    public Slot currentSlot;

    GameController gc;
    UIController uc;
    new SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        gc = Object.FindObjectOfType<GameController>();
        uc = Object.FindObjectOfType<UIController>();
        currentSlot = gc.allSlotTypes[Random.Range(0, gc.allSlotTypes.Length)];
    }

    public void TriggerSlotBehaviour(int playerIndex)
    {
        switch (currentSlot.slotType)
        {
            case SlotType.plusThree:
                //Add 3 fruits to player
                gc.ChangeFruitAmount(playerIndex, 3);
                Debug.Log("3 fruits: " + playerIndex);
                break;
            case SlotType.minusThree:
                //Remove 3 fruits from player
                gc.ChangeFruitAmount(playerIndex, -3);
                Debug.Log("-3 fruits: " + playerIndex);
                break;
            case SlotType.plusTen:
                //Add 10 fruits to player
                gc.ChangeFruitAmount(playerIndex, 10);
                Debug.Log("10 fruits: " + playerIndex);
                break;
            case SlotType.miniGame:
                //minigame
                Debug.Log("minigame " + playerIndex);
                break;
            default:
                break;
        }
    }
}
