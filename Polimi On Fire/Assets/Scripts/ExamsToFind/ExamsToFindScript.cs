using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamsToFind : MonoBehaviour
{
    
    public bool isClose = false;
    public Transform followPlayer;
    public CheckListScript3 checkList;
    public Image pressE;
    public int id;
    public float distance;
    public GameObject book;
    public ExamsToFind examScript1;
    public ExamsToFind examScript2;
    public ExamsToFind examScript3;
    public ExamsToFind examScript4;
    public ExamsToFind examScript5;


    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        pressE.gameObject.SetActive(false);
        book.SetActive(true);
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(followPlayer.position, this.transform.position);

        isClose = (Math.Abs(distance) < 1.8);
        if (isClose && !started)
        {
            pressE.gameObject.SetActive(true);
        }

        if (!(examScript1.isClose || examScript2.isClose || examScript3.isClose || examScript4.isClose || examScript5.isClose))
        {
            pressE.gameObject.SetActive(false);
        }
        if (isClose && Input.GetKey(KeyCode.E) && !started)
        {
            isClose = false;
            pressE.gameObject.SetActive(false);
            checkList.actionToggle(id);
            book.SetActive(false);
            started = true;
        }
    }
}