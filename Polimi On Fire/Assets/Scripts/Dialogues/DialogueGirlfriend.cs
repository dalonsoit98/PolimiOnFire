using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueGirlfriend : MonoBehaviour
{
    // Start is called before the first frame update

    public Text dialogue;
    public string[] lines;
    public float textSpeed;
    public PlayerMoveBuilding playerMoveBuilding;
    public MainCameraBuilding1 mainCamera;
    
    private int index;

    public bool dialogueStarted;
    
    void Start()
    {
        dialogueStarted = false;
        dialogue.text = string.Empty;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueStarted)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogue.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogue.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        dialogue.text = string.Empty;
        gameObject.SetActive(true);
        dialogueStarted=true;
        index = 0;
        playerMoveBuilding.isDialog = true;
        mainCamera.isPaused = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogue.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            playerMoveBuilding.isDialog = false;
            mainCamera.isPaused = false;
            gameObject.SetActive(false);
        }
    }
}
