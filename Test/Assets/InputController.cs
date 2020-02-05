using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

            if (gc.timer > 22)
            {
                switch (Input.inputString)
                {
                    //Random Range because we currently cant get input from the controllers so which the -
                    //player chooses is random.
                    case "1":
                        if (!hasPressedKey[0])
                        {
                            gc.HandleQueueInputs(0);
                        }
                        break;
                    case "2":
                        if (!hasPressedKey[1])
                        {
                            gc.HandleQueueInputs(1);
                        }
                        break;
                    case "3":
                        if (!hasPressedKey[2])
                        {
                            gc.HandleQueueInputs(2);
                        }
                        break;
                    case "4":
                        if (!hasPressedKey[3])
                        {
                            gc.HandleQueueInputs(3);
                        }
                        break;
                    default:
                        break;
                }
               
                

            }
        }
    }

    private void OnGUI()
    {
        var c1Hor = Input.GetAxis("C1 Horizontal");
        var c2Hor = Input.GetAxis("C2 Horizontal");

        var c1Ver = Input.GetAxis("C1 Vertical");
        var c2Ver = Input.GetAxis("C2 Vertical");

        string debugString = "P1: " + c1Hor.ToString("F2") + ", " + c1Ver.ToString("F2")
            + "\n" + "P2: " + c2Hor.ToString("F2") + ", " + c2Ver.ToString("F2");

        GUI.Label(new Rect(10, 10, 250, 200), debugString);
    }
}
