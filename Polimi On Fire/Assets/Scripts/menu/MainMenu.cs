using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        SceneManager.LoadScene("GameplayRun");
    }
     public void CreditsScene()
        {
            SceneManager.LoadScene("Credits");
        }

     public void BuildScene()
     {
         SceneManager.LoadScene("Building1");
     }
     public void OptionsScene()
     {
        SceneManager.LoadScene("Options");
     }
     
     public void CharacterScene()
     {
         SceneManager.LoadScene("Character");
     }

     public void QuitGame()
     {
         Application.Quit();
     }
}
