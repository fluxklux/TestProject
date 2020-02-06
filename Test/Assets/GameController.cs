using System.Collections;
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

    int[] playerFruits = { 0, 0, 0, 0 };

    [HideInInspector] public float timer;
    float timerMax = 30;
    bool countDown = false;

    InputController ic;
    UIController uc;
    MoveController mc;
    DPad dpad;
    bool doneOnce = false;

    void Start()
    {
        mc = GetComponent<MoveController>();
        uc = GetComponent<UIController>();
        ic = GetComponent<InputController>();
        dpad = GetComponent<DPad>();

        //DEBUG
        for (int i = 0; i < allSlots.Length; i++)
        {
            allSlots[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }

    public void ChangeFruitAmount (int playerIndex, int amount)
    {
        playerFruits[playerIndex] += amount;

        if(playerFruits[playerIndex] < 0)
        {
            playerFruits[playerIndex] = 0;
        }

        uc.UpdatePlayerFruits(playerFruits);
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

                if(timer <= (timerMax - 3) && !doneOnce)
                {
                    StartCoroutine(WaitForNextRound());
                    //StartCoroutine(CycleQueue(1, 0));
                    doneOnce = true;
                    ic.ChangeTakeInputBool(false);
                }
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
            Debug.Log("Has input");
            StartCoroutine(CycleQueue(1, 0));
        }
        else
        {
            Debug.Log("No input");
            TriggerTimer(true);
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
        QueueObject newQueueObject = new QueueObject();
        newQueueObject.playerIndex = playerIndex;
        newQueueObject.steps = steps;

        queueObjects.Add(newQueueObject);
    }

    IEnumerator ResetQueue()
    {
        yield return new WaitForSeconds(0.5f);
        uc.TriggerEvent("RESETING QUEUE...");
        //TriggerTimer(true);

        yield return new WaitForSeconds(3);
        queueObjects.Clear();

        for (int i = 0; i < ic.hasPressedKey.Length; i++)
        {
            ic.hasPressedKey[i] = false;
        }

        queueFinished = true;
        uc.TriggerEvent("QUEUE RESET!");
    }

    IEnumerator CycleQueue(float actionLength, int queueIndex)
    {
        yield return new WaitForSeconds(actionLength);
        int newQueueIndex = queueIndex + 1;
        
        mc.MovePlayer(queueObjects[queueIndex].playerIndex, queueObjects[queueIndex].steps);

        if (newQueueIndex < queueObjects.Count)
        {
            StartCoroutine(CycleQueue(2, newQueueIndex));
        }
        else
        {
            uc.TriggerEvent("QUEUE DONE!");
            //TriggerTimer(true);
            StartCoroutine(ResetQueue());
        }
    }

    public void HandleQueueInputs(int indexedPlayer, int dpadIndex)
    {
        AddToQueue(indexedPlayer, dpad.GetDPadNum(dpadIndex));
        ic.hasPressedKey[indexedPlayer] = true;

        //dont remove plz
        /*if (queueObjects.Count == 2) //change dynamicaly from 4 to amount of players in inputController
        {
            StartCoroutine(CycleQueue(1, 0));
            //Get the action length in some way and input it to the queue ienumerator (first parameter)
            //queue should always start on index 0
        }*/
    }

    public void TriggerRoundStart()
    {
        if (queueFinished)
        {
            ic.ChangeTakeInputBool(true);
            doneOnce = false;
            TriggerTimer(false);
            uc.TriggerEvent("WAITING FOR PLAYER INPUTS");
            dpad.Randomize();
            queueFinished = false;
        }
    }
}