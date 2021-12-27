using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireAlarmScript : MonoBehaviour
{
    public bool isClose = false;
    public Transform followPlayer;
    public CheckListScript checkList;
    public Image pressE;
    public GameObject fireAlarm;
    public GameObject fireAlarm2;
    public float distance;

    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        fireAlarm2.SetActive(false);
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(followPlayer.position, this.transform.position);

        isClose = (Math.Abs(distance) < 4);
        if (isClose && !started)
        {
            pressE.gameObject.SetActive(true);
        }
        if (isClose && Input.GetKey(KeyCode.E) && !started)
        {
            pressE.gameObject.SetActive(false);
            checkList.actionToggle(2);
            fireAlarm.SetActive(false);
            fireAlarm2.SetActive(true);
            FindObjectOfType<AudioManager>().StartAlarm();
            started = true;
        }
    }
}
