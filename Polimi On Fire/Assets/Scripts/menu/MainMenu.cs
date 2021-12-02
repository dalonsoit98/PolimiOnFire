using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameScene()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("GameplayRun");
    }
     public void CreditsScene()
        {
            FindObjectOfType<AudioManager>().ButtonPress();
            SceneManager.LoadScene("Credits");
        }

     public void BuildScene()
     {
         FindObjectOfType<AudioManager>().ButtonPress();
         SceneManager.LoadScene("BuildingMenu");
     }
     public void OptionsScene()
     {
         FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("Options");
     }
     
     public void CharacterScene()
     {
         FindObjectOfType<AudioManager>().ButtonPress();
         SceneManager.LoadScene("Character");
     }

     public void QuitGame()
     {
         FindObjectOfType<AudioManager>().ButtonPress();
         Application.Quit();
     }
}
