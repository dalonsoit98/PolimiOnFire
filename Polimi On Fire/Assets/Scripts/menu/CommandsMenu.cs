using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandsMenu : MonoBehaviour
{
    public void ToOptionsScene()
    {
        SceneManager.LoadScene("Options");
    }
}
