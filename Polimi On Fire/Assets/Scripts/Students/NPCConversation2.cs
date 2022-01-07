using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPCConversation2 : MonoBehaviour
{

    //public bool conversationOver = false;
    public bool isClose = false;
    public Transform followPlayer;
    public Transform npcController;
    public DialogueStudents dialogueStart;
    public Image pressE;
    public bool started = false;

    public float npcPosition;

    public NPCConversation2 npc1;
    public NPCConversation2 npc2;
    public NPCConversation2 npc3;
    public NPCConversation2 npc4;
    public NPCConversation2 npc5;
    public NPCConversation2 npc6;
    public NPCConversation2 npc7;
    public NPCConversation2 npc8;
    public NPCConversation2 npc9;
    public NPCConversation2 npc10;
    public NPCConversation2 npc11;
    public NPCConversation2 npc12;
    public NPCConversation2 npc13;
    public NPCConversation2 npc14;
   
    // Start is called before the first frame update
    void Start()
    {
        pressE.gameObject.SetActive(false);
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        npcPosition = Vector3.Distance(followPlayer.position, npcController.position);

        isClose = (Math.Abs(npcPosition) < 3.5);
        if (!npc1.isClose && !npc2.isClose && !npc3.isClose && !npc4.isClose && !npc5.isClose && !npc6.isClose &&
            !npc7.isClose && !npc8.isClose && !npc9.isClose && !npc10.isClose && !npc11.isClose && !npc12.isClose &&
            !npc13.isClose && !npc14.isClose)
        {
            pressE.gameObject.SetActive(false);
        }
        if (isClose && !started)
        {
            pressE.gameObject.SetActive(true);
        }
        if (isClose && Input.GetKey(KeyCode.E) && !started)
        {
            pressE.gameObject.SetActive(false);
            dialogueStart.StartDialogue();
            started = true;
        }
        if (!isClose && started)
        {
            started = false;
        }
    }
}
