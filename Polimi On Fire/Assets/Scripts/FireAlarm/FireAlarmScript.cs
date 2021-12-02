using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireAlarmScript : MonoBehaviour
{
    public bool isClose = false;
    public Transform followPlayer;
    public CheckListScript checkList;
    
    public float distance;

    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(followPlayer.position, this.transform.position);

        isClose = (Math.Abs(distance) < 4);

        if (isClose && Input.GetKey(KeyCode.E) && !started)
        {
            checkList.actionToggle(2);
            // Insertar Sonido?
            started = true;
        }
    }
}
