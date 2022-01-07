using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuBuilding : MonoBehaviour
{
    public Image backgroundImg;
    public PlayerMoveBuilding playerMoveBuilding;
    public TimerScript timer;
    public bool isShown = false;
    public GameObject ControlPanel;
    public GameObject ResumeButton;
    public GameObject ControlsButton;
    public GameObject ToMenuButton;
    public bool isShownControlers = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        ControlPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShown)
        {
            return;
        }
        
    }
    
    public void TogglePauseMenu()
    {
        FindObjectOfType<TimerScript>().PauseTimer();
        FindObjectOfType<MainCameraBuilding1>().PauseCamera();
        gameObject.SetActive(true);
        isShown = true;
    }
    
    public void Resume()
    {
        FindObjectOfType<TimerScript>().PauseTimer();
        FindObjectOfType<AudioManager>().ButtonPress();
        playerMoveBuilding.isPaused = false;
        FindObjectOfType<MainCameraBuilding1>().PauseCamera();
        gameObject.SetActive(false);
    }

    public void Controls()
    {
        ControlPanel.SetActive(true);
        ResumeButton.SetActive(false);
        ControlsButton.SetActive(false);
        ToMenuButton.SetActive(false);
    }

    public void toPauseMenu()
    {
        ControlPanel.SetActive(false);
        gameObject.SetActive(true);
        ResumeButton.SetActive(true);
        ControlsButton.SetActive(true);
        ToMenuButton.SetActive(true);
    }

    public void ToMenu()
    {
        FindObjectOfType<AudioManager>().MusicStop();
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("BuildingMenu");
    }
}
