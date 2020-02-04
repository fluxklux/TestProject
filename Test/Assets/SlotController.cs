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

                if (playerIndex == 0)
                {
                    uc.playerOneFruits += 3;
                }


                if (playerIndex == 1)
                {
                    uc.playerTwoFruits += 3;
                }


                if (playerIndex == 2)
                {
                    uc.playerThreeFruits += 3;
                }

                if (playerIndex == 3)
                {
                    uc.playerFourFruits += 3;
                }


                Debug.Log(playerIndex);

                break;


            case SlotType.minusThree:

                //Remove 3 fruits from player
                Debug.Log(playerIndex);

                if (playerIndex == 0)
                {
                    uc.playerOneFruits -= 3;
                }


                if (playerIndex == 1)
                {
                    uc.playerTwoFruits -= 3;
                }


                if (playerIndex == 2)
                {
                    uc.playerThreeFruits -= 3;
                }

                if (playerIndex == 3)
                {
                    uc.playerFourFruits -= 3;
                }

                break;


            case SlotType.plusTen:

                //Add 10 fruits to player

                if (playerIndex == 0)
                {
                    uc.playerOneFruits += 10;
                }


                if (playerIndex == 1)
                {
                    uc.playerTwoFruits += 10;
                }


                if (playerIndex == 2)
                {
                    uc.playerThreeFruits += 10;
                }

                if (playerIndex == 3)
                {
                    uc.playerFourFruits += 10;
                }

                break;

            case SlotType.miniGame:

                //do something//
                if (playerIndex == 0)
                {
                    Debug.Log(playerIndex + " minigame Time");
                }


                if (playerIndex == 1)
                {
                    Debug.Log(playerIndex + " minigame Time");
                }


                if (playerIndex == 2)
                {
                    Debug.Log(playerIndex + " minigame Time");
                }

                if (playerIndex == 3)
                {
                    Debug.Log(playerIndex + " minigame Time");
                }

                break;

            default:

                break;


        }
    }
}
