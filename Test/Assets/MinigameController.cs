using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    Minigame selectedMinigame;

    public void RandomizeMinigame()
    {
        int random = Random.Range(0, 2);

        switch (random)
        {
            case 0:
                selectedMinigame = new MinigameButtomMash();
                break;
            case 1:
                selectedMinigame = new MinigameTest();
                break;
            default:
                break;
        }

        selectedMinigame.TriggerMinigame();
    }
}
