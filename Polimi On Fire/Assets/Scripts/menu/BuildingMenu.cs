using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Building1()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("StartBuilding1");
    }
    
    public void Building2()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        //SceneManager.LoadScene("Building2");
    }
    
    public void Building3()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        //SceneManager.LoadScene("Building3");
    }
    
    public void Building4()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        //SceneManager.LoadScene("Building4");
    }
    
    public void ToMainScene()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("ManinMenu");
    }
}
