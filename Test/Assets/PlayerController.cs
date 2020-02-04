using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int currentSlotPosition = 0;

    public void UpdatePosition(int newIndex)
    {
        currentSlotPosition = newIndex;
    }
}
