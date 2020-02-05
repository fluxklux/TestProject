using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public bool[] hasPressedKey = { false, false, false, false };
    [Header("DEBUG")]
    public GUIStyle style;

    private int playersCount = 0;
    private GameController gc;
    private bool canTakeInput = true;

    void Start()
    {
        gc = GetComponent<GameController>();
    }

    public void ChangeTakeInputBool (bool onOff)
    {
        canTakeInput = onOff;
    }

    void Update()
    {
        Debug.Log(canTakeInput);

        if (!gc.queueFinished)
        {
            if (canTakeInput)
            {
                switch (Input.inputString)
                {
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

        GUI.Label(new Rect(10, 10, 250, 200), debugString, style);
    }
}
