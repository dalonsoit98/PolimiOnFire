using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("GameplayRun");
    }
    
    public void EndlessTutorial()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("GameplayRun");
    }
    
    public void ToMainScene()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("ManinMenu");
    }
}
