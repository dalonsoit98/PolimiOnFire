using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController _charController;
    private Animator _animator;
    
    //move variables
    public float moveSpeed = 6f;
    public float leftRightSpeed = 9f;
    public Vector3 v_movement;
    public bool moveFlag = true;
    private double flagCounter = 0;
    //public float deviation = 0f;
    public Vector3 RL;
    
    //Gravity
    public float verticalVelocity;

    public float gravity = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        _charController = GetComponent<CharacterController> ();

        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        v_movement = _charController.transform.forward;
        v_movement.y = verticalVelocity;
       
        RL = Vector3.Cross(v_movement, new Vector3(0f, 1f));
       _charController.Move (v_movement * Time.deltaTime * moveSpeed);
        flagCounter += Time.deltaTime;
        
        if (_charController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(Jump());
                verticalVelocity = 3.5f;
            }
            else
            {
                verticalVelocity = -0.5f;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
    
        if (flagCounter >= 0.3)
        {
            moveFlag = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _charController.transform.Translate(RL * Time.deltaTime * leftRightSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _charController.transform.Translate(RL * Time.deltaTime * leftRightSpeed* -1, Space.World);
        }
        if ((Input.GetKey(KeyCode.LeftArrow)) && (v_movement.x > -1) && (moveFlag == true))
        {
            flagCounter = 0;
            moveFlag = false;
            _charController.transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        if ((Input.GetKey(KeyCode.RightArrow)) && (v_movement.x < 1) && (moveFlag == true))
        {
            flagCounter = 0;
            moveFlag = false;
            _charController.transform.Rotate(new Vector3(0f, 90f, 0f));
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Colision");
    }

    private IEnumerator Jump()
    {
        _animator.SetTrigger("JumpTrigger");
        yield return new WaitForSeconds(3.0f);
    }
}
