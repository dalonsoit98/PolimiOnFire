using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTrigger : MonoBehaviour
{
    public bool isClose = false;
    public Transform followPlayer;
    public CheckListScript checkList;
    public FireAlarmScript fireAlarm;
    public WiningText winText;
    public NPCConversation npcConversation;
    public WinMenuScript winMenu;
    public PlayerMoveBuilding player;
    
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

        if (isClose && !started && fireAlarm.started && npcConversation.started && npcConversation.isClose)
        {
            player.isWin = true;
            checkList.actionToggle(3);
            // Insertar Sonido?
            winText.ToggleWinText();
            winMenu.ToggleWinMenu();
            started = true;
        }
    }
}
