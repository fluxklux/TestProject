using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    public Minigame[] allMinigames;

    public void RandomizeMinigame()
    {
        int random = Random.Range(0, 2);

        switch (random)
        {
            case 0:

                break;
            case 1:

                break;
            default:
                break;
        }
    }

    #region 0_Masher
    private void ToggleMasherPanel (bool onOff)
    {

    }

    #endregion
}
