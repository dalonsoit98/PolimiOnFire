
using UnityEngine;


public class MainCamera : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;

    private float offsetX = 0f;
    private float offsetY = 2.87f;
    private float offsetZ = -3.65f;

    public bool isPaused = false;
    
    // Smooth change
    public Quaternion currentAngle;
    Quaternion targetRight = Quaternion.Euler(15,90,0);
    Quaternion targetLeft = Quaternion.Euler(15,270,0);
    Quaternion targetFront = Quaternion.Euler(15,0,0);
   // private Vector3 currentPosition;
    private int direction;

    private float _tempVar;
    public Vector3 v_movement;
    public bool moveFlag = true;    
    public int flagForward;
    private double flagCounter = 0;

    public PlayerMove script;
    
    //Animacion
    private Vector3 moveVector;
    
    //Dead
    private bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = targetFront;
        direction = 0;
        
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;

        gameObject.transform.position = lookAt.position + new Vector3(offsetX, offsetY, offsetZ);
        
        flagForward = 1;
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
        
        if (flagCounter >= 2.0)    
        {                          
            moveFlag = true;       
        }
        if (((Input.GetKey(KeyCode.LeftArrow)) && (v_movement.x > -1) && (moveFlag)) && (!isDead) && (FindObjectOfType<PlayerMove>().turnFlag) && !FindObjectOfType<PlayerMove>().isTutorialR)
        {
            switch (flagForward)
            {
              case  (0):
                  direction = 0;
                  /*transform.eulerAngles = new Vector3(15, 0, 0);
                  //transform.Rotate(0f, -90f ,0f);
                  */
                  _tempVar = offsetX;
                  offsetX = -offsetZ;
                  offsetZ = _tempVar;
                  flagCounter = 0; 
                  moveFlag = false;
                  flagForward = 1;
                  ChangeCurrentAngle();
                  break;
              case (1):
                  direction = 1;
                 /* transform.eulerAngles = new Vector3(15, 270, 0);
                  //transform.Rotate(0f, -90f ,0f);
                  */
                  _tempVar = offsetX;
                  offsetX = -offsetZ;
                  offsetZ = _tempVar;
                  flagCounter = 0; 
                  moveFlag = false;
                  flagForward = 0;
                  ChangeCurrentAngle();
                  break;
            }
        }

        if (((Input.GetKey(KeyCode.RightArrow)) && (v_movement.x < 1) && (moveFlag)) && (!isDead) && (FindObjectOfType<PlayerMove>().turnFlag) && !FindObjectOfType<PlayerMove>().isTutorialL)
        {
            switch (flagForward)
            {
                case (0):
                    direction = 0;
                    /*    transform.eulerAngles = new Vector3(15, 0, 0);
                        //transform.Rotate(0f, 90f ,0f);
                       */
                    _tempVar = offsetX;
                    offsetX = offsetZ;
                    offsetZ = -_tempVar;
                    flagCounter = 0;
                    moveFlag = false;
                    
                    flagForward = 1;
                    ChangeCurrentAngle();
                    break;
                case (1):
                    direction = 2;
                    /*transform.eulerAngles = new Vector3(15, 90, 0);
                    //transform.Rotate(0f, 90f ,0f);
                    */
                    _tempVar = offsetX;
                    offsetX = offsetZ;
                    offsetZ = -_tempVar;
                    flagCounter = 0;
                    moveFlag = false;
                    flagForward = 0;
                    ChangeCurrentAngle();
                    break;
            }
        }

        transform.position = Vector3.Lerp(transform.position, moveVector, 0.05f);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentAngle, 0.05f);
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
        }
    }
    public void PauseCamera()
    {
        isPaused = !isPaused;
    }
}
