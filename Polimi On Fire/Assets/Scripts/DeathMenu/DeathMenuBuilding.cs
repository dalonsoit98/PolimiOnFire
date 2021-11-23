using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathMenuBuilding : MonoBehaviour
{
    public Image backgroundImg;
    public bool isShown = false;

    private float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        backgroundImg.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShown)
        {
            return;
        }

        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }

    public void ToogleEndMenu()
    {
        gameObject.SetActive(true);
        isShown = true;
    }

    public void PlayAgain()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("ManinMenu");
    }
}