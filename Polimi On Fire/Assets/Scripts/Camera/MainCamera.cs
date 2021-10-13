using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainCamera : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;

    private float offsetX;
    private float offsetY;
    private float offsetZ;

    private float _tempVar;
    public Vector3 v_movement;
    public bool moveFlag = true;      
    private double flagCounter = 0;  
    
    //Animacion
    private Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
        offsetX = startOffset.x;
        offsetY = startOffset.y;
        offsetZ = startOffset.z;
    }

    // Update is called once per frame
    void Update()
    {
        v_movement = lookAt.transform.forward;
        startOffset.x = offsetX;
        startOffset.y = offsetY;
        startOffset.z = offsetZ;
        
        moveVector = lookAt.position + startOffset;

        transform.position = moveVector;
           
        flagCounter += Time.deltaTime; 
        
        if (flagCounter >= 0.3)    
        {                          
            moveFlag = true;       
        }
        if ((Input.GetKey(KeyCode.LeftArrow)) && (v_movement.x > -1) && (moveFlag == true))
        {
            transform.Rotate(0f, -90f ,0f);
            _tempVar = offsetX;
            offsetX = -offsetZ;
            offsetZ = _tempVar;
            flagCounter = 0; 
            moveFlag = false;
        }

        if ((Input.GetKey(KeyCode.RightArrow)) && (v_movement.x < 1) && (moveFlag == true))
        {
            transform.Rotate(0f, 90f ,0f);
            _tempVar = offsetX;
            offsetX = offsetZ;
            offsetZ = -_tempVar;
            flagCounter = 0;
            moveFlag = false;
        }
    }
}
