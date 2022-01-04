using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningTrigger3 : MonoBehaviour
{
    public bool isClose = false;
    public Transform followPlayer;
    public WinMenuScript winMenu;
    public WiningText winText;
    public PlayerMoveBuilding3 player;
    public CheckListScript3 checklist;
    
    public bool started;
    
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(followPlayer.position, this.transform.position);

        isClose = (Math.Abs(distance) < 3);
        if (!started && isClose && checklist.toggle1.GetComponent<Toggle>().isOn && checklist.toggle2.GetComponent<Toggle>().isOn && checklist.toggle3.GetComponent<Toggle>().isOn && checklist.toggle4.GetComponent<Toggle>().isOn && checklist.toggle5.GetComponent<Toggle>().isOn)
        {
            player.isWin = true;
            player._animator.enabled = false;
            // Insertar Sonido?
            winText.ToggleWinText();
            winMenu.ToggleWinMenu();
            started = true;
        }
    }
}