﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DPad : MonoBehaviour
{
    public Text[] numbers;

    int randomInt;

    [HideInInspector]
    public List<int> TakeNumbList = new List<int>();

    public void Randomize()
    {
        TakeNumbList = new List<int>(new int[numbers.Length]);

        for (int i = 0; i < numbers.Length; i++)
        {
            randomInt = Random.Range(1, 11);
            while (TakeNumbList.Contains(randomInt))
            {
                randomInt = Random.Range(1, 11);
            }

            TakeNumbList[i] = randomInt;
            numbers[i].text = TakeNumbList[i].ToString();
        }
    }
}
