using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinigameType { ButtonMash, Test}

[CreateAssetMenu(fileName = "new Minigame", menuName = "Custom/Minigame")]
public class Minigame : ScriptableObject
{
    public MinigameType minigameType;
}
