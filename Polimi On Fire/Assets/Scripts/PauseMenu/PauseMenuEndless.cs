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
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
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

    public void ToMenu()
    {
        FindObjectOfType<AudioManager>().MusicStop();
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("ManinMenu");
    }
}