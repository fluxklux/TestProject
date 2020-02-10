﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    //make private later, public for debugging reasons
    public int playerCount = 0;
    public bool[] hasPressedKey = { false, false, false, false };
    public bool[] hasJoined = { false, false, false, false };
    public int[] playerArray = { 0, 1, 2, 3 };

    public GameObject[] allPlayers = { };

    [Header("DEBUG")]
    public GUIStyle style;
    
    private GameController gc;
    private DPad dc;
    private UIController uc;
    private MoveController mc;

    private bool canTakeInput = true;
    private bool gameStarted = false;

    void Start()
    {
        mc = GetComponent<MoveController>();
        dc = GetComponent<DPad>();
        gc = GetComponent<GameController>();
        uc = GetComponent<UIController>();
    }

    public void ChangeTakeInputBool (bool onOff)
    {
        canTakeInput = onOff;
    }

    public void AddPlayer (int index)
    {
        Debug.Log("Entered AddPlayer Function");
        if(playerCount < 4)
        {
            //add events
            playerCount++;
            hasJoined[index] = true;
            uc.TogglePlayerUi(index, true);

            //add mechanical functions
            //KAN INTE DYNAMISKT LÄGGA TILL OCH TA BORT SPELAR OBJEKTEN FÖR DEM LIGGER-
            //I GAMECONTROLLER OCH JAG MÅSTE ÄNDRA SPELAR ARRAYEN TILL EN LIST. BEHÖVER-
            //VIKBERG I SAMMA RUM FÖR DET. SÅ GITEN INTE FÅR MERGE-FEL.
        }
        else
        {
            Debug.Log("max player count reached!");
        }
    }

    private void StartGame ()
    {
        gameStarted = true;
        uc.ToggleConnectionUi(false);
        Debug.Log("Started game!");
    }

    private void Update()
    {
        //add controllers
        if(!gameStarted)
        {
            //Start Game
            if(playerCount >= 2)
            {
                if(Input.GetButtonDown("C1 Start"))
                {
                    StartGame();
                }

                if (Input.GetButtonDown("C2 Start"))
                {
                    StartGame();
                }

                if(Input.GetButtonDown("C3 Start"))
                {
                    StartGame();
                }
            }

            //Connect players
            if(Input.GetButtonDown("C1 Select") && !hasJoined[0])
            {
                Debug.Log("CONTROLLER 1");
                AddPlayer(0);
            }

            if (Input.GetButtonDown("C2 Select") && !hasJoined[1])
            {
                Debug.Log("CONTROLELR 2");
                AddPlayer(1);
            }

            if (Input.GetButtonDown("C3 Select") && !hasJoined[2])
            {
                Debug.Log("CONTROLELR 3");
                AddPlayer(2);
            }
        }

        //take input mid game
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
                    case "3":
                        if(!hasPressedKey[2])
                        {
                            gc.HandleQueueInputs(2, 0);
                        }
                        break;
                    default:
                        break;
                }

                //p1
                if (playerCount > 0 && !hasPressedKey[0])
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
                if (playerCount > 1 && !hasPressedKey[1])
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

                //p3
                if (playerCount > 2 && !hasPressedKey[2])
                {
                    var c3Horizontal = Input.GetAxis("C3 Horizontal");
                    var c3Vertical = Input.GetAxis("C3 Vertical");

                    switch (c3Horizontal)
                    {
                        case 1:
                            gc.HandleQueueInputs(2, 1); //right
                            break;
                        case -1:
                            gc.HandleQueueInputs(2, 3);//left
                            break;
                        default:
                            break;
                    }

                    switch (c3Vertical)
                    {
                        case 1:
                            gc.HandleQueueInputs(2, 0); //up
                            break;
                        case -1:
                            gc.HandleQueueInputs(2, 2);//down
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
        var c3Hor = Input.GetAxis("C3 Horizontal");

        var c1Ver = Input.GetAxis("C1 Vertical");
        var c2Ver = Input.GetAxis("C2 Vertical");
        var c3Ver = Input.GetAxis("C3 Vertical");

        string debugString = "P1: " + c1Hor.ToString("F2") + ", " + c1Ver.ToString("F2")
            + "\n" + "P2: " + c2Hor.ToString("F2") + ", " + c2Ver.ToString("F2")
            + "\n" + "P3: " + c3Hor.ToString("F2") + ", " + c3Ver.ToString("F2");

        GUI.Label(new Rect(10, 10, 250, 200), debugString, style);
    }
}
