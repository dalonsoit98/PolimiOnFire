using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ServerScript : MonoBehaviour
{
    
    public bool isClose = false;
    public Transform followPlayer;
    public CheckListScript3 checkList;
    public Image pressE;
    public int id;
    public float distance;
    public GameObject book;
    public ExamsToFindScript examScript1;
    public ExamsToFindScript examScript2;
    public ExamsToFindScript examScript3;
    public PublishExamScript publishExam;
    public ServerScript serverScript;


    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        pressE.gameObject.SetActive(false);
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(followPlayer.position, this.transform.position);

        isClose = (Math.Abs(distance) < 2.8);
        if (isClose && !started)
        {
            pressE.gameObject.SetActive(true);
        }

        if (!(examScript1.isClose || examScript2.isClose || examScript3.isClose || publishExam.isClose || serverScript.isClose))
        {
            pressE.gameObject.SetActive(false);
        }
        if (isClose && Input.GetKey(KeyCode.E) && !started)
        {
            isClose = false;
            pressE.gameObject.SetActive(false);
            checkList.actionToggle(id);
            started = true;
        }
    }
}