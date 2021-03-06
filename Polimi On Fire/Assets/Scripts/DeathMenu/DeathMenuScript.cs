using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathMenuScript : MonoBehaviour
{
    public Text scoreText;
    public Image backgroundImg;
    public bool isShown = false;
    public int isTutorial;

    private float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
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

    public void ToogleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int) score).ToString();
        isShown = true;
    }

    public void PlayAgain()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        isTutorial = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("EndlessMenu");
    }
    
    void OnDisable()
    {
        PlayerPrefs.SetInt("TutorialFlag", isTutorial);
    }
}
