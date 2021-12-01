using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace SD
{

    public class NPCFollow : MonoBehaviour
    {
        [Header("Player Setting")]
        public Transform followPlayer;
        Animator npcAnim;
        public float walkSpeed = 3.0f;
        public float runSpeed = 6.0f;
        public CharacterController npcController;
        public Vector3 ctrlVelocity;
        float npcGrav = 12.0f;
        public bool isPlayerRunning = false;
        public bool isPlayerIdle = true;
        public bool isPlayerAction = false;
        public float npcPosition;
        public float turnSpeed = 10f;
        public bool stopMoverment = false;

        public void Start()
        {
            npcAnim = GetComponent<Animator>();
        }
        
        public void Update()
        {
            Vector3 direction = followPlayer.position - npcController.transform.position;
            float angle = Vector3.Angle(direction, npcController.transform.position);
            npcPosition = Vector3.Distance(followPlayer.position, npcController.transform.position);
            stopMoverment = (Math.Abs(npcPosition) < 4);
            direction.y = 0;
            npcController.transform.rotation = Quaternion.Slerp(npcController.transform.rotation, Quaternion.LookRotation(direction), 1f);
            if (stopMoverment)
            {
                isIdle();
                return;
            }
            npcMoving();
        }
        
         public void npcMoving() 
         {
             Vector3 direction = followPlayer.position - npcController.transform.position;
            float angle = Vector3.Angle(direction, npcController.transform.position);
            npcPosition = Vector3.Distance(followPlayer.position, npcController.transform.position);

        direction.y = 0;
        //npcController.transform.rotation = Quaternion.Slerp(npcController.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        
        if(Math.Abs(npcPosition) > 10)
        {
            npcMove(direction, runSpeed - 1);
            isRunForward();
            Debug.Log("Running");
        }
        if (Math.Abs(npcPosition) > 3)
        {
            npcMove(direction, walkSpeed);
            isMoveForward();
            Debug.Log("Problems");
        }
        
        if (npcPosition < 4.3)
        {
            npcMove(direction, walkSpeed + 1);
            isMoveForward();
        }
        }

    void npcMove(Vector3 dir, float spd)
    {
        ctrlVelocity = dir.normalized * spd;
        ctrlVelocity.y = Mathf.Clamp(npcController.velocity.y, -30, 2);
        ctrlVelocity.y -= npcGrav * Time.deltaTime;
        npcController.Move(ctrlVelocity * Time.deltaTime);
    }

    void isRunForward()
    {
        npcAnim.SetBool("isJump", false);
        npcAnim.SetBool(Const.Moving, true);
        npcAnim.SetFloat(Const.Speed, runSpeed);
    }

    void isMoveForward()
    {
        npcAnim.SetBool("isJump", false);
        npcAnim.SetBool(Const.Moving, true);
        npcAnim.SetFloat(Const.Speed, walkSpeed);
    }
    
    void isIdle()
    {
        npcAnim.SetBool(Const.Moving, false);
        npcAnim.SetFloat(Const.Speed, 0);
        npcAnim.SetBool("isJump", false);
    }
    
    void isJump()
    {
        npcAnim.SetBool("isJump", true);
    }
    
    }
}
