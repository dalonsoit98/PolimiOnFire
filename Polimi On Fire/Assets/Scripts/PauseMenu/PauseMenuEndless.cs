using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuEndless : MonoBehaviour
{
    public Image backgroundImg;
    public PlayerMove playerMove;
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
        FindObjectOfType<MainCamera>().PauseCamera();
        FindObjectOfType<Score>().Pause();
        gameObject.SetActive(true);
        isShown = true;
    }
    
    public void Resume()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        playerMove.isPaused = false;
        FindObjectOfType<MainCamera>().PauseCamera();
        FindObjectOfType<Score>().Pause();
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
        SceneManager.LoadScene("EndlessMenu");
    }
}