using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPCConversation : MonoBehaviour
{

    //public bool conversationOver = false;
    public bool isClose = false;
    public Transform followPlayer;
    public CharacterController npcController;
    private DialogueGirlfriend dialogueStart;
    private bool started = false;

    public float npcPosition;
    // Start is called before the first frame update
    void Start()
    {
        dialogueStart = FindObjectOfType<DialogueGirlfriend>();
    }

    // Update is called once per frame
    void Update()
    {
        npcPosition = Vector3.Distance(followPlayer.position, npcController.transform.position);

        isClose = (Math.Abs(npcPosition) < 4);

        if (isClose && Input.GetKey(KeyCode.E) && !started)
        {
            dialogueStart.StartDialogue();
            started = true;
        }
    }
}
