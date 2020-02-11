using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Minigame
{
    public virtual void TriggerMinigame ()
    {
        Debug.Log("Minigame: BASE");
    }
}
