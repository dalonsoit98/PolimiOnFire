using System;
using System.Collections;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Object = UnityEngine.Object;

public class PlayerMove : MonoBehaviour
{
    
    private CharacterController _charController;
    private Animator _animator;
    private CountdownScript countDownScript;
    public PauseMenuEndless pauseMenu;

    //move variables
    public float moveSpeed = 6.0f;
    public float leftRightSpeed = 9f;
    public Vector3 v_movement;
    public bool moveFlag = true;
    public bool turnFlag = false;
    private double flagCounter = 0;
    private double flagJumpCounter = 0;
    public float jumpSpeed = 3.5f;
    //public float deviation = 0f;
    public Vector3 RL;
    public bool AFlag = true;
    public bool DFlag = true;

    //Gravity
    public float verticalVelocity;
    public float gravity = 12.0f;
    public float jumpDelay = 1.0f;
    
    // Death Control
    public bool isDead = false;
    public bool isStarted = false;
    public float startCountDown;
    
    // pause control
    public bool isPaused = false;
    
    //Skins
    public GameObject player;
    private int texId = 0;
    public Object[] texturesPlayer;
    private Renderer _rendererPlayer;
    
    //Tutorial
    public GameObject pressA;
    public GameObject pressD;
    public GameObject pressR;
    public GameObject pressL;
    public GameObject pressSpace;
    private float startXTutorial = -40f;
    private float startYTutorial = 0f;
    private float startZTutorial = -40f;
    public bool isTutorial;
    public bool isTutorialA;
    public bool isTutorialD;
    public bool isTutorialR;
    public bool isTutorialL;
    public bool isTutorialSpace;
    public bool flagA = false;
    public bool flagD = false;
    public bool flagR = false;
    public bool flagL = false;
    public bool flagSpace = false;
    public bool flagJump = true;

    // Start is called before the first frame update
    void Start()
    {
        //Skin Load
        _rendererPlayer = player.GetComponent<Renderer>();
        string textPath = "Texture";
        texturesPlayer = Resources.LoadAll(textPath, typeof(Texture2D));
        _rendererPlayer.material.SetTexture("_MainTex", (Texture2D)texturesPlayer[texId]);
        //Movement
        
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        _charController = GetComponent<CharacterController> ();
        _animator = GetComponentInChildren<Animator>();
        isDead = false;
        isStarted = false;
        //FindObjectOfType<FloorManager>().Restart();
        countDownScript = FindObjectOfType<CountdownScript>();
        countDownScript.CountdownFinished(false);
        FindObjectOfType<AudioManager>().StartCountdown();
        _charController.transform.position = Vector3.zero;
        
        //Tutorial
        pressA.SetActive(false);
        pressD.SetActive(false);
        pressSpace.SetActive(false);
        pressR.SetActive(false);
        pressL.SetActive(false);
        
        if (isTutorial)
        {
            _charController.transform.position = new Vector3(startXTutorial, startYTutorial, startZTutorial);
            flagJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted == false)
        {
            StartRunning();
            return;
        }
        if (isDead)
        {
            DeathRunning();
            FindObjectOfType<AudioManager>().MusicStop();
            return;
        }

        if (isTutorialA && !flagA)
        {
            pressA.SetActive(true);
            _animator.enabled = false;
            FindObjectOfType<Score>().isPaused = true;
            if (Input.GetKey(KeyCode.A))
            {
                FindObjectOfType<Score>().isPaused = false;
                _animator.enabled = true;
                flagA = true;
                pressA.SetActive(false);
            }
            return;
        }
        
        if (isTutorialD && !flagD)
        {
            pressD.SetActive(true);
            _animator.enabled = false;
            FindObjectOfType<Score>().isPaused = true;
            if (Input.GetKey(KeyCode.D))
            {
                FindObjectOfType<Score>().isPaused = false;
                _animator.enabled = true;
                flagD = true;
                pressD.SetActive(false);
            }
            return;
        }
        
        if (isTutorialSpace && !flagSpace)
        {
            pressSpace.SetActive(true);
            _animator.enabled = false;
            FindObjectOfType<Score>().isPaused = true;
            if (Input.GetKey(KeyCode.Space))
            {
                FindObjectOfType<Score>().isPaused = false;
                _animator.enabled = true;
                flagSpace = true;
                flagJump = true;
                pressSpace.SetActive(false);
            }
            return;
        }
        
        if (isTutorialR && !flagR)
        {
            pressR.SetActive(true);
            _animator.enabled = false;
            FindObjectOfType<Score>().isPaused = true;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                FindObjectOfType<Score>().isPaused = false;
                _animator.enabled = true;
                flagR = true;
                pressR.SetActive(false);
            }
            return;
        }
        
