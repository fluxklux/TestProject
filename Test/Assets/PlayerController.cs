using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int currentSlotPosition = 0;

    public int lastSlotIndex = 0;

    public bool isAlone = false;

    public bool wasFirst = false;

    public void UpdatePosition(int newIndex)
    {
        lastSlotIndex = GetPositionIndex();
        currentSlotPosition = newIndex;
    }

    public int GetPositionIndex()
    {
        return currentSlotPosition;
    }
}
