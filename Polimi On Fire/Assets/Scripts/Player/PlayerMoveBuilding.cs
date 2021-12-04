using System.Collections;
using SD;
using UnityEngine;

public class PlayerMoveBuilding : MonoBehaviour
{
    private CharacterController _charController;
    private Animator _animator;
    
    //Timer
    [SerializeField] private TimerScript timer1;
    
    //Death Menu
    public DeathMenuBuilding deathMenu;
    public PauseMenuBuilding pauseMenu;
    public CheckListScript checkListScript;
    public TimerDeathScript timerDeathScript;
    public FireDeath fireDeath;
    
    //move variables
    public float moveSpeed = 6.0f;
    public float leftRightSpeed = 6f;
    public Vector3 v_movement;
    public bool moveFlag = true;
    public bool turnFlag = false;
    private double flagCounter = 0;
    private double flagJumpCounter = 0;
    public float jumpSpeed = 3.5f;
    //public float deviation = 0f;
    public Vector3 RL;
    
    //Gravity
    public float verticalVelocity;
    public float gravity = 12.0f;
    
    // Death Control
    public bool isDead;
    
    // Pause Control
    public bool isPaused;
    
    // Pause Dialog
    public bool isDialog;
    
    // Pause at Win
    public bool isWin;
    
    //Skins
    public GameObject player;
    private int texId = 0;
    public Object[] texturesPlayer;
    private Renderer _rendererPlayer;
    
    //Npc
    //public NPCFollow npcFollow;
    // Start is called before the first frame update
    void Start()
    {
        //Skin Load
        //_rendererPlayer = player.GetComponent<Renderer>();
        FindObjectOfType<AudioManager>().StartBuilding();
        string textPath = "Texture";
        texturesPlayer = Resources.LoadAll(textPath, typeof(Texture2D));
        player.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.SetTexture("_MainTex", (Texture2D)texturesPlayer[texId]);
        //Move
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        _charController = GetComponent<CharacterController> ();
        _animator = GetComponentInChildren<Animator>();
        isDead = false;
        isPaused = false;
        isDialog =  false;
        isWin = false;
        
        //Timer
        
        timer1.SetDuration(300).Begin();
        
        //DeathMenu
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWin)
        {
            FindObjectOfType<AudioManager>().MusicStop();
            return;
        }
        
        if (isDead)
        {
            FindObjectOfType<AudioManager>().MusicStop();
            DeathRunning();
            return;
        }
        
        if (isDialog)
        {
            _animator.enabled = false;
            return;
        }
        
        if (isPaused)
        {
            _animator.enabled = false;
            return;
        }

        _animator.enabled = true;
        
        v_movement.y = verticalVelocity;

        RL = Vector3.Cross(v_movement, new Vector3(0f, 1f));
       _charController.Move (v_movement * Time.deltaTime * moveSpeed);
       flagCounter += Time.deltaTime;
        flagJumpCounter += Time.deltaTime;
        
        if (_charController.isGrounded)
        {
            if ((Input.GetKey(KeyCode.Space) && (flagJumpCounter >= 0.5)))
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
    
        if (flagCounter >= 0.3)
        {
            moveFlag = true;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
            isPaused = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //npcFollow.isPlayerAction = true;
            _charController.transform.Translate(v_movement * Time.deltaTime, Space.World);
            _animator.SetTrigger("RunTrigger");
            v_movement = _charController.transform.forward;
        }
        else
        {
                //npcFollow.isPlayerAction = false;
                _animator.SetTrigger("IddleTrigger");
                v_movement = new Vector3(0,0,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _charController.Move(RL * Time.deltaTime * leftRightSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _charController.Move(RL * Time.deltaTime * -1 * leftRightSpeed);
        }
        if ((Input.GetKey(KeyCode.LeftArrow)) && (moveFlag))
        {
            flagCounter = 0;
            moveFlag = false;
            _charController.transform.Rotate(new Vector3(0f, -90f, 0f));
            v_movement = _charController.transform.forward;
        }

        if ((Input.GetKey(KeyCode.RightArrow)) && (moveFlag))
        {
            flagCounter = 0;
            moveFlag = false;
            _charController.transform.Rotate(new Vector3(0f, 90f, 0f));
            v_movement = _charController.transform.forward;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!isDead && (hit.gameObject.tag == "Fire"))
        {
            Debug.Log("GameOver");
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        //GetComponent<Score>().OnDeath();
        FindObjectOfType<MainCameraBuilding1>().OnDeath();
        //FindObjectOfType<AudioManager>().Death();
        timer1.PauseTimer();
        deathMenu.ToogleEndMenu();
        fireDeath.ToggleFireDeath();
        FindObjectOfType<AudioManager>().FireDeath();
    }
    
    private void Pause()
    {
        isPaused = true;
        //GetComponent<Score>().OnDeath();
        //FindObjectOfType<AudioManager>().Death();
        pauseMenu.TogglePauseMenu();
    }

    public void timerDeath()
    {
        isDead = true;
        //GetComponent<Score>().OnDeath();
        FindObjectOfType<MainCameraBuilding1>().OnDeath();
        //FindObjectOfType<AudioManager>().Death();
        deathMenu.ToogleEndMenu();
        timerDeathScript.ToggleTimerDeath();
        FindObjectOfType<AudioManager>().FireDeath();
    }

    private IEnumerator Jump()
    {
        _animator.SetTrigger("JumpTrigger");
        yield return new WaitForSeconds(3.0f);
    }

    public void SetSpeed(float modifier)
    {
        moveSpeed = 6.0f + modifier;
        jumpSpeed = 3.5f - (float) (modifier * 0.2);
    }

    public void activateToggle(int id)
    {
        checkListScript.actionToggle(id);
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
    }
}

