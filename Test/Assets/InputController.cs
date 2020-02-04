using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool[] hasPressedKey = { false, false, false, false };
    GameController gc;

    void Start()
    {
        gc = GetComponent<GameController>();
    }

    void Update()
    {

        if (!gc.queueFinished)
        {
            switch (Input.inputString)
            { 
                //Random Range because we currently cant get input from the controllers so which the -
                //player chooses is random.
                case "1":
                    if(!hasPressedKey[0])
                    {
                        gc.handleQueueInputs(0);
                    }
                    break;
                case "2":
                    if (!hasPressedKey[1])
                    {
                        gc.handleQueueInputs(1);
                    }
                    break;
                case "3":
                    if (!hasPressedKey[2])
                    {
                        gc.handleQueueInputs(2);
                    }
                    break;
                case "4":
                    if (!hasPressedKey[3])
                    {
                        gc.handleQueueInputs(3);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
