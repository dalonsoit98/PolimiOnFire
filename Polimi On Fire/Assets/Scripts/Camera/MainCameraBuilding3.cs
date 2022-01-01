using UnityEngine;


public class MainCameraBuilding3 : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;

    private float offsetX;
    private float offsetY;
    private float offsetZ;
    
    // Smooth change
    public Quaternion currentAngle;
    Quaternion targetRight = Quaternion.Euler(15,90,0);
    Quaternion targetLeft = Quaternion.Euler(15,270,0);
    Quaternion targetFront = Quaternion.Euler(15,0,0);
    Quaternion targetBack = Quaternion.Euler(15,180,0);
   // private Vector3 currentPosition;
    private int direction;

    //pause
    public bool isPaused = false;
    
    private float _tempVar;
    public Vector3 v_movement;
    public bool moveFlag = true;    
    public int flagForward;
    private double flagCounter = 0;

    public PlayerMoveBuilding3 script;
    
    //Animacion
    private Vector3 moveVector;
    
    //Dead
    private bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = targetRight;
        direction = 2;
        
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
        offsetX = startOffset.x;
        offsetY = startOffset.y;
        offsetZ = startOffset.z;
        flagForward = 0;
    }

    // Update is called once per frame
    void Update()
    {
       /* if (isDead)
            return;
       */
       //transform.rotation = new Quaternion(0f,0f,0f,0f);

       if (isPaused)
       {
           return;
       }

       v_movement = script.v_movement;
        startOffset.x = offsetX;
        startOffset.y = offsetY;
        startOffset.z = offsetZ;
        
        moveVector = lookAt.position + startOffset;

        //transform.position = moveVector;
           
        flagCounter += Time.deltaTime; 
        
        if (flagCounter >= 0.3)    
        {                          
            moveFlag = true;       
        }
        if (((Input.GetKey(KeyCode.LeftArrow)) && (moveFlag)) && (!isDead))
        {
            switch (direction)
            {
              case  (0):
                  direction = 1;
                  /*transform.eulerAngles = new Vector3(15, 0, 0);
                  //transform.Rotate(0f, -90f ,0f);
                  */
                  _tempVar = offsetX;
                  offsetX = -offsetZ;
                  offsetZ = _tempVar;
                  flagCounter = 0; 
                  moveFlag = false;
                  ChangeCurrentAngle();
                  break;
              case (1):
                  direction = 3;
                 /* transform.eulerAngles = new Vector3(15, 270, 0);
                  //transform.Rotate(0f, -90f ,0f);
                  */
                  _tempVar = offsetX;
                  offsetX = -offsetZ;
                  offsetZ = _tempVar;
                  flagCounter = 0; 
                  moveFlag = false;
                  ChangeCurrentAngle();
                  break;
              case (2):
                  direction = 0;
                  /* transform.eulerAngles = new Vector3(15, 270, 0);
                   //transform.Rotate(0f, -90f ,0f);
                   */
                  _tempVar = offsetX;
                  offsetX = -offsetZ;
                  offsetZ = _tempVar;
                  flagCounter = 0; 
                  moveFlag = false;
                  ChangeCurrentAngle();
                  break;
              case (3):
                  direction = 2;
                  /* transform.eulerAngles = new Vector3(15, 270, 0);
                   //transform.Rotate(0f, -90f ,0f);
                   */
                  _tempVar = offsetX;
                  offsetX = -offsetZ;
                  offsetZ = _tempVar;
                  flagCounter = 0; 
                  moveFlag = false;
                  ChangeCurrentAngle();
                  break;
            }
        }

        if (((Input.GetKey(KeyCode.RightArrow)) && (moveFlag)) && (!isDead))
        {
            switch (direction)
            {
                case (0):
                    direction = 2;
                    _tempVar = offsetX;
                    offsetX = offsetZ;
                    offsetZ = -_tempVar;
                    flagCounter = 0;
                    moveFlag = false;
                    ChangeCurrentAngle();
                    break;
                case (1):
                    direction = 0;
                    _tempVar = offsetX;
                    offsetX = offsetZ;
                    offsetZ = -_tempVar;
                    flagCounter = 0;
                    moveFlag = false;
                    ChangeCurrentAngle();
                    break;
                case (2):
                    direction = 3;
                    _tempVar = offsetX;
                    offsetX = offsetZ;
                    offsetZ = -_tempVar;
                    flagCounter = 0;
                    moveFlag = false;
                    ChangeCurrentAngle();
                    break;
                case (3):
                    direction = 1;
                    _tempVar = offsetX;
                    offsetX = offsetZ;
                    offsetZ = -_tempVar;
                    flagCounter = 0;
                    moveFlag = false;
                    ChangeCurrentAngle();
                    break;
            }
        }

        transform.position = Vector3.Lerp(transform.position, moveVector, 0.1f);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentAngle, 0.1f);
    }
    public void OnDeath()
    {
        isDead = true;
    }
    
    public void ChangeCurrentAngle()
    {
        switch (direction)
        {
            case 0:
                currentAngle = targetFront;
                break;
            case 1:
                currentAngle = targetLeft;
                break;
            case 2:
                currentAngle = targetRight;
                break;
            case 3:
                currentAngle = targetBack;
                break;
        }
    }

    public void PauseCamera()
    {
        isPaused = !isPaused;
    }
}

