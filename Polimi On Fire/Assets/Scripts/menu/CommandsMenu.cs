using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandsMenu : MonoBehaviour
{
    public void ToOptionsScene()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("Options");
    }
}
