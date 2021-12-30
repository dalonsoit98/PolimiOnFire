using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookToFind : MonoBehaviour
{
    
    public bool isClose = false;
    public Transform followPlayer;
    public CheckListScript2 checkList;
    public Image pressE;
    public int id;
    public float distance;
    public GameObject book;
    public BookToFind bookScript1;
    public BookToFind bookScript2;
    public BookToFind bookScript3;
    public BookToFind bookScript4;
    public BookToFind bookScript5;


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

        isClose = (Math.Abs(distance) < 1.5);
        if (isClose && !started)
        {
            pressE.gameObject.SetActive(true);
        }

        if (!(bookScript1.isClose || bookScript2.isClose || bookScript2.isClose || bookScript2.isClose || bookScript2.isClose))
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
