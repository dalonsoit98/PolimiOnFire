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
    public DialogueGirlfriend dialogueStart;
    public NPCNavMesh npcNavMesh;
    public CheckListScript checkList;
    public Image pressE;
    public bool started = false;

    public float npcPosition;
    // Start is called before the first frame update
    void Start()
    {
        pressE.gameObject.SetActive(false);
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        npcPosition = Vector3.Distance(followPlayer.position, npcController.transform.position);

        isClose = (Math.Abs(npcPosition) < 5.5);
        if (isClose && !started)
        {
            pressE.gameObject.SetActive(true);
        }
        if (isClose && Input.GetKey(KeyCode.E) && !started)
        {
            pressE.gameObject.SetActive(false);
            checkList.actionToggle(1);
            npcNavMesh.ToggleFollow();
            dialogueStart.StartDialogue();
            started = true;
        }
    }
}