        if (isTutorialL && !flagL)
        {
            pressL.SetActive(true);
            _animator.enabled = false;
            FindObjectOfType<Score>().isPaused = true;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                FindObjectOfType<Score>().isPaused = false;
                _animator.enabled = true;
                flagL = true;
                pressL.SetActive(false);
            }
            return;
        }
        if (isPaused)
        {
            _animator.enabled = false;
            return;
        }
        
        _animator.enabled = true;
        FindObjectOfType<Score>().isPaused = false;
        
        v_movement = _charController.transform.forward;
        v_movement.y = verticalVelocity;
       
        RL = Vector3.Cross(v_movement, new Vector3(0f, 1f));
       _charController.Move (v_movement * Time.deltaTime * moveSpeed);
        flagCounter += Time.deltaTime;
        flagJumpCounter += Time.deltaTime;
        
        if (_charController.isGrounded)
        {
            if ((Input.GetKey(KeyCode.Space) && (flagJumpCounter >= jumpDelay) && flagJump))
            {
                StartCoroutine(Jump());
                verticalVelocity = jumpSpeed;
                flagJumpCounter = 0;
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
    
        if (flagCounter >= 2.0)
        {
            moveFlag = true;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
            isPaused = true;
        }
        if (Input.GetKey(KeyCode.A) && AFlag)
        {
            _charController.transform.Translate(RL * Time.deltaTime * leftRightSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D) && DFlag)
        {
            _charController.transform.Translate(RL * Time.deltaTime * leftRightSpeed* -1, Space.World);
        }
        if ((Input.GetKey(KeyCode.LeftArrow)) && (v_movement.x > -1) && (moveFlag) && (turnFlag) && !isTutorialR)
        {
            flagCounter = 0; 
            moveFlag = false;
            _charController.transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        if ((Input.GetKey(KeyCode.RightArrow)) && (v_movement.x < 1) && (moveFlag) && (turnFlag) && !isTutorialL)
        {
            flagCounter = 0;
            moveFlag = false;
            _charController.transform.Rotate(new Vector3(0f, 90f, 0f));
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((!isDead && ((hit.gameObject.tag == "Wall") || (hit.gameObject.tag == "Obstacle"))))
        {
            Debug.Log("GameOver");
            Death();
        }

        turnFlag = ((hit.gameObject.tag == "Turn") || (hit.gameObject.tag == "TurnRTutorial") ||
                    (hit.gameObject.tag == "TurnLTutorial"));
        
        isTutorialA = hit.gameObject.tag == "TutorialA";
        isTutorialD = hit.gameObject.tag == "TutorialD";
        isTutorialR = hit.gameObject.tag == "TurnRTutorial";
        isTutorialL = hit.gameObject.tag == "TurnLTutorial";
        isTutorialSpace = hit.gameObject.tag == "TutorialSpace";
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
        FindObjectOfType<MainCamera>().OnDeath();
        isStarted = false;
        FindObjectOfType<AudioManager>().Death();
    }

    private IEnumerator Jump()
    {
        _animator.SetTrigger("JumpTrigger");
        yield return new WaitForSeconds(3.0f);
    }

    public void SetSpeed(float modifier)
    {
        moveSpeed = 6.0f + modifier;
        switch (moveSpeed)
        {
            case 7:
                jumpSpeed = 3.3f;
                break;
            case 8:
                jumpSpeed = 3.1f;
                break;
            case 9:
                jumpSpeed = 2.9f;
                break;
            case 10:
                jumpSpeed = 2.85f;
                break;
            case 11:
                jumpSpeed = 2.82f;
                break;
            case 12:
                jumpSpeed = 2.6f;
                break;
            case 13:
                jumpSpeed = 2.5f;
                break;
            case 14:
                jumpSpeed = 2.4f;
                break;
            case 15:
                jumpSpeed = 2.3f;
                jumpDelay = 0.9f;
                break;
            case 16:
                jumpSpeed = 2.2f;
                break;
            case 17:
                jumpSpeed = 2.1f;
                break;
            case 18:
                jumpSpeed = 2.0f;
                break;
            case 19:
                jumpSpeed = 1.9f;
                leftRightSpeed += 2;
                break;
            case 20:
                jumpSpeed = 1.88f;
                break;
            case 21:
                jumpSpeed = 1.85f;
                break;
        }
    }
    
    private void Pause()
    {
        isPaused = true;
        //GetComponent<Score>().OnDeath();
        //FindObjectOfType<AudioManager>().Death();
        pauseMenu.TogglePauseMenu();
    }

    private void StartRunning()
    {
       if (startCountDown > 4f){ 
           FindObjectOfType<Score>().HasStarted();
           _animator.SetTrigger("StartTrigger");
            isStarted = true;
            countDownScript.CountdownFinished(true);
            FindObjectOfType<AudioManager>().StartEndless();
       }
       else
       {
           //v_movement = _charController.transform.forward;
           //_charController.Move (v_movement * Time.deltaTime * moveSpeed * 0.01f);
           startCountDown += Time.deltaTime;
       }
    }

    private void DeathRunning()
    {
        v_movement.x = 0.0f;
        v_movement.y -= gravity * Time.deltaTime;
        v_movement.z = 0.0f;
        _charController.Move (v_movement * Time.deltaTime * moveSpeed);
       _animator.SetTrigger("DeathTrigger");
    }

    void OnEnable()
    {
        texId = PlayerPrefs.GetInt("textureId");
        isTutorial = PlayerPrefs.GetInt("TutorialFlag") == 1;
    }
    
    
}
