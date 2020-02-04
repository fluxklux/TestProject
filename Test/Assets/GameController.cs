﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QueueObject
{

    public int playerIndex; //player index, p1 = 0, p2 = 1 .....
    public int steps; //amount of steps forward

}

public class GameController : MonoBehaviour
{
    public Image uiFill;
    public Text timerText;

    public Slot[] allSlotTypes;
    public GameObject[] allSlots;

    public List<QueueObject> queueObjects = new List<QueueObject>();
    public bool queueFinished = true;

    float timer;
    float timerMax = 25;
    bool countDown = false;

    InputController ic;
    UIController uc;
    MoveController mc;
    DPad dpad;

    void Start()
    {
        mc = GetComponent<MoveController>();
        uc = GetComponent<UIController>();
        ic = GetComponent<InputController>();
        dpad = GetComponent<DPad>();
    }

    void Update()
    {
        if(countDown)
        {
            if(timer > 0 )
            {
                timer -= Time.fixedDeltaTime;
                timerText.text = timer.ToString("F1");

                float calcFloat = timer / timerMax;
                uiFill.fillAmount = calcFloat;
                uc.DisplayTimerFloat(timer);
            }
            else
            {
                countDown = false;
                queueFinished = true;
                StartCoroutine(WaitForNextRound());

            }
        }
    }

    private IEnumerator WaitForNextRound()
    {
        yield return new WaitForSeconds(0.5f);

        if(queueObjects.Count > 0)
        {
            StartCoroutine(CycleQueue(1, 0));
        }
        else
        {
            StartCoroutine(ResetQueue());
        }
    }

    public void TriggerTimer(bool pause)
    {
        if(pause)
        {
            countDown = false;
        }
        else
        {
            timer = timerMax;
            countDown = true;
        }
    }

    public void AddToQueue(int playerIndex, int steps)
    {
        //sets the variables from the actions to the queueObject.
        QueueObject newQueueObject = new QueueObject();
        newQueueObject.playerIndex = playerIndex;
        newQueueObject.steps = steps;

        queueObjects.Add(newQueueObject);
    }

    IEnumerator ResetQueue()
    {
        yield return new WaitForSeconds(0.5f);
        uc.TriggerEvent("Reseting Queue");

        yield return new WaitForSeconds(3);
        queueObjects.Clear();

        for (int i = 0; i < ic.hasPressedKey.Length; i++)
        {
            ic.hasPressedKey[i] = false;
        }

        queueFinished = true;
        uc.TriggerEvent("Queue Reset!");
    }

    IEnumerator CycleQueue(float actionLength, int queueIndex)
    {
        yield return new WaitForSeconds(actionLength);
        int newQueueIndex = queueIndex + 1;

        //ACTIONS HERE!
        mc.MovePlayer(queueObjects[queueIndex].playerIndex, queueObjects[queueIndex].steps);
        //END OF ACTIONS

        if (newQueueIndex < queueObjects.Count)
        {
            //gc.TriggerEvent("Continue Queue");
            StartCoroutine(CycleQueue(2, newQueueIndex));
        }
        else
        {
            uc.TriggerEvent("Queue done!");
            TriggerTimer(true);
            StartCoroutine(ResetQueue());
            //reset queue and start again.
        }
    }

    public void handleQueueInputs(int indexedPlayer)
    {
        AddToQueue(indexedPlayer, dpad.TakeNumbList[Random.Range(0, dpad.TakeNumbList.Count)]);
        ic.hasPressedKey[indexedPlayer] = true;

        if (queueObjects.Count == 4)
        {
            StartCoroutine(CycleQueue(1, 0));
            //Get the action length in some way and input it to the queue ienumerator (first parameter)
            //queue should always start on index 0
        }
    }

    public void TriggerRoundStart()
    {
        if (queueFinished)
        {
            TriggerTimer(false);
            uc.TriggerEvent("Waiting for player inputs");
            dpad.Randomize();
            queueFinished = false;
        }
    }
}