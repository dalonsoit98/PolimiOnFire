using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueStart : MonoBehaviour
{

    public Text dialogue;
    public string[] lines;
    public float textSpeed;
    
    private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogue.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogue.text == lines[index])
            {
                NextLine();
                if (index == 1)
                {
                    FindObjectOfType<AudioManager>().Death();
                }
                
            }
            else
            {
                StopAllCoroutines();
                dialogue.text = lines[index];
            }
        }
        
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    
    public void StartDialogue()
    {
        dialogue.text = string.Empty;
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
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
            gameObject.SetActive(false);
            SceneManager.LoadScene("Building1");
        }
    }
}
