using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessMenu : MonoBehaviour
{
    public int isTutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void EndlessStart()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        isTutorial = 0;
        SceneManager.LoadScene("GameplayRun");
    }
    
    public void EndlessTutorial()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        isTutorial = 1;
        SceneManager.LoadScene("GameplayRun");
    }
    
    public void ToMainScene()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("ManinMenu");
    }
    
    void OnDisable()
    {
        PlayerPrefs.SetInt("TutorialFlag", isTutorial);
    }
}
