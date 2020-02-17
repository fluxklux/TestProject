using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public int currentSlotPosition = 0;
    public Slot currentSlotType = null;
    public int lastSlotIndex = 0;
    public bool isAlone = false;
    public bool wasFirst = false;

    public int currentPlayer;
    public int lastPlayerIndex;

    public void UpdatePosition(int newIndex)
    {
        lastSlotIndex = GetPositionIndex();
        currentSlotPosition = newIndex;
    }

    public void UpdateScale(int playerIndex, float highestSlotY)
    {

        float maxY = highestSlotY;

        float yPos = transform.position.y;

        float differents;

        differents = maxY - yPos;

        Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);

        Vector3 maxScale = new Vector3(1f, 1f, 1f);

        float playerScale;

        playerScale = Mathf.Lerp(minScale.y, maxScale.y, differents - 4);

        transform.localScale = new Vector3(playerScale, playerScale, 0.0f);

        currentPlayer = playerIndex;

    }

    public int GetPositionIndex()
    {
        return currentSlotPosition;
    }

    public int GetPlayerIndex()
    {
        return currentPlayer;
    }
}

