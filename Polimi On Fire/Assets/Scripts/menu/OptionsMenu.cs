using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public void CommandsScene()
    {
        SceneManager.LoadScene("CommandsMenu");
    }
    public void VolumeScene()
    {
        SceneManager.LoadScene("Volume");
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene("ManinMenu");
    }
}
