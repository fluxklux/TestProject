using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public bool[] hasPressedKey = { false, false, false, false };
    [Header("DEBUG")]
    public GUIStyle style;

    //private int playersCount = 0;
    private GameController gc;
    private DPad dc;
    private bool canTakeInput = true;

    void Start()
    {
        dc = GetComponent<DPad>();
        gc = GetComponent<GameController>();
    }

    public void ChangeTakeInputBool (bool onOff)
    {
        canTakeInput = onOff;
    }

    void Update()
    {
        if (!gc.queueFinished)
        {
            if (canTakeInput)
            {
                //för plebsen utan xbox controllers. lmao
                switch (Input.inputString)
                    {
                        case "1":
                            if (!hasPressedKey[0])
                            {
                                gc.HandleQueueInputs(0, 0);
                            }
                            break;
                        case "2":
                            if (!hasPressedKey[1])
                            {
                            gc.HandleQueueInputs(1, 0);
                        }
                            break;
                        default:
                            break;
                    }

                //p1
                if (!hasPressedKey[0])
                {
                    var c1Horizontal = Input.GetAxis("C1 Horizontal");
                    var c1Vertical = Input.GetAxis("C1 Vertical");
                
                    switch(c1Horizontal)
                    {
                        case 1:
                            gc.HandleQueueInputs(0, 1); //right
                            break;
                        case -1:
                            gc.HandleQueueInputs(0, 3);//left
                            break;
                        default:
                            break;
                    }

                    switch (c1Vertical)
                    {
                        case 1:
                            gc.HandleQueueInputs(0, 0); //up
                            break;
                        case -1:
                            gc.HandleQueueInputs(0, 2);//down
                            break;
                        default:
                            break;
                    }
                }

                //p2
                if (!hasPressedKey[1])
                {
                    var c2Horizontal = Input.GetAxis("C2 Horizontal");
                    var c2Vertical = Input.GetAxis("C2 Vertical");

                    switch (c2Horizontal)
                    {
                        case 1:
                            gc.HandleQueueInputs(1, 1); //right
                            break;
                        case -1:
                            gc.HandleQueueInputs(1, 3);//left
                            break;
                        default:
                            break;
                    }

                    switch (c2Vertical)
                    {
                        case 1:
                            gc.HandleQueueInputs(1, 0); //up
                            break;
                        case -1:
                            gc.HandleQueueInputs(1, 2);//down
                            break;
                        default:
                            break;
                    }
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

        GUI.Label(new Rect(10, 10, 250, 200), debugString, style);
    }
}
