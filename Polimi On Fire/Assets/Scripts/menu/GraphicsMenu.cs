using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraphicsMenu : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
 	public void ToOptionsScene()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("Options");
    }
	
}
